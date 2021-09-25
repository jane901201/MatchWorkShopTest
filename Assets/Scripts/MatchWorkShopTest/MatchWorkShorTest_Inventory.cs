using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class MatchWorkShopTest
{
    public void ShowInventoryUI()
    {
        m_InventoryUIController.ShowMainUI();
    }

    public void SetGettingItem(List<Item> items)
    {
        m_InventorySystem.SetGettingItem(items);
    }

    public void SetBeUsedItem(List<Item> items)
    {
        m_InventorySystem.SetBeUsedItems(items);
    }

    public void SetInitinalInventoryItems(List<Item> items)
    {
        m_InventorySystem.SetInitinalInventoryItems(items);
    }

    public void InventoryUI_ShowItemInformation(int i)
    {
        m_InventoryUIController.ShowItemInformation(i);
    }

    public bool IsItemUpdate()
    {
        Debug.Log("Item is updated " + m_InventorySystem.IsItemUpdate);
        return m_InventorySystem.IsItemUpdate;
    }

    public void IsItemUpdate(bool update)
    {
        m_InventorySystem.IsItemUpdate = update;
    }

    public void InventoryUI_Initialize()
    {
        List<Item> items = m_InventorySystem.GetInventoryWillBeUseItems();
        m_InventoryUIController.SetInventoryItems(items);
        m_InventoryUIController.IsItemUpdate = IsItemUpdate();
        m_InventoryUIController.SetIsItemUpdate(IsItemUpdate);
    }

    public void InventoruUI_Update()
    {
        m_InventoryUIController.IsItemUpdate = IsItemUpdate();
    }

}
