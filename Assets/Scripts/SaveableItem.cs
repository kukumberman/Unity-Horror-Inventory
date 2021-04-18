using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class SaveableItem
{
    public string Id = "";
    public int Amount = 0;

    public SaveableItem(InventoryItem inventoryItem)
    {
        if (!inventoryItem.IsEmpty())
        {
            Id = inventoryItem.Item.Id;
            Amount = inventoryItem.Amount;
        }
    }
}
