using UnityEngine;
using UnityEngine.InputSystem;

public class PCInputSystem : IInputService
{
    private float _vectorDifference = 0.5f;
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private float _lastInputTime;
    private float _inputCooldown = 0.3f;

    public PCInputSystem()
    {
        Debug.Log("Construct");
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
            if (move.y > _vectorDifference)
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
            if (move.x < -_vectorDifference)
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
            if (move.x > _vectorDifference)
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
            if (move.y < -_vectorDifference)
            {
                _lastInputTime = Time.time;
                changePos = true;
            }
        }
        return changePos;
    }
}
