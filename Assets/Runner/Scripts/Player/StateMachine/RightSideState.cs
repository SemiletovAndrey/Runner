using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public RightSideState(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
    }

    public void Enter()
    {
        Debug.Log("Enter Right State");
        _playerModel.MoveRight();
    }
    public void Update()
    {
        _playerModel.MoveForward();
        //_playerView.PlayIdleAnimation();
    }

    public void Exit()
    {
        Debug.Log("Exit Right State");
    }
}
