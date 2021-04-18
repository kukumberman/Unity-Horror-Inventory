using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    [SerializeField] private BaseItem m_Item = null;
    [SerializeField] private int m_Amount = 1;

    public BaseItem Item => m_Item;
    public int Amount => m_Amount;

    public bool IsEmpty()
    {
        return m_Item == null;
    }

    public void SetItem(BaseItem item, int amount)
    {
        m_Item = item;
        m_Amount = amount;
    }
}
