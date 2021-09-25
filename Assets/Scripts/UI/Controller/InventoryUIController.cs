using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private Image m_ItemInfoImage;
    [SerializeField] private Text m_ItemInfoAmount;
    [SerializeField] private Button m_UseBtn;
    [SerializeField] private LongClickButton m_LongClickButton;

    [Header("MatchWorkShopTest_Inventory")]
    [SerializeField] private UnityEvent<List<Item>> m_SetBeUseItems;

    private AssetResources m_AssetResources = new AssetResources();
    private Action<bool> m_SetIsItemUpdate;

    private List<Button> m_ItemBtns = new List<Button>();
    private List<Image> m_ItemImages = new List<Image>();
    private List<Text> m_ItemAmount = new List<Text>();
    private Dictionary<Button, int> m_ItemNumber = new Dictionary<Button, int>();
    private List<Item> m_InventoryItems = new List<Item>();


    private bool m_IsItemUpdate = false;
    private int m_AlreadyHave = 0;
    private int m_CurrectItemNum = -1;

    public bool IsItemUpdate { get => m_IsItemUpdate; set => m_IsItemUpdate = value; }

    private void Start()
    {
        SetCloseUIBtn();
        SetUseBtn();
    }

    private void Update()
    {
        m_Update.Invoke();

        if (IsItemUpdate)
        {
            RefreshView();
        }
    }

    private void OnEnable()
    {
        if (m_Initialize != null)
        {
            m_Initialize.Invoke();
            //m_ItemObjectPool.HowMuchWantToUse(m_InventoryItems.Count);
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
        m_SetBeUseItems.Invoke(m_InventoryItems);
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
        m_ItemInfoImage.sprite = m_ItemImages[i].sprite;
        m_ItemInfoAmount.text = m_InventoryItems[i].Amount.ToString();
        m_CurrectItemNum = i;
    }

    private void RefreshView()
    {
        Debug.Log("Currect inventory items count " + m_InventoryItems.Count);
        m_ItemObjectPool.HowMuchWantToUse(m_InventoryItems.Count);
        SetItemBtn();
        IsItemUpdate = false;
    }

    private void SetCloseUIBtn()
    {
        m_CloseInventoryUIBtn.onClick.AddListener(() => HideMainUI());
    }

    private void SetUseBtn()
    {
        m_UseBtn.onClick.AddListener(() => DecreaseItemAmount(m_CurrectItemNum));
        m_LongClickButton.SetLongClickEvent(UseCurrectItem);
    }

    private void UseCurrectItem()
    {
        Debug.Log("UseCurrectItem");
        DecreaseItemAmount(m_CurrectItemNum);
    }

    private void SetItemBtn()
    {
        int total = m_InventoryItems.Count;
        m_AlreadyHave = total;
        ClearList();

        for (int i = 0; i < total; i++)
        {
            GameObject tmpItemObj = GameObject.Find("Item" + i);
            Button tmpItemBtn = tmpItemObj.GetComponent<Button>();
            //ItemInformationButtonTrigger tmpItemTrigger = tmpItemObj.GetComponent<ItemInformationButtonTrigger>();

            m_ItemBtns.Add(tmpItemBtn);
            m_ItemNumber.Add(tmpItemBtn, i);
            //tmpItemTrigger.Number = i;

            tmpItemObj = SetItemObjChildUI(tmpItemObj, i);
            tmpItemBtn = SetItemBtnState(tmpItemBtn);
        }
    }

    private GameObject SetItemObjChildUI(GameObject item, int i)
    {
        //List:ItemImage, Image, ItemAmount
        Image itemImage = null;
        Text itemAmount = null;

        for (int j = 0; j < item.transform.childCount; j++)
        {
            switch (j)
            {
                case 0:
                    itemImage = item.transform.GetChild(j).gameObject.GetComponent<Image>();
                    break;
                case 1:
                    //itemName = item.transform.GetChild(j).gameObject.GetComponent<Text>();
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
        m_ItemAmount.Add(itemAmount);

        SetItemChildState(i);

        return item;
    }

    private void SetItemChildState(int i)
    {
        m_ItemImages[i].sprite = m_AssetResources.LoadItem(m_InventoryItems[i].ItemImageName);
        m_ItemAmount[i].text = m_InventoryItems[i].Amount.ToString();
    }

    private Button SetItemBtnState(Button item)
    {
        item.onClick.AddListener(delegate ()
        {
            if (m_ItemNumber.ContainsKey(item))
            {
                int choose = m_ItemNumber[item];
                ShowItemInformation(choose);
            }
        });

        return item;
    }

    private void DecreaseItemAmount(int itemNum)
    {
        IsItemUpdate = true;
        m_InventoryItems[itemNum].Amount -= 1;
        if (IsEmpty(m_InventoryItems[itemNum].Amount))
        {
            Item tmpItem = m_InventoryItems[itemNum];
            m_SetBeUseItems.Invoke(m_InventoryItems);
            m_InventoryItems.Remove(tmpItem);
            RefreshView();
        }
        else
        {
            string tmpAmount = m_InventoryItems[itemNum].Amount.ToString();
            m_ItemAmount[itemNum].text = tmpAmount;
            m_ItemInfoAmount.text = tmpAmount;
        }
    }

    private void ClearList()
    {
        m_ItemBtns.Clear();
        m_ItemNumber.Clear();
        m_ItemImages.Clear();
        m_ItemAmount.Clear();
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
