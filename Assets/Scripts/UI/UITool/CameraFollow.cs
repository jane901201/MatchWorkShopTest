using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform m_PlayerTransform;

    private void LateUpdate()
    {
        transform.position = new Vector3(m_PlayerTransform.position.x, m_PlayerTransform.position.y, -10);
    }

}
