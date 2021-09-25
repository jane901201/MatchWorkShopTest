using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Recording player item
/// Add item
/// Remove Item
/// </summary>
public class InventorySystem : MonoBehaviour
{
    [Header("Player Prefabs")]
    [SerializeField] private ItemSetting m_InventoryItemSetting;

    private List<Item> m_GetGettingItems = new List<Item>();//TODO:Field->Local
    private List<Item> m_WillBeUseItems = new List<Item>();
    private bool m_IsItemUpdate = false;

    public bool IsItemUpdate { get => m_IsItemUpdate; set => m_IsItemUpdate = value; }

    private void Awake()
    {
        IsItemUpdate = true;
    }

    private void Start()
    {
        SetWillShowItems();
    }

    public void SetInitinalInventoryItems(List<Item> items)
    {
        m_InventoryItemSetting.SetInitialItems(items);
        SetWillShowItems();
    }

    public List<Item> GetInventoryWillBeUseItems()
    {
        return m_WillBeUseItems;
    }

    public List<Item> GetInventoryItems()
    {
        return m_InventoryItemSetting.GetItems();
    }

    public void SetGettingItem(List<Item> items)
    {
        m_IsItemUpdate = true;
        //Debug.Log("Item is updated " + m_IsItemUpdate);
        m_GetGettingItems = items;
        //Debug.Log("Get item " + items.ToString());
        for (int i = 0; i < m_GetGettingItems.Count; i++)
        {
            IncreaseItemAmount(m_GetGettingItems[i], m_GetGettingItems[i].Amount);
        }
        SetWillShowItems();
        //m_InventoryItem.CurrectItems();
    }

    public void SetBeUsedItems(List<Item> items)
    {
        m_IsItemUpdate = true;
        m_GetGettingItems = items;
        List<Item> tmpInventoryItems = m_WillBeUseItems;
        for(int i = 0; i < m_GetGettingItems.Count; i++)
        {
            int tmpDecreaseAmount = tmpInventoryItems[i].Amount - m_GetGettingItems[i].Amount;
            DecreaseItemAmount(m_GetGettingItems[i], tmpDecreaseAmount);
        }
        SetWillShowItems();
    }

    private void IncreaseItemAmount(Item item, int amount)
    {
        m_InventoryItemSetting.IncreaseItemAmount(item, amount);
    }

    private void DecreaseItemAmount(Item item, int amount)
    {
        m_InventoryItemSetting.DecreaseItemAmount(item, amount);
    }

    private void SetWillShowItems()
    {
        m_WillBeUseItems.Clear();
        List<Item> tmpItems = m_InventoryItemSetting.GetItems();
        for (int i = 0; i < tmpItems.Count; i++)
        {
            if (tmpItems[i].Amount > 0)
            {
                m_WillBeUseItems.Add(tmpItems[i]);
            }
        }

        //CurrectWillBeUseItems();
    }

    private void CurrectWillBeUseItems()
    {
        int i = 0;
        Debug.Log("Currect Will Show Items");
        foreach (Item item in m_WillBeUseItems)
        {
            Debug.Log("Item " + i + " " + item.ItemName + " " + item.Amount);
            i++;
        }
    }
}