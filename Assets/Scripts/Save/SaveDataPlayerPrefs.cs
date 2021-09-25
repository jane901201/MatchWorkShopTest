using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataPlayerPrefs
{
    private string[] m_InventoryNames = new string[9];

    public string[] InventoryNames { get => m_InventoryNames; private set => m_InventoryNames = value; }

    public void SetInventoryItemData()
    {
        PlayerPrefs.SetInt("WhiteChocolate", 0);
        PlayerPrefs.SetInt("BlackChocolate", 2);
        PlayerPrefs.SetInt("WhitePotion", 0);
        PlayerPrefs.SetInt("RedPotion", 3);
        PlayerPrefs.SetInt("OrangePotion", 7);
        PlayerPrefs.SetInt("YellowPotion", 1);
        PlayerPrefs.SetInt("GreenPotion", 4);
        PlayerPrefs.SetInt("BlutPotion", 5);
        PlayerPrefs.SetInt("key", 0);
    }

    public void SetInventoryNames()
    {
        InventoryNames[0] = "WhiteChocolate";
        InventoryNames[1] = "BlackChocolate";
        InventoryNames[2] = "WhitePotion";
        InventoryNames[3] = "RedPotion";
        InventoryNames[4] = "OrangePotion";
        InventoryNames[5] = "YellowPotion";
        InventoryNames[6] = "GreenPotion";
        InventoryNames[7] = "BlutPotion";
        InventoryNames[8] = "key";
    }

    public int GetNum(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }

}
