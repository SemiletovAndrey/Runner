using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MobileInputSystem : IInputService
{
    private PlayerInput _playerInput;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private bool _isSwipe;
    private float _swipeThreshold;

    public MobileInputSystem(float swipeThreshold)
    {
        _swipeThreshold = swipeThreshold;
        SubscribeToInputEvents();
    }

    private void SubscribeToInputEvents()
    {
        _playerInput = new PlayerInput();
        _playerInput.GameplayInput.Touch.performed += OnTouchStarted;
        _playerInput.GameplayInput.Touch.canceled += OnTouchCanceled;
        _playerInput.Enable();
    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        // Начало касания
        _startTouchPosition = context.ReadValue<Vector2>();
        _isSwipe = true;
        Debug.Log("Touch Started");
    }

    private void OnTouchCanceled(InputAction.CallbackContext context)
    {
        // Окончание касания
        if (_isSwipe)
        {
            _endTouchPosition = context.ReadValue<Vector2>();
            DetectSwipe();
            _isSwipe = false;
        }
        Debug.Log("Touch Canceled");
    }

    private void DetectSwipe()
    {
        Debug.Log("Detected swipe");
        Vector2 swipeVector = _endTouchPosition - _startTouchPosition;
        if (swipeVector.magnitude >= _swipeThreshold)
        {
            Vector2 swipeDirection = swipeVector.normalized;

            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.x > 0)
                {
                    Debug.Log("Right Swipe Detected");
                }
                else
                {
                    Debug.Log("Left Swipe Detected");
                }
            }
            else
            {
                if (swipeDirection.y > 0)
                {
                    Debug.Log("Jump Swipe Detected");
                }
                else
                {
                    Debug.Log("Squat Swipe Detected");
                }
            }
        }
    }

    public bool IsRightMove()
    {
        return _endTouchPosition.x - _startTouchPosition.x > _swipeThreshold;
    }

    public bool IsLeftMove()
    {
        return _startTouchPosition.x - _endTouchPosition.x > _swipeThreshold;
    }

    public bool IsJumpMove()
    {
        return _endTouchPosition.y - _startTouchPosition.y > _swipeThreshold;
    }

    public bool IsSquatMove()
    {
        return _startTouchPosition.y - _endTouchPosition.y > _swipeThreshold;
    }
}
