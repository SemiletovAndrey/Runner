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
        _playerView.PlayRunAnimation();
        _playerStateMachine.PreviousState = this;
    }
    public void Update()
    {
        _playerModel.UpdatePosition();
    }

    public void Exit()
    {
        Debug.Log("Exit Right State");
        _playerStateMachine.PreviousState = this;
    }

    public void ReturnState()
    {
        _playerView.PlayRunAnimation();
        _playerStateMachine.PreviousState = this;
    }
}
