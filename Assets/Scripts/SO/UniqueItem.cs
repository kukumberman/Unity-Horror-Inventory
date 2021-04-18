using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "[Unique Item]", menuName = "SO/Unique Item")]
public class UniqueItem : ScriptableObject
{
    [Header("Unique Item")]
    [SerializeField] private string m_Id = "None";

    public string Id => m_Id;
}
