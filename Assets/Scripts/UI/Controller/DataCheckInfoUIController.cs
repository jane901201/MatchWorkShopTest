using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataCheckInfoUIController : IUserInterface
{
    [Header("DataCheckInfoUI")]
    [SerializeField] private Text m_InformationText;
    [SerializeField] private Button m_YesBtn;
    [SerializeField] private Button m_NoBtn;

    [Header("MatchWorkShopTest")]
    [SerializeField] private UnityEvent m_RestartGame;
    [SerializeField] private UnityEvent m_SetPlayerMap;

    public override void ShowMainUI()
    {
        base.ShowMainUI();
    }

    public override void HideMainUI()
    {
        base.HideMainUI();
    }

    public void ShowWantToRestartInfo()
    {
        m_InformationText.text = "重新開始遊戲?";
        m_YesBtn.onClick.AddListener(() => m_RestartGame.Invoke());
        m_NoBtn.onClick.AddListener(delegate() {
            HideMainUI();
            m_SetPlayerMap.Invoke();
        });
    }

}
