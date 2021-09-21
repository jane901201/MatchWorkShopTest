using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 先寫個中文備註
/// 簡單來說是個根據Item大小自動調整物件顯示數量的ObjectPool
/// </summary>
public class ItemObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject m_Item;

    private List<GameObject> m_ItemObjs = new List<GameObject>();

    private int m_ItemsCount = 0;
    private int m_AlreadyCreate = 0;
    private int m_Recycle = 0;

    private void OnEnable() //TODO:Test
    {
        //HowMuchWantToUse(1); // 1 Button
        //HowMuchWantToUse(2); // 2 Button
        //HowMuchWantToUse(2); // 2 Button
        //HowMuchWantToUse(4); // 4 Button
        //HowMuchWantToUse(3); // 3 Button
    }



    public void HowMuchWantToUse(int num) //TODO:private
    {
        m_ItemsCount = num;

        if (m_ItemsCount > 0)
        {
            if (IsSameAsBefore())
            {

            }
            else if (IsSmallThanNeed())
            {
                InstantiateItem();
            }
            else if (IsAlreadyCreate())
            {
                ReUseObjs();
            }
            else if (IsNeedToHide())
            {
                RecycleObjs(m_AlreadyCreate - m_ItemsCount);
            }
            else
            {
                Debug.LogError("Something wrong happen in HowMuchWantToUse function.");
            }
        }
    }

    public void RecycleObjs(int num)
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
        //Debug.Log("Already create " + m_AlreadyCreate);
        //Debug.Log("Will create " + m_ItemsCount);
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
            int max = m_ItemObjs.Count;
            int needToReuse = m_ItemsCount;
            int beginReuse = m_AlreadyCreate - m_Recycle;
            for (int i = beginReuse; i < max - (m_Recycle - needToReuse); i++)
            {
                m_ItemObjs[i].SetActive(true);
            }

            m_Recycle -= needToReuse;

        }
        else
        {
            Debug.LogError("Someone try to use this function when item is emptyed.");
        }

    }


    //private void DestroyObjs()
    //{
    //    int max = m_ItemObjs.Count;

    //    for(int i = max; i > max - m_WillBeDestoryCount; i--)
    //    {
    //        GameObject tmp = m_ItemObjs[i];
    //        m_ItemObjs.Remove(tmp);
    //        Destroy(tmp);
    //    }
    //}

    private bool IsSameAsBefore()
    {
        int needItems = m_ItemsCount;
        if (m_AlreadyCreate == m_ItemsCount)
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
        if (m_AlreadyCreate > m_ItemsCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
