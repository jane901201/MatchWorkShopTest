using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private PlayerMovement2D m_PlayerMovement2D;

    [SerializeField] private float m_PlayerSpeed = 40f;

    private PlayerInput m_PlayerInput;
    private Vector2 m_PlayerMovement;
    private float m_PlayerMovementX = 0f;
    private bool m_Jump = false;

    private void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Vector2 move = m_PlayerMovement * m_PlayerSpeed * Time.deltaTime;
        m_PlayerMovement2D.Move(move, m_Jump);
        m_Animator.SetFloat("Speed", Mathf.Abs(m_PlayerMovementX));
        m_Jump = false;
    }

    private void OnMove(InputValue inputValue)
    {
        m_PlayerMovement = inputValue.Get<Vector2>();
        m_PlayerMovementX = m_PlayerMovement.x;
    }

    private void OnJump(InputValue inputValue)
    {
        Debug.Log("Jump");
        m_Jump = true;
        //TODO:Jump
    }

    public void SetPlayerMap()
    {
        m_PlayerInput.SwitchCurrentActionMap("Player");
    }

    public void SetMatchWorkShopTestUIMap()
    {
        m_PlayerInput.SwitchCurrentActionMap("MatchWorkShopTestUI");
    }
}
