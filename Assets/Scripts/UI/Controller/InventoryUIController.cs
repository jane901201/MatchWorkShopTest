using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : IUserInterface
{
    [Header("InventoryUI")]
    [SerializeField] private Button m_CloseInventoryUIBtn;
    [SerializeField] private GameObject m_ItemInformationPanel;
    [SerializeField] private Text m_ItemNameText;
    [SerializeField] private Text m_ItemInformationText;
    [SerializeField] private Image m_ItemImageText;
    [SerializeField] private ItemObjectPool m_ItemObjectPool;

    private AssetResources m_AssetResources;
    private Action<bool> m_SetIsItemUpdate;

    private List<Button> m_ItemBtns = new List<Button>();
    private List<Image> m_ItemImages = new List<Image>();
    private List<Text> m_ItemNames = new List<Text>();
    private List<Text> m_ItemAmount = new List<Text>();
    private Dictionary<Button, int> m_ItemNumber = new Dictionary<Button, int>();
    private List<Item> m_InventoryItems = new List<Item>();


    private bool m_IsItemUpdate = false;
    private int m_AlreadyHave = 0;

    public bool IsItemUpdate { get => m_IsItemUpdate; set => m_IsItemUpdate = value; }

    private void Start()
    {
        m_AssetResources = new AssetResources();
    }


    private void OnEnable()
    {
        if (m_Initialize != null)
        {
            m_Initialize.Invoke();
            m_ItemObjectPool.HowMuchWantToUse(m_InventoryItems.Count);
            //Debug.Log("Button will Show " + (m_InventoryItems.Count));
        }
        if (IsItemUpdate)
        {
            RefreshView();

        }
    }

    private void OnDisable()
    {
        //TODO:Send items information to InventoryManager;
        m_SetIsItemUpdate(IsItemUpdate);
    }

    public override void ShowMainUI()
    {
        base.ShowMainUI();
    }

    public override void HideMainUI()
    {
        base.HideMainUI();
    }

    public void SetInventoryItems(List<Item> items)
    {
        m_InventoryItems = items;
        Debug.Log("InventoryUIController get the items " + m_InventoryItems.ToString());
    }

    public void SetIsItemUpdate(Action<bool> action)
    {
        m_SetIsItemUpdate = action;
    }

    public void ShowItemInformation(int i)
    {
        m_ItemNameText.text = m_InventoryItems[i].ItemName;
        m_ItemInformationText.text = m_InventoryItems[i].Information;
    }

    private void RefreshView()
    {

        SetItemBtn();
        IsItemUpdate = false;
    }

    private void SetItemBtn()
    {
        int total = m_InventoryItems.Count;
        m_AlreadyHave = total;
        m_ItemBtns.Clear();
        m_ItemNumber.Clear();
        m_ItemImages.Clear();
        m_ItemNames.Clear();
        m_ItemAmount.Clear();


        for (int i = 0; i < total; i++)
        {
            GameObject tmpItemObj = GameObject.Find("Item" + i);
            //Debug.Log(tmpItemObj.GetType().ToString());
            Button tmpItemBtn = tmpItemObj.GetComponent<Button>();
            //Debug.Log("Button " + tmpItemBtn);
            //ItemTrigger tmpItemTrigger = tmpItemObj.GetComponent<ItemTrigger>();

            m_ItemBtns.Add(tmpItemBtn);
            m_ItemNumber.Add(tmpItemBtn, i);
            //tmpItemTrigger.Number = i;

            tmpItemObj = SetItemObjChildUI(tmpItemObj, i);
            tmpItemBtn = SetItemBtnState(tmpItemBtn);
        }
    }

    private GameObject SetItemObjChildUI(GameObject item, int i)
    {
        //List:ItemImage, ItemName, ItemPrice
        Image itemImage = null;
        Text itemName = null;
        Text itemAmount = null;

        for (int j = 0; j < item.transform.childCount; j++)
        {
            switch (j)
            {
                case 0:
                    itemImage = item.transform.GetChild(j).gameObject.GetComponent<Image>();
                    break;
                case 1:
                    itemName = item.transform.GetChild(j).gameObject.GetComponent<Text>();
                    break;
                case 2:
                    itemAmount = item.transform.GetChild(j).gameObject.GetComponent<Text>();
                    break;
                default:
                    Debug.Log("Something wrong happen in ItemUI Child");
                    break;
            }
        }

        m_ItemImages.Add(itemImage);
        m_ItemNames.Add(itemName);
        m_ItemAmount.Add(itemAmount);

        SetItemChildState(i);

        return item;
    }

    private void SetItemChildState(int i)
    {
        //TODO:m_ItemImages[i].sprite = m_Resources.LoadSprite(m_InventoryItems[i].ItemImageName);
        m_ItemNames[i].text = m_InventoryItems[i].ItemName;
        m_ItemAmount[i].text = m_InventoryItems[i].Amount.ToString();
    }

    private void SetItemChildState()
    {
        for (int i = 0; i < m_InventoryItems.Count; i++)
        {
            //TODO:m_ItemImages[i].sprite = m_Resources.LoadSprite(m_InventoryItems[i].ItemImageName);
            m_ItemNames[i].text = m_InventoryItems[i].ItemName;
            m_ItemAmount[i].text = m_InventoryItems[i].Amount.ToString();
        }
    }



    private Button SetItemBtnState(Button item)
    {
        item.onClick.AddListener(delegate ()
        {
            if (m_ItemNumber.ContainsKey(item))
            {
                int choose = m_ItemNumber[item];
                //TODO:ItemUse
            }
        });

        return item;
    }

    private void UseItem() //TODO:Will be move to other place
    {
        IsItemUpdate = true;
        m_SetIsItemUpdate.Invoke(IsItemUpdate);
        //TODO:Call DataCheckInfomation
    }

    private void DecreaseItemAmount(int i)
    {
        IsItemUpdate = true;
        m_InventoryItems[i].Amount -= 1;
        if (IsEmpty(m_InventoryItems[i].Amount))
        {
            m_ItemObjectPool.RecycleObjs(1);
            //TODO:SetChildState
        }
        else
        {
            m_ItemAmount[i].text = m_InventoryItems[i].Amount.ToString();
        }
    }

    private bool IsEmpty(int amount)
    {
        if (amount <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
