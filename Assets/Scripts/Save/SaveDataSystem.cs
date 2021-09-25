using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private SaveDataFile m_SaveDataFile;

    [Header("MustRecover")]
    [SerializeField] private UnityEvent<List<Item>> m_SetInitinalInventoryItems;
    [SerializeField] private GameObject m_Player;

    SaveDataPlayerPrefs m_SaveDataPlayerPrefs = new SaveDataPlayerPrefs();

    private void Start()
    {
        m_SaveDataPlayerPrefs.SetInventoryItemData();
        m_SaveDataPlayerPrefs.SetInventoryNames();
    }

    private void OnDestroy()
    {
        m_SaveDataPlayerPrefs.Clear();
    }

    public void RecoverData()
    {
        RecoverPlayerPosition();
        RecoverInventoryItem();
        RecoverWorldItem();
    }

    private void RecoverPlayerPosition()
    {
        Transform tmpTransform = m_Player.GetComponent<Transform>();
        tmpTransform.position = m_SaveDataFile.PlayerInitinalTransform.position;
    }

    private void RecoverInventoryItem()
    {
        RecoverSaveInventory();
        m_SetInitinalInventoryItems.Invoke(m_SaveDataFile.InventoryItem);
    }

    private void RecoverSaveInventory()
    {
        for(int i = 0; i < m_SaveDataPlayerPrefs.InventoryNames.Length; i++)
        {
            List<Item> items = m_SaveDataFile.InventoryItem;
            items[i].Amount = m_SaveDataPlayerPrefs.GetNum(m_SaveDataPlayerPrefs.InventoryNames[i]);
        }
    }

    private void RecoverWorldItem()
    {
        GameObject[] gameObjects = m_SaveDataFile.WorldItems;

        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }

}
