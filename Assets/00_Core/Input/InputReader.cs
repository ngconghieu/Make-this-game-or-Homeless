using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action DashEvent;
    public event Action AttackEvent;

    private void Awake()
    {
        //DontDestroyOnLoad(this); 
        inputActions = new();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        // Move
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

        // Jump
        inputActions.Player.Jump.started += OnJump;
        // Dash
        inputActions.Player.Dash.started += OnDash;
        // Attack
        inputActions.Player.Attack.started += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        AttackEvent?.Invoke();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        DashEvent?.Invoke();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        JumpEvent?.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }


    private void OnDisable()
    {
        inputActions.Player.Disable();
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Jump.started -= OnJump;
        inputActions.Player.Dash.started -= OnDash;
        inputActions.Player.Attack.started -= OnAttack;
    }
}
