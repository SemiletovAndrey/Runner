using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LeftSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private IPlayerStateMachine _playerStateMachine;
    private PlayerView _playerView;


    [Inject]
    public LeftSideState(PlayerModel playerModel, IPlayerStateMachine playerStateMachine, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerStateMachine = playerStateMachine;
        _playerView = playerView;
    }

    public void Enter()
    {
        Debug.Log("Enter Left State");
        _playerModel.MoveLeft();
        _playerStateMachine.PreviousState = this;
    }
    public void Update()
    {
        _playerModel.MoveForward();
    }

    public void Exit()
    {
        Debug.Log("Exit Left State");
        _playerStateMachine.PreviousState = this;
    }

    public void ReturnState()
    {
        _playerView.PlayRunAnimation();
        _playerStateMachine.PreviousState = this;
    }
}
