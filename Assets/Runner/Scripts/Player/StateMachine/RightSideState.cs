using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RightSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private IPlayerStateMachine _playerStateMachine;

    [Inject]
    public RightSideState(PlayerModel playerModel, PlayerView playerView, IPlayerStateMachine playerStateMachine)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _playerStateMachine = playerStateMachine;
    }

    public void Enter()
    {
        Debug.Log("Enter Right State");
        _playerModel.MoveRight();
        _playerStateMachine.PreviousState = this;
    }
    public void Update()
    {
        _playerModel.MoveForward();
    }

    public void Exit()
    {
        Debug.Log("Exit Right State");
        _playerStateMachine.PreviousState = this;
    }
}
