using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IdleState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private IPlayerStateMachine _playerStateMachine;

    [Inject]
    public IdleState(PlayerModel playerModel, PlayerView playerView, IPlayerStateMachine playerStateMachine)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _playerStateMachine = playerStateMachine;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle");
        _playerModel.RestartPlayerPosition();
        _playerView.PlayIdleAnimation();
    }

    public void Exit()
    {
        
    }

    public void ReturnState()
    {
        
    }

    public void Update()
    {

    }
}
