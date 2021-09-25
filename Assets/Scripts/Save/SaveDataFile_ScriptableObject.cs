using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SaveData")]
public class SaveDataFile_ScriptableObject : ScriptableObject
{
    [SerializeField, ReadOnly] private List<Item> m_InventoryItem;

    public List<Item> InventoryItem { get => m_InventoryItem; private set => m_InventoryItem = value; }
}