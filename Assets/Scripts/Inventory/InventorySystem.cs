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
    [SerializeField] private ItemSetting m_InventoryItem;

    private List<Item> m_GetGettingItems = new List<Item>();
    private List<Item> m_WillShowItems = new List<Item>();
    private bool m_IsItemUpdate = false;

    public bool IsItemUpdate { get => m_IsItemUpdate; set => m_IsItemUpdate = value; }

    private void Awake()
    {
        IsItemUpdate = true; //TODO:Test
    }

    private void Start()
    {
        SetWillShowItems();
    }

    public List<Item> GetInventoryWillShowItems()
    {
        return m_WillShowItems;
    }

    public List<Item> GetInventoryItems()
    {
        return m_InventoryItem.GetItems();
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
    }

    public void IncreaseItemAmount(Item item, int amount)
    {
        m_InventoryItem.IncreaseItemAmount(item, amount);
    }

    public void DecreaseItemAmount(Item item, int amount)
    {
        m_InventoryItem.DecreaseItemAmount(item, amount);
    }

    private void SetWillShowItems()
    {
        m_WillShowItems.Clear();
        List<Item> tmpItems = m_InventoryItem.GetItems();
        for (int i = 0; i < tmpItems.Count; i++)
        {
            if (tmpItems[i].Amount > 0)
            {
                m_WillShowItems.Add(tmpItems[i]);
            }
        }

        //CurrectWillShowItems();
    }

    public void CurrectWillShowItems()
    {
        int i = 0;
        Debug.Log("Currect Will Show Items");
        foreach (Item item in m_WillShowItems)
        {
            Debug.Log("Item " + i + " " + item.ItemName + " " + item.Amount);
            i++;
        }
    }
}