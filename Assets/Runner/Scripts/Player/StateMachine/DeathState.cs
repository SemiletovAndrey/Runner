using UnityEngine;
using Zenject;

public class DeathState : IPlayerState
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    [Inject]
    public DeathState(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;
    }

    public void Enter()
    {
        Debug.Log("Enter death State");
        _playerView.StopAnimations();
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
