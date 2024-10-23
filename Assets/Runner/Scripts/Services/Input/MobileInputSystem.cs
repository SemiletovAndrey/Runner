using UnityEngine;
using UnityEngine.InputSystem;

public class MobileInputSystem : IInputService
{
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private float _swipeThreshold = 50f;
    private Swipe _currentSwipe = Swipe.None;

    private InputAction _positionAction;
    private InputAction _pressAction;
    private PlayerInput _playerInput;

    private float _lastInputTime;
    private float _inputCooldown = 0.3f;
    public MobileInputSystem()
    {
        _playerInput = new PlayerInput();

        _positionAction = _playerInput.GameplayInput.Position;
        _pressAction = _playerInput.GameplayInput.Press;

        _pressAction.started += OnStartTouch;
        _pressAction.canceled += OnCanceledTouch;

        _playerInput.Enable();
        _pressAction.Enable();
        _playerInput.Enable();
    }

    public bool IsRightMove()
    {

        return IsChangeMoveOnTime(Swipe.Right);
    }

    public bool IsLeftMove()
    {
        return IsChangeMoveOnTime(Swipe.Left);
    }

    public bool IsJumpMove()
    {
        return IsChangeMoveOnTime(Swipe.Up);
    }

    public bool IsSquatMove()
    {
        return IsChangeMoveOnTime(Swipe.Down);
    }

    private void OnStartTouch(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = _positionAction.ReadValue<Vector2>();
        _startTouchPosition = touchPosition;
    }
    private void OnCanceledTouch(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = _positionAction.ReadValue<Vector2>();
        _endTouchPosition = touchPosition;
        _currentSwipe = SwipeDirection();
    }

    private bool IsChangeMoveOnTime(Swipe swipe)
    {
        bool changePos = false;
        if (CanPerformAction() && _currentSwipe == swipe)
        {
            if (SwipeDirection() == swipe)
            {
                _lastInputTime = Time.time;
                changePos = true;
                _currentSwipe = Swipe.None;
            }
        }
        return changePos;
    }

    private bool CanPerformAction()
    {
        return Time.time >= _lastInputTime + _inputCooldown;
    }

    private Swipe SwipeDirection()
    {

        Vector2 swipeVector = _endTouchPosition - _startTouchPosition;

        if (swipeVector.magnitude >= _swipeThreshold)
        {
            if (Mathf.Abs(swipeVector.x) > Mathf.Abs(swipeVector.y))
            {
                return swipeVector.x > 0 ? Swipe.Right : Swipe.Left;
            }
            else
            {
                return swipeVector.y > 0 ? Swipe.Up : Swipe.Down;
            }
        }
        return Swipe.None;
    }

    private enum Swipe
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
}
