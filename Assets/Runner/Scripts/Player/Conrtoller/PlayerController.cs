using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IInputService _input;
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Rigidbody _rigidbodyPlayer;

    [Inject]
    public void Construct(IInputService input)
    {
        _input = input;
    }

    private void Start()
    {
        _playerView = GetComponent<PlayerView>();
        _rigidbodyPlayer = GetComponent<Rigidbody>();
        _playerModel = new PlayerModel(_rigidbodyPlayer, transform);
    }

    private void Update()
    {
        HandleInput();
        UpdatePlayer();
        UpdateView();
    }


    private void HandleInput()
    {
        if (_input.IsJumpMove())
        {
            Debug.Log("Jump");
            _playerModel.Jump();
            _playerView.PlayJumpAnimation();
        }
        else if(_input.IsSquatMove())
        {
            Debug.Log("Squat");
            _playerModel.Squat();
            _playerView.PlaySquatAnimation();
        }
        else if(_input.IsLeftMove())
        {
            Debug.Log("Left");
            _playerModel.MoveLeft();
            _playerView.PlayMoveLeftAnimation();
        }
        else if(_input.IsRightMove())
        {
            Debug.Log("Right");
            _playerModel.MoveRight();
            _playerView.PlayMoveRightAnimation();

        }
    }

    private void UpdatePlayer()
    {
        _playerModel.UpdateSpeed();
        _playerModel.MoveForward();
    }

    private void UpdateView()
    {
        
    }
}
