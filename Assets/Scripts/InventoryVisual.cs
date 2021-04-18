using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisual : MonoBehaviour
{
    [SerializeField] private Inventory m_Inventory = null;
    [SerializeField] private InventoryCell m_CellPrefab = null;
    [SerializeField] private Transform m_CellsParent = null;

    private InventoryCell[] m_Cells = null;

    private void OnEnable()
    {
        m_Inventory.OnStart += OnInventoryStart;
        m_Inventory.OnItemAdded += OnItemAdded;
    }

    private void OnDisable()
    {
        m_Inventory.OnStart -= OnInventoryStart;
        m_Inventory.OnItemAdded -= OnItemAdded;
    }

    private void OnItemAdded(Inventory.OnItemAddedEventArgs args)
    {
        UpdateVisual();
    }

    private void OnInventoryStart()
    {
        //todo: delete existing cells

        int length = m_Inventory.Items.Length;

        m_Cells = new InventoryCell[length];

        for (int i = 0; i < length; i++)
        {
            InventoryCell cell = Instantiate(m_CellPrefab, m_CellsParent);
            m_Cells[i] = cell;
        }

        UpdateVisual();
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < m_Cells.Length; i++)
        {
            m_Cells[i].UpdateVisual(m_Inventory.Items[i]);
        }
    }
}
