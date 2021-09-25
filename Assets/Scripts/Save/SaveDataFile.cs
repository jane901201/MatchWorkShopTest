using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[System.Serializable]
public class SaveDataFile
{
    [SerializeField] private List<Item> m_InventoryItem;
    [SerializeField] private GameObject[] m_WorldItems;
    [SerializeField] private Transform m_PlayerInitinalTransform;

    public SaveDataFile()
    {

    }

    public List<Item> InventoryItem { get => m_InventoryItem; private set => m_InventoryItem = value; }
    public GameObject[] WorldItems { get => m_WorldItems; private set => m_WorldItems = value; }
    public Transform PlayerInitinalTransform { get => m_PlayerInitinalTransform; private set => m_PlayerInitinalTransform = value; }
}