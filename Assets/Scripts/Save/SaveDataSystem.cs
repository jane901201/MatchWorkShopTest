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
        m_SetInitinalInventoryItems.Invoke(m_SaveDataFile.InventoryItem);
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
