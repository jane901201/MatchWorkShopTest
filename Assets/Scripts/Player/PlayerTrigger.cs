using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent<List<Item>> m_SetInventoryItem;
    private GameObject m_CurrectTouchObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        m_CurrectTouchObj = collision.gameObject;
        WhichTag(tag);
    }

    private void WhichTag(string tag)
    {
        switch(tag)
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
    }

    private void End()
    {

    }
}
