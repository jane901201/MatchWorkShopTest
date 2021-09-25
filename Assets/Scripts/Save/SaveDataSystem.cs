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
    [SerializeField] private Transform m_StartPoint;
    [SerializeField] private GameObject[] m_WorldItems;

    XMLManager m_XMLManager = new XMLManager();

    public void RecoverData()
    {
        RecoverPlayerPosition();
        RecoverInventoryItem();
        RecoverWorldItem();
    }

    private void RecoverPlayerPosition()
    {
        Transform tmpTransform = m_Player.GetComponent<Transform>();
        tmpTransform.position = m_StartPoint.position;
    }

    private void RecoverInventoryItem()
    {
        m_SetInitinalInventoryItems.Invoke(m_XMLManager.LoadSaveDataFileXML().InventoryItem);
    }

    private void RecoverWorldItem()
    {
        GameObject[] gameObjects = m_WorldItems;

        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }

}
