using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryItem m_InventoryItem = new InventoryItem();

    public InventoryItem InventoryItem => m_InventoryItem;
}
