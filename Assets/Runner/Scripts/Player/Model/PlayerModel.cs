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
        throw new NotImplementedException();
    }

    public void MoveRight()
    {
        throw new NotImplementedException();
    }
}
