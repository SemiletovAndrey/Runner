using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SlideState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    [Inject]
    public SlideState(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
    }
    public void Enter()
    {
        Debug.Log("Enter Slide State");
        _playerModel.StartSlide();
        _playerView.PlaySlideAnimation();
    }

    public void Exit()
    {
        Debug.Log("Exit Jump State");
    }

    public void ReturnState()
    {
    }

    public void Update()
    {
        _playerModel.MoveForward();
    }
}
