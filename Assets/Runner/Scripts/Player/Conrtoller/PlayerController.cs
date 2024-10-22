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
    private IPlayerStateMachine _playerStateMachine;

    private Dictionary<Type, IPlayerState> _playerStates;

    [Inject]
    public void Construct(IInputService input)
    {
        _input = input;
        Debug.Log($"IInput{_input}");
    }

    private void Start()
    {
        _playerView = GetComponent<PlayerView>();
        _rigidbodyPlayer = GetComponent<Rigidbody>();
        _playerModel = new PlayerModel(_rigidbodyPlayer, transform);

        _playerStateMachine = new PlayerStateMachine();
        _playerStates = new Dictionary<Type, IPlayerState>();
        _playerStates[typeof(CenterSideState)] = new CenterSideState(_playerModel, _playerView);
        _playerStates[typeof(RightSideState)] = new RightSideState(_playerModel, _playerView);
        _playerStates[typeof(LeftSideState)] = new LeftSideState(_playerModel, _playerView);
        //_playerStates[typeof(CenterSideState)] = new CenterSideState(_playerModel, _playerView);

        _playerStateMachine.Initialize(_playerStates[typeof(CenterSideState)]);
    }

    private void Update()
    {
        HandleInput();
        UpdatePlayer();
        UpdateView();
    }


    private void HandleInput()
    {
        if (_input.IsRightMove())
        {
            if (_playerStateMachine.CurrentState == _playerStates[typeof(CenterSideState)])
            {
                _playerStateMachine.ChangeState(_playerStates[typeof(RightSideState)]);
            }
            else if (_playerStateMachine.CurrentState == _playerStates[typeof(LeftSideState)])
            {
                _playerStateMachine.ChangeState(_playerStates[typeof(CenterSideState)]);
            }
            else if (_playerStateMachine.CurrentState == _playerStates[typeof(RightSideState)])
            {
                Debug.Log("Already in RightSideState");
            }
        }
        else if (_input.IsLeftMove())
        {
            if (_playerStateMachine.CurrentState == _playerStates[typeof(CenterSideState)])
            {
                _playerStateMachine.ChangeState(_playerStates[typeof(LeftSideState)]);
            }
            else if (_playerStateMachine.CurrentState == _playerStates[typeof(RightSideState)])
            {
                _playerStateMachine.ChangeState(_playerStates[typeof(CenterSideState)]);
            }
            else if (_playerStateMachine.CurrentState == _playerStates[typeof(LeftSideState)])
            {
                Debug.Log("Already in LeftSideState");
            }
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
