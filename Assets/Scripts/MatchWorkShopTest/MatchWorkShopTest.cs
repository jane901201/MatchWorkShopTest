using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MatchWorkShopTest : MonoBehaviour
{
    [Header("GameSystem")]
    [SerializeField] private InventorySystem m_InventorySystem;
    [SerializeField] private SaveDataSystem m_SaveDataSystem;

    [Header("UI")]
    [SerializeField] private InventoryUIController m_InventoryUIController;
    [SerializeField] private DataCheckInfoUIController m_DataCheckInfoUIController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame");
    }
}
