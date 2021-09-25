using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根據Item大小自動調整物件顯示數量的ObjectPool
/// </summary>
public class ItemObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject m_Item;

    private List<GameObject> m_ItemObjs = new List<GameObject>();

    private int m_ItemsCount = 0;
    private int m_AlreadyCreate = 0;
    private int m_Recycle = 0;

    public void HowMuchWantToUse(int num)
    {
        m_ItemsCount = num;

        if (m_ItemsCount > 0)
        {
            if (IsSameAsBefore())
            {
                Debug.Log("IsSameAsBefore");
            }
            else if (IsSmallThanNeed())
            {
                Debug.Log("IsSmallThanNeed");

                if(IsAlreadyCreate())
                {
                    ReUseObjs();
                }
                InstantiateItem();
            }
            else if (IsNeedToHide())
            {
                Debug.Log("IsNeedToHide");
                RecycleObjs(m_AlreadyCreate - m_ItemsCount);
            }
            else if (IsAlreadyCreate())
            {
                Debug.Log("IsAlreadyCreate");
                ReUseObjs();
            }
            else
            {
                Debug.LogError("Something wrong happen in HowMuchWantToUse function.");
            }
        }
    }

    private void RecycleObjs(int num)
    {
        if (m_ItemObjs.Count > 0)
        {
            int max = m_ItemObjs.Count;
            m_Recycle = num;
            int needToRecycle = max - m_Recycle;

            for (int i = (max - 1); i >= needToRecycle; i--)
            {
                m_ItemObjs[i].SetActive(false);
            }
        }
    }


    private void InstantiateItem()
    {
        for (int i = m_AlreadyCreate; i < m_ItemsCount; i++)
        {
            GameObject obj = Instantiate(m_Item, transform) as GameObject;
            obj.name = "Item" + i;
            m_ItemObjs.Add(obj);
            obj.SetActive(true);
        }

        m_AlreadyCreate = m_ItemObjs.Count;
    }

    private void ItemObjIsActive(bool active, int objNum)
    {
        m_ItemObjs[objNum].SetActive(active);
    }

    private void ReUseObjs()
    {
        if (m_Recycle > 0)
        {
            int currectMax = m_ItemObjs.Count;
            int needToReuse = m_ItemsCount;
            int maxReuse = Mathf.Clamp(needToReuse, 0, currectMax);
            int beginReuse = m_AlreadyCreate - m_Recycle;
            
            Debug.Log("Begin reuse " + beginReuse);
            for (int i = beginReuse; i < maxReuse; i++)
            {
                if(m_ItemObjs[i] != null && m_Recycle > 0)
                {
                    m_ItemObjs[i].SetActive(true);
                    m_Recycle--;
                    Debug.Log("Recycle " + m_Recycle);
                }
            }
        }
        else
        {
            Debug.LogError("Someone try to use this function when item is emptyed.");
        }

    }

    private bool IsSameAsBefore()
    {
        int needItems = m_ItemsCount;
        if (m_AlreadyCreate == m_ItemsCount && m_Recycle == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsSmallThanNeed()
    {
        int needItems = m_ItemsCount;
        if (m_AlreadyCreate < needItems)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsAlreadyCreate()
    {
        int haveShowItem = m_ItemObjs.Count - m_Recycle;
        if (m_AlreadyCreate > haveShowItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsNeedToHide()
    {
        Debug.Log("m_AlreadyCreate " + m_AlreadyCreate);
        Debug.Log("m_ItemsCount " + m_ItemsCount);

        if (m_AlreadyCreate - m_Recycle > m_ItemsCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
