using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemInformationButtonTrigger : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private UnityEvent<int> m_Event;

    private int m_Number = 0;

    public int Number { get => m_Number; set => m_Number = value; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Test");
        if (m_Event != null)
        {
            m_Event.Invoke(Number);
        }
    }
}
