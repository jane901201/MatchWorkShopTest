using System.Collections;
using UnityEngine;

public partial class MatchWorkShopTest
{
    public void HideDataCheckInfoUI()
    {
        m_DataCheckInfoUIController.HideMainUI();
    }

    public void ShowWantToRestartInfo()
    {
        m_DataCheckInfoUIController.ShowMainUI();
        m_DataCheckInfoUIController.ShowWantToRestartInfo();
        SetMatchWorkShopTestUIMap();
    }
}
