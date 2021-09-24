using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataFile
{
    private Dictionary<string, string> m_RecoverName;

    public void Initinal()
    {
        PlayerPrefs.SetInt("BlackChocolate", 2);
        InitinalRecoverName();
    }

    public void Release()
    {
        PlayerPrefs.DeleteAll();
    }

    private void InitinalRecoverName()
    {
        m_RecoverName = new Dictionary<string, string>();
        m_RecoverName.Add("黑巧克力", "BlackChocolate");

    }
}