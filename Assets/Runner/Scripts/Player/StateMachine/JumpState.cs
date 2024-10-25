using UnityEngine;
using Zenject;

public class JumpState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    [Inject]
    public JumpState(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
    }
    public void Enter()
    {
        Debug.Log("Enter Jump State");
        _playerModel.StartJump();
        _playerView.PlayJumpAnimation();
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
        _playerModel.UpdatePosition();
    }
}
