using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IInputService _input;
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private IPlayerStateMachine _playerStateMachine;
    private IUIService _uiService;

    [Inject]
    public void Construct(IInputService input,PlayerModel playerModel,PlayerView playerView, IPlayerStateMachine playerStateMachine, IUIService uiService)
    {
        _input = input;
        _playerModel = playerModel;
        _playerView = playerView;
        _playerStateMachine = playerStateMachine;
        _uiService = uiService;
    }

    private void Update()
    {
        HandleInput();
        UpdatePlayer();
        UpdateView();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            EndGame();
        }
    }

    private void HandleInput()
    {
        RightLeftHandler();
        JumpSlideHandler();
    }

    private void JumpSlideHandler()
    {
        if (_input.IsJumpMove() && _playerModel.CanJump)
        {
            JumpHandler();
        }
        else if (_input.IsSquatMove() && _playerModel.CanSlide)
        {
            SlideHandler();
        }
    }

    private void RightLeftHandler()
    {
        if (_input.IsRightMove())
        {
            _playerModel.MoveRight();
        }
        else if (_input.IsLeftMove())
        {
            _playerModel.MoveLeft();
        }
    }

    private void UpdatePlayer()
    {
        _playerModel.UpdateSpeed();
        _playerStateMachine.CurrentState.Update();
        _playerModel.UpdateScore();
    }

    private void UpdateView()
    {
        _playerView.UpdateAnimationSpeed(_playerModel.Speed);
        _uiService.UpdateScore(_playerModel.CurrentScore);
    }

    private void SlideHandler()
    {
        if (_playerStateMachine.CurrentState != _playerStateMachine.GetState<SlideState>())
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<SlideState>());
    }

    private void JumpHandler()
    {
        if (_playerStateMachine.CurrentState != _playerStateMachine.GetState<JumpState>())
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<JumpState>());
    }

    private void EndGame()
    {
        Debug.Log("GameOver");
        _playerModel.MaxScore = _playerModel.CurrentScore;
        _playerStateMachine.ChangeState(_playerStateMachine.GetState<DeathState>());
        _uiService.ShowDeathUI();
        EventBus.OnDeathPlayer?.Invoke();
    }
}
