using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent<List<Item>> m_SetGettingItem;
    [SerializeField] private UnityEvent m_ShowWantToRestartInfo;

    private GameObject m_CurrectTouchObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        m_CurrectTouchObj = collision.gameObject;
        WhichTag(tag);
    }

    private void WhichTag(string tag)
    {
        //Debug.Log("This tag is " + tag);
        switch (tag)
        {
            case "Item":
                Item();
            break;
            case "End":
                End();
                break;
            default:
                break;
        }
    }

    private void Item()
    {
        ItemSetting itemSetting = m_CurrectTouchObj.GetComponent<ItemSetting>();
        List<Item> items = itemSetting.GetItems();
        m_SetGettingItem.Invoke(items);
        m_CurrectTouchObj.SetActive(false);
    }

    private void End()
    {
        Debug.Log("End Function");
        m_ShowWantToRestartInfo.Invoke();
    }
}
