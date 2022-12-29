using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerControls _inputActions;
    private bool _canUseInputs = true;
    
    public Action<Vector2> OnMovement;
    public Action OnMovementCancelled;
    public Action OnInteraction;
    [field: SerializeField] public Vector2 MoveDir { get; private set; }
    [field: SerializeField] public float MoveAmount { get; private set; }
    
    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.Player.Movement.performed += Movement;
            _inputActions.Player.Movement.canceled += MovementCancelled;
            _inputActions.Player.Interact.performed += Interact;
        }
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Movement.performed -= Movement;
        _inputActions.Player.Interact.performed -= Interact;
        _inputActions.Disable();
    }

    private void Update()
    {
        MovementInput();
    }

    private void Movement(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        MoveDir = context.ReadValue<Vector2>();
    }

    private void MovementCancelled(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        MoveDir = Vector2.zero;
        OnMovementCancelled?.Invoke();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        OnInteraction?.Invoke();
    }

    private void MovementInput()
    {
        MoveAmount = Mathf.Clamp01(Mathf.Abs(MoveDir.x) + Mathf.Abs(MoveDir.y));
        if (MoveAmount <= 0) return;
        OnMovement?.Invoke(MoveDir);
    }

    public void EnableInputs(bool canUseInputs) => _canUseInputs = canUseInputs;
}
