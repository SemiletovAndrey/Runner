using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LeftSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private IPlayerStateMachine _playerStateMachine;


    [Inject]
    public LeftSideState(PlayerModel playerModel, IPlayerStateMachine playerStateMachine)
    {
        _playerModel = playerModel;
        _playerStateMachine = playerStateMachine;
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
}
