﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class MatchWorkShopTest
{
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
        List<Item> items = m_InventorySystem.GetInventoryWillShowItems();
        m_InventoryUIController.SetInventoryItems(items);
        m_InventoryUIController.IsItemUpdate = IsItemUpdate();
        m_InventoryUIController.SetIsItemUpdate(IsItemUpdate);
    }

}