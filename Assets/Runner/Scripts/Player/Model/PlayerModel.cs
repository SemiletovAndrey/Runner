using System.Collections;
using UnityEngine;

public class PlayerModel
{
    public bool IsAlive { get; set; } = true;
    public Vector3 Position { get; internal set; }
    public float Speed { get; set; } = 5f;
    public int Score { get; set; }

    public bool CanJump { get; private set; } = true;
    public bool CanSlide { get; private set; } = true;

    private float _maxSpeed = 200f;
    private float _acceleration = 0.05f;
    private Rigidbody _rigidbodyPlayer;
    private Transform _playerTransform;

    private Collider _centerCollider;
    private Collider _jumpCollider;
    private Collider _slideCollider;

    private IPlayerStateMachine _playerStateMachine;

    private int _currentLane = 0;
    private float _laneDistance = 2.5f;
    private CurrentLine _currentLine;

    public PlayerModel(Rigidbody rigidbodyPlayer, Transform playerTransform, Collider centerCollider, Collider jumpCollider, Collider slideCollider, IPlayerStateMachine playerStateMachine)
    {
        _rigidbodyPlayer = rigidbodyPlayer;
        _playerTransform = playerTransform;
        _centerCollider = centerCollider;
        _jumpCollider = jumpCollider;
        _slideCollider = slideCollider;
        _playerStateMachine = playerStateMachine;
    }

    public void UpdateSpeed()
    {
        if (Speed < _maxSpeed)
        {
            Speed += _acceleration * Time.deltaTime;
        }
    }

    public void MoveForward()
    {
        Vector3 moveDirection = _playerTransform.forward * Speed * Time.deltaTime;
        RaycastHit hit;

        if (!Physics.Raycast(_rigidbodyPlayer.position, moveDirection, out hit, moveDirection.magnitude))
        {
            _rigidbodyPlayer.MovePosition(_rigidbodyPlayer.position + moveDirection);
        }
    }

    public void StartJump()
    {
        AllColliderOff();
        JumpColliderOn();
        _rigidbodyPlayer.useGravity = false;
        CanJump = false;
    }

    public void EndJump()
    {
        JumpColliderOff();
        _rigidbodyPlayer.useGravity = true;
        _playerStateMachine.RevertToPreviousState();
        CanJump = true;
        CanSlide = true;
    }

    public void StartSlide()
    {
        AllColliderOff();
        SlideColliderOn();
        _rigidbodyPlayer.useGravity = false;
        CanSlide = false;
    }
    public void EndSlide()
    {
        SlideColliderOff();
        _rigidbodyPlayer.useGravity = true;
        _playerStateMachine.RevertToPreviousState();
        CanSlide = true;
        CanJump = true;
    }

    public void MoveLeft()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position + new Vector3(-_laneDistance, 0, 0);
        if (CanJump)
        {
            if (!(_currentLine == CurrentLine.Left) && !Physics.Raycast(_rigidbodyPlayer.position, Vector3.left, _laneDistance))
            {
                _rigidbodyPlayer.MovePosition(targetPosition);
                _currentLane--;
                _currentLine = (CurrentLine)_currentLane;

                if (_currentLine == CurrentLine.Center)
                    _playerStateMachine.ChangeState(_playerStateMachine.GetState<CenterSideState>());
                if (_currentLine == CurrentLine.Left)
                    _playerStateMachine.ChangeState(_playerStateMachine.GetState<LeftSideState>());
            }
        }
    }

    public void MoveRight()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position + new Vector3(_laneDistance, 0, 0);
        if (CanJump)
        {
            if (!(_currentLine == CurrentLine.Right) && !Physics.Raycast(_rigidbodyPlayer.position, Vector3.right, _laneDistance))
            {
                _rigidbodyPlayer.MovePosition(targetPosition);
                _currentLane++;
                _currentLine = (CurrentLine)_currentLane;

                if (_currentLine == CurrentLine.Center)
                    _playerStateMachine.ChangeState(_playerStateMachine.GetState<CenterSideState>());
                if (_currentLine == CurrentLine.Right)
                    _playerStateMachine.ChangeState(_playerStateMachine.GetState<RightSideState>());
            }
        }
    }

    public void AlignmentPlayerPosition()
    {
        switch(_currentLine)
        {
            case CurrentLine.Left:
                Vector3 alignmentPosLeft = new Vector3(-_laneDistance, _rigidbodyPlayer.position.y, _rigidbodyPlayer.position.z);
                _rigidbodyPlayer.MovePosition(alignmentPosLeft);
                break;
            case CurrentLine.Center:
                Vector3 alignmentPosCenter = new Vector3(0, _rigidbodyPlayer.position.y, _rigidbodyPlayer.position.z);
                _rigidbodyPlayer.MovePosition(alignmentPosCenter);
                break;
            case CurrentLine.Right:
                Vector3 alignmentPosRight = new Vector3(_laneDistance, _rigidbodyPlayer.position.y, _rigidbodyPlayer.position.z);
                _rigidbodyPlayer.MovePosition(alignmentPosRight);
                break;
        }
    }


    private void JumpColliderOn()
    {
        _jumpCollider.enabled = true;
        _centerCollider.enabled = false;
    }

    private void JumpColliderOff()
    {
        _jumpCollider.enabled = false;
        _centerCollider.enabled = true;
    }

    private void SlideColliderOn()
    {
        _slideCollider.enabled = true;
        _centerCollider.enabled = false;
    }

    private void SlideColliderOff()
    {
        _slideCollider.enabled = false;
        _centerCollider.enabled = true;
    }

    private void AllColliderOff()
    {
        _slideCollider.enabled = false;
        _centerCollider.enabled = false;
        _jumpCollider.enabled = false;
    }

    public enum CurrentLine
    {
        Left = -1,
        Center = 0,
        Right = 1
    }
}
