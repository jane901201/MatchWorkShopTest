using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    //TODO:[SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    [SerializeField] private float m_PlayerSpeed = 4f;

    private PlayerInput m_PlayerInput;
    private Vector2 m_PlayerMovement;

    private void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.position += m_PlayerMovement * m_PlayerSpeed * Time.deltaTime;
        //TODO:Move to PlayerMovement2D?
    }

    private void OnMove(InputValue inputValue)
    {
        m_PlayerMovement = inputValue.Get<Vector2>();
    }
}
