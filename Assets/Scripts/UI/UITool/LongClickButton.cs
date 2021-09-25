using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool m_PointerDown = false;
    private float m_PointDownTimer = 0f;

    [SerializeField] private float m_RequiredHoldTime;
    private Action m_LongClickEvent;


    private void Update()
    {
        //Debug.Log(m_PointDownTimer);
        if(m_PointerDown)
        {
            m_PointDownTimer += Time.deltaTime;
            if(m_PointDownTimer >= m_RequiredHoldTime)
            {
                Reset();
                LongClickEvent();
            }
        }
    }

    public void SetLongClickEvent(Action unityEvent)
    {
        m_LongClickEvent = unityEvent;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_PointerDown = true;
        Debug.Log("PointerDown " + m_PointerDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        m_PointerDown = false;
        Debug.Log("PointerDown " + m_PointerDown);
    }

    private void Reset()
    {
        //m_PointerDown = false;
        Debug.Log("PointerDown " + m_PointerDown);
        m_PointDownTimer = 0f;
    }

    private void LongClickEvent()
    {
        if(m_LongClickEvent != null)
        {
            m_LongClickEvent.Invoke();
        }
    }

}
