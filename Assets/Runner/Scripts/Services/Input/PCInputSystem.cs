using UnityEngine;
using UnityEngine.InputSystem;

public class PCInputSystem : IInputService
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private float _lastInputTime;
    private float _inputCooldown = 0.1f;

    public PCInputSystem()
    {
        SubscribeToInputEvents();
    }

    private void SubscribeToInputEvents()
    {
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.GameplayInput.PC; 
        _playerInput.Enable();
    }

    private bool CanPerformAction()
    {
        return Time.time >= _lastInputTime + _inputCooldown;
    }

    public bool IsJumpMove()
    {
        bool changePos = false;
        if (CanPerformAction())
        {
            Vector2 move = _moveAction.ReadValue<Vector2>();
            if (move.y > 0.5f)
            {
                _lastInputTime = Time.time;
                changePos = true;
            }
        }
        return changePos;
    }

    public bool IsLeftMove()
    {
        bool changePos = false;
        if (CanPerformAction())
        {
            Vector2 move = _moveAction.ReadValue<Vector2>();
            if (move.x < -0.5f)
            {
                _lastInputTime = Time.time;
                changePos = true;
            }
        }
        return changePos;
    }

    public bool IsRightMove()
    {
        bool changePos = false;
        if (CanPerformAction())
        {
            Vector2 move = _moveAction.ReadValue<Vector2>();
            if (move.x > 0.5f)
            {
                _lastInputTime = Time.time;
                changePos = true;
            }
        }
        return changePos;
    }

    public bool IsSquatMove()
    {
        bool changePos = false;
        if (CanPerformAction())
        {
            Vector2 move = _moveAction.ReadValue<Vector2>();
            if (move.y < -0.5f)
            {
                _lastInputTime = Time.time;
                changePos = true;
            }
        }
        return changePos;
    }
}
