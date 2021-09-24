using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    [SerializeField] private float m_PlayerSpeed = 4f;

    private PlayerInput m_PlayerInput;
    private Vector2 m_PlayerMovement;
    private float m_PlayerMovementX;

    private void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
        Debug.Log("PlayerInput " + m_PlayerInput.currentActionMap);
    }

    private void FixedUpdate()
    {
        m_Rigidbody2D.position += m_PlayerMovement * m_PlayerSpeed * Time.deltaTime;
        m_Animator.SetFloat("Speed", Mathf.Abs(m_PlayerSpeed * m_PlayerMovementX));
    }

    private void OnMove(InputValue inputValue)
    {
        m_PlayerMovement = inputValue.Get<Vector2>();
        m_PlayerMovementX = m_PlayerMovement.x;
    }

    private void OnJump(InputValue inputValue)
    {
        Debug.Log("Jump");
        //TODO:Jump
    }

    public void SetPlayerMap()
    {
        m_PlayerInput.SwitchCurrentActionMap("Player");
    }

    public void SetMatchWorkShopTestUIMap()
    {
        //Debug.Log(m_PlayerInput.currentActionMap);
        m_PlayerInput.SwitchCurrentActionMap("MatchWorkShopTestUI");
    }
}
