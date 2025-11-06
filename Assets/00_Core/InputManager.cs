using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private InputSystem_Actions inputActions;

    public Vector2 MoveInput;

    protected override void Awake()
    {
        base.Awake();

        inputActions = new();
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}
