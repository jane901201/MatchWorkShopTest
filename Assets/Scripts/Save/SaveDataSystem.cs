using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private List<Item> m_InventoryItem;

    SaveDataFile m_SaveDataFile = new SaveDataFile();


    private void Awake()
    {
        m_SaveDataFile.Initinal();
    }

    void Start()
    {
        
    }

    public void RecoverData()
    {

    }
}
