using UnityEngine;

[System.Serializable]
public class Item
{
    private int m_MaxAnount = 999999;
    private int m_MinAmount = 0;

    [SerializeField] private string m_Name;
    [SerializeField] private string m_Image;
    [TextArea(3, 5)] [SerializeField] private string m_Information = "Information";
    [Range(0, 999999)] [SerializeField] private int m_Amount = 1;


    public string ItemName { get => m_Name; set => m_Name = value; }
    public string ItemImageName { get => m_Image; set => m_Image = value; }
    public int Amount { get => m_Amount; set => m_Amount = Mathf.Clamp(value, MinAmount, MaxAnount); }
    public string Information { get => m_Information; set => m_Information = value; }
    public int MaxAnount { get => m_MaxAnount; set => m_MaxAnount = value; }
    public int MinAmount { get => m_MinAmount; set => m_MinAmount = value; }
}
