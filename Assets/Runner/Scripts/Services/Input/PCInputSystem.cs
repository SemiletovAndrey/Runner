using UnityEngine;
using UnityEngine.InputSystem;

public class PCInputSystem : IInputService
{
    private float _vectorDifference = 0.5f;
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private float _lastInputTime;
    private float _inputCooldown = 0.1f;
    private bool _isActionProcessed = false;

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
            if (move.y > _vectorDifference && !_isActionProcessed)
            {
                _lastInputTime = Time.time;
                changePos = true;
                _isActionProcessed = true;
            }
            else if (_isActionProcessed && move.y <= _vectorDifference)
            {
                _isActionProcessed = false;
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
            if (move.x < -_vectorDifference && !_isActionProcessed)
            {
                _lastInputTime = Time.time;
                changePos = true;
                _isActionProcessed = true;
            }
            else if (move.x >= -_vectorDifference)
            {
                _isActionProcessed = false;
            }
        }
        return changePos;
    }

    public bool IsRightMove()
    {
        bool changePos = false;
        Vector2 move = _moveAction.ReadValue<Vector2>();

        if (CanPerformAction() && move.x > _vectorDifference && !_isActionProcessed)
        {
            _lastInputTime = Time.time;
            _isActionProcessed = true;
            changePos = true;
        }
        else if (move.x <= _vectorDifference)
        {
            _isActionProcessed = false;
        }
        return changePos;
    }

    public bool IsSquatMove()
    {
        bool changePos = false;
        Vector2 move = _moveAction.ReadValue<Vector2>();

        if (CanPerformAction() && move.y < -_vectorDifference && !_isActionProcessed)
        {
            _lastInputTime = Time.time;
            _isActionProcessed = true;
            changePos = true;
        }
        else if (move.y >= -_vectorDifference)
        {
            _isActionProcessed = false;
        }
        return changePos;
    }
}
