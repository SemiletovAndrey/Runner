using UnityEngine;
using Zenject;

public class CenterSideState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private IPlayerStateMachine _playerStateMachine;

    [Inject]
    public CenterSideState(PlayerModel playerModel, PlayerView playerView, IPlayerStateMachine playerStateMachine)
    {
        _playerModel = playerModel;
        _playerView = playerView;
        _playerStateMachine = playerStateMachine;
    }

    public void Enter()
    {
        Debug.Log("Enter Center State");
        _playerModel.MoveCenter();
        _playerView.PlayRunAnimation();
        _playerStateMachine.PreviousState = this;
    }
    public void Update()
    {
        _playerModel.MoveForward();
    }

    public void Exit()
    {
        Debug.Log("Exit Center State");
        _playerStateMachine.PreviousState = this;
    }

}
