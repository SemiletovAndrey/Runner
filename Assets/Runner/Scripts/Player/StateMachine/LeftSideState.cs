using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public LeftSideState(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
    }

    public void Enter()
    {
        Debug.Log("Enter Left State");
        _playerModel.MoveLeft();
    }
    public void Update()
    {
        _playerModel.MoveForward();
        //_playerView.PlayIdleAnimation();
    }

    public void Exit()
    {
        Debug.Log("Exit Left State");
    }
}
