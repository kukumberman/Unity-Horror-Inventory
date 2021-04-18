using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBehaviour : MonoBehaviour
{
    [SerializeField] private string fileName = "";

    public bool Load<T>(ref T data)
    {
        return SaveManager.Load(fileName, ref data);
    }

    public void Save<T>(T data)
    {
        SaveManager.Save(fileName, data);
    }
}