using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public bool IsAlive { get; set; } = true;
    public Vector3 Position { get; internal set; }
    public float Speed { get; set; } = 5f;

    private float _maxSpeed = 20f;
    private float _acceleration = 0.5f;
    private Rigidbody _rigidbodyPlayer;
    private Transform _playerTransform;

    private int _currentLane = 0;
    private float _laneDistance = 2.5f;

    public PlayerModel(Rigidbody rigidbodyPlayer, Transform playerTransform)
    {
        _rigidbodyPlayer = rigidbodyPlayer;
        _playerTransform = playerTransform;
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
    //TO DO
    public void Jump()
    {
        throw new NotImplementedException();
    }

    public void Squat()
    {
        throw new NotImplementedException();
    }

    public void MoveLeft()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position + new Vector3(-_laneDistance, 0, 0);
        _rigidbodyPlayer.MovePosition(targetPosition);
    }

    public void MoveRight()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position + new Vector3(_laneDistance, 0, 0);
        _rigidbodyPlayer.MovePosition(targetPosition);
    }
    
    public void MoveCenter()
    {
        Vector3 targetPosition = _rigidbodyPlayer.position;
        targetPosition.x = 0;
        _rigidbodyPlayer.MovePosition(targetPosition);
    }
}
