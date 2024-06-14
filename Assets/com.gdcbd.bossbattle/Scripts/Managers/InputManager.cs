using System;
using BossBattle.Utility;
using UnityEngine;
using UnityEngine.InputSystem;  

public class InputManager : PersistentMonoSingleton<InputManager>
{
     [SerializeField] private PlayerInput playerInput;
     
 
    private Vector2 _moveInput;
    
    public delegate void OnActionEvent();
    
    public OnActionEvent JumpPressedAction;
    public OnActionEvent JumpReleaseAction;
    
    public OnActionEvent SprintPressedAction;
    public OnActionEvent SprintReleasedAction;
   
    public OnActionEvent FirePressedAction;
    public OnActionEvent FireReleasedAction;
    protected override void Initialize()
    {
    }
    public void GetMovementInput(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public Vector2 Move()
    {
        return _moveInput;
    }
     public void OnJumpAction(InputAction.CallbackContext context)
        {
            if (context.performed)
                JumpPressedAction?.Invoke();
            else if (context.canceled)
                JumpReleaseAction?.Invoke();
        }
    public void OnSprintAction(InputAction.CallbackContext context)
    {
        if (context.performed)
            SprintPressedAction?.Invoke();
        else if (context.canceled)
            SprintReleasedAction?.Invoke();
    }
   
    public void OnFireAction(InputAction.CallbackContext context)
    {
        if (context.performed)
            FirePressedAction?.Invoke();
        else if (context.canceled)
            FireReleasedAction?.Invoke();
    }

    
}