using System.Collections;
using UnityEngine;

public class PlayerModel
{
    private float _maxSpeed = 200f;
    private float _acceleration = 0.5f;
    private Rigidbody _rigidbodyPlayer;

    private Collider _centerCollider;
    private Collider _jumpCollider;
    private Collider _slideCollider;

    private IPlayerStateMachine _playerStateMachine;

    private int _currentLane = 0;
    private float _laneDistance = 2.5f;
    private CurrentLine _currentLine;

    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private int _maxScore;

    public Vector3 Position { get; internal set; }
    public float Speed { get; set; } = 5f;
    public int CurrentScore { get; set; }
    public int MaxScore
    {
        get 
        {
            return _maxScore; 
        }
        set
        {
            if (value > _maxScore)
            {
                _maxScore = value;
            }
        }
    }

    public bool CanJump { get; private set; } = true;
    public bool CanSlide { get; private set; } = true;

    public PlayerModel(Rigidbody rigidbodyPlayer, Collider centerCollider, Collider jumpCollider, Collider slideCollider, IPlayerStateMachine playerStateMachine)
    {
        _rigidbodyPlayer = rigidbodyPlayer;
        _centerCollider = centerCollider;
        _jumpCollider = jumpCollider;
        _slideCollider = slideCollider;
        _playerStateMachine = playerStateMachine;

        _startPosition = _rigidbodyPlayer.position;
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        EventBus.OnDeathPlayer += SaveMaxScore;
    }

    public void UpdateSpeed()
    {
        if (Speed < _maxSpeed)
        {
            Speed += _acceleration * Time.deltaTime;
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
        if (_currentLane > -1 && !Physics.Raycast(_rigidbodyPlayer.position, Vector3.left, _laneDistance))
        {
            _currentLane--;
            _currentLine = (CurrentLine)_currentLane;
            UpdateTargetPosition();
            UpdatePlayerState();
        }
    }

    public void MoveRight()
    {
        if (_currentLane < 1 && !Physics.Raycast(_rigidbodyPlayer.position, Vector3.right, _laneDistance))
        {
            _currentLane++;
            _currentLine = (CurrentLine)_currentLane;
            UpdateTargetPosition();
            UpdatePlayerState();
        }
    }

    public void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore", MaxScore);
        Debug.Log($"SaveMaxScore {MaxScore}");
    }

    private void UpdateTargetPosition()
    {
        _targetPosition = new Vector3(_currentLane * _laneDistance, _rigidbodyPlayer.position.y, _rigidbodyPlayer.position.z);
    }

    public void UpdatePosition()
    {
        Vector3 targetHorizontalPosition = new Vector3(_targetPosition.x, _rigidbodyPlayer.position.y, _rigidbodyPlayer.position.z);

        Vector3 horizontalMovement = Vector3.Lerp(_rigidbodyPlayer.position, targetHorizontalPosition, 10 * Time.deltaTime);

        Vector3 forwardMovement = _rigidbodyPlayer.transform.forward * Speed * Time.deltaTime;
        _rigidbodyPlayer.MovePosition(horizontalMovement + forwardMovement);
    }

    public void UpdateScore()
    {
        float distanceTravelled = _rigidbodyPlayer.position.z - _startPosition.z;
        CurrentScore = Mathf.FloorToInt(distanceTravelled);
    }


    private void UpdatePlayerState()
    {
        if (_currentLine == CurrentLine.Center)
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<CenterSideState>());
        else if (_currentLine == CurrentLine.Left)
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<LeftSideState>());
        else if (_currentLine == CurrentLine.Right)
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<RightSideState>());
    }

    public void RestartPlayerPosition()
    {
        Position = new Vector3(0, 0.2f, 0);
        Speed = 5f;
        CurrentScore = 0;
        _rigidbodyPlayer.transform.position = Position;
        _rigidbodyPlayer.isKinematic = true;
        _currentLane = 0;
        _currentLine = CurrentLine.Center;
        _playerStateMachine.PreviousState = _playerStateMachine.GetState<CenterSideState>();
        _targetPosition = _startPosition;
        AllColliderOff();
        _centerCollider.enabled = true;
        CanJump = true;
        CanSlide = true;
    }

    public void DeathPlayer()
    {
        _rigidbodyPlayer.isKinematic = true;
    }

    public void EnterPlayPlayer()
    {
        _rigidbodyPlayer.isKinematic = false;
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
