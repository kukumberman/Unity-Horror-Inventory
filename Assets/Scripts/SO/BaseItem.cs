using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "[Base Item]", menuName = "SO/Inventory/Base Item")]
public class BaseItem : UniqueItem
{
    [Header("Base Item")]
    [SerializeField] private string m_ItemName = "New Item";
    [SerializeField] private Sprite m_Sprite = null;
    [SerializeField] private int m_MaxStack = 1;

    public string Name => m_ItemName;
    public Sprite Sprite => m_Sprite;
    public int MaxStack => m_MaxStack;
}
