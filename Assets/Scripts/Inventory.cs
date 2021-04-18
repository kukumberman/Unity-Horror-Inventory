using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Serializable]
    public class SaveData
    {
        public SaveableItem[] Items;

        public SaveData(InventoryItem[] items)
        {
            Items = new SaveableItem[items.Length];
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new SaveableItem(items[i]);
            }
        }
    }

    public class OnItemAddedEventArgs
    {
        public InventoryItem InventoryItem { get; }

        public OnItemAddedEventArgs(InventoryItem inventoryItem)
        {
            InventoryItem = inventoryItem;
        }
    }

    public event Action<OnItemAddedEventArgs> OnItemAdded = null;

    public event Action OnStart = null;

    [SerializeField] private List<BaseItem> ALL_ITEMS = new List<BaseItem>();
    [SerializeField] private InventoryItem[] m_Items = new InventoryItem[0];

    private SaveBehaviour m_SaveBehaviour = null;

    public InventoryItem[] Items => m_Items;

    private void Start()
    {
        m_SaveBehaviour = GetComponent<SaveBehaviour>();

        Load();

        OnStart?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
    }

    private void Save()
    {
        SaveData s = new SaveData(m_Items);
        m_SaveBehaviour.Save(s);
    }

    private void Load()
    {
        SaveData s = null;

        if (m_SaveBehaviour.Load(ref s))
        {
            int length = s.Items.Length;

            m_Items = new InventoryItem[length];

            for (int i = 0; i < length; i++)
            {
                m_Items[i] = new InventoryItem();

                BaseItem item = ALL_ITEMS.Find(e => e.Id == s.Items[i].Id);
                int amount = s.Items[i].Amount;

                if (item)
                {
                    m_Items[i].SetItem(item, amount);
                }
            }
        }
    }

    public bool CanAddItem(InventoryItem inventoryItem)
    {
        for (int i = 0; i < m_Items.Length; i++)
        {
            InventoryItem cellItem = m_Items[i];

            if (cellItem.IsEmpty())
            {
                cellItem.SetItem(inventoryItem.Item, inventoryItem.Amount);

                OnItemAdded?.Invoke(new OnItemAddedEventArgs(cellItem));

                return true;
            }
        }

        return false;
    }
}
