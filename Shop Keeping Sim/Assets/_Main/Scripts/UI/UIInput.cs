using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput : MonoBehaviour
{
    private PlayerControls _inputActions;
    private bool _canUseInputs = true;
    
    public Action OnPauseInput;
    public Action OnInventoryInput;
    
    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.UI.Pause.performed += Pause;
            _inputActions.UI.Inventory.performed += Inventory;
        }
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Movement.performed -= Pause;
        _inputActions.Player.Interact.performed -= Inventory;
        _inputActions.Disable();
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        OnPauseInput?.Invoke();
    }
    
    private void Inventory(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        OnInventoryInput?.Invoke();
    }

    public void EnableInputs(bool canUseInputs) => _canUseInputs = canUseInputs;
}
