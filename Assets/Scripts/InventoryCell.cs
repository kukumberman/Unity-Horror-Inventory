using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image m_Image = null;
    [SerializeField] private Text m_CountLabel = null;

    public void UpdateVisual(InventoryItem inventoryItem)
    {
        bool empty = inventoryItem.IsEmpty();
        Color c = Color.white;
        c.a = empty ? 0 : 1;

        m_Image.color = c;
        m_Image.sprite = empty ? null : inventoryItem.Item.Sprite;

        int amount = inventoryItem.Amount;
        m_CountLabel.text = empty ? "" : (amount > 1 ? amount.ToString() : "");
    }
}
