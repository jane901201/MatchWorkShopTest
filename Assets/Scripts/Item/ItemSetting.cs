using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSetting : MonoBehaviour
{
    [SerializeField] private HowToGet m_HowToGet;
    [SerializeField] private List<Item> m_Items = new List<Item>();

    private Item m_MustBeSettingItem = null;

    public List<Item> GetItems()
    {
        return m_Items;
    }

    public void SetInitialItems(List<Item> items)
    {
        m_Items = items;
    }

    public void IncreaseItemAmount(Item increaseItem, int num)
    {
        if (IsHaveItem_WillSettingItemIfHave(increaseItem))
        {
            int index = m_Items.IndexOf(m_MustBeSettingItem);
            m_Items[index].Amount += num;
        }
        else
        {
            Debug.Log("Can't find this item, try to check itemName or Type again.");
        }
    }

    public void DecreaseItemAmount(Item decreaseItem, int num)
    {
        if (IsHaveItem_WillSettingItemIfHave(decreaseItem))
        {
            int index = m_Items.IndexOf(m_MustBeSettingItem);
            m_Items[index].Amount -= num;
        }
        else
        {
            Debug.Log("Can't find this item, try to check itemName or Type again.");
        }

    }


    public HowToGet GetHowToGet()
    {
        return m_HowToGet;
    }

    public void CurrectItems()
    {
        int i = 0;
        Debug.Log("Currect " + GetHowToGet().GetType().ToString()
                + "Have ");
        foreach (Item item in m_Items)
        {
            Debug.Log("Item " + i + " " + item.ItemName + " " + item.Amount);
            i++;
        }
    }

    private bool IsHaveItem_WillSettingItemIfHave(Item item)
    {
        string itemName = item.ItemName;
        bool IsHaveItem = false;

        foreach (Item items in m_Items)
        {
            if (items.ItemName.Equals(itemName))
            {
                //Debug.Log("Have same item.");
                IsHaveItem = true;
                SetMustBeSettingItem(items);
                return IsHaveItem;
            }
        }

        Debug.Log("It don't have same item");

        return IsHaveItem;
    }

    private void SetMustBeSettingItem(Item item)
    {
        m_MustBeSettingItem = item;
    }

}

public enum HowToGet
{
    Inventory,
    Drop
}