using UnityEngine;

public class PlayerModel
{
    public bool IsAlive { get; set; } = true;
    public Vector3 Position { get; internal set; }
    public float Speed { get; set; } = 5f;
    public int Score {  get; set; }

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
        _rigidbodyPlayer.MovePosition(_rigidbodyPlayer.position + moveDirection);
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
        _rigidbodyPlayer.MovePosition(targetPosition);
        _currentLane--;
    }

    public void MoveRight()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position + new Vector3(_laneDistance, 0, 0);
        _rigidbodyPlayer.MovePosition(targetPosition);
        _currentLane++;
    }
    
    public void MoveCenter()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position;
        targetPosition.x = 0;
        _rigidbodyPlayer.MovePosition(targetPosition);
        _currentLane = 0;
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
}
