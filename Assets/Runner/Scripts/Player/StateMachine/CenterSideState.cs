using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public CenterSideState(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
    }

    public void Enter()
    {
        Debug.Log("Enter Center State");
        _playerModel.MoveCenter();
    }
    public void Update()
    {
        _playerModel.MoveForward();
        //_playerView.PlayIdleAnimation();
    }

    public void Exit()
    {
        Debug.Log("Exit Center State");
    }

}
