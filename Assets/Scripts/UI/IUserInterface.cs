using UnityEngine;
using UnityEngine.Events;

public abstract class IUserInterface : MonoBehaviour
{
    [SerializeField] protected UnityEvent m_Initialize;
    [SerializeField] protected UnityEvent m_Update;
    [SerializeField] protected UnityEvent m_Release;

    public virtual void ShowMainUI()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideMainUI()
    {
        gameObject.SetActive(false);
    }
}
