using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IInputService _input;
    private PlayerModel _playerModel;
    private IPlayerStateMachine _playerStateMachine;

    public PlayerModel PlayerModel {  get { return _playerModel; } }

    [Inject]
    public void Construct(IInputService input,PlayerModel playerModel, IPlayerStateMachine playerStateMachine)
    {
        _input = input;
        _playerModel = playerModel;
        _playerStateMachine = playerStateMachine;
    }

    private void Update()
    {
        HandleInput();
        UpdatePlayer();
        UpdateView();
    }

    private void HandleInput()
    {
        if (_input.IsRightMove())
        {
            RightMovehandler();
        }
        else if (_input.IsLeftMove())
        {
            LeftMoveHandler();

        }
        else if (_input.IsJumpMove() && _playerModel.CanJump)
        {
            JumpHandler();
        }
        else if (_input.IsSquatMove() && _playerModel.CanSlide)
        {
            SlideHandler();
        }
    }

    private void UpdatePlayer()
    {
        _playerModel.UpdateSpeed();
        _playerStateMachine.CurrentState.Update();
    }

    private void UpdateView()
    {

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

    private void LeftMoveHandler()
    {
        if (_playerStateMachine.CurrentState == _playerStateMachine.GetState<CenterSideState>())
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<LeftSideState>());
        else if (_playerStateMachine.CurrentState == _playerStateMachine.GetState<RightSideState>())
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<CenterSideState>());
    }

    private void RightMovehandler()
    {
        if (_playerStateMachine.CurrentState == _playerStateMachine.GetState<CenterSideState>())
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<RightSideState>());
        else if (_playerStateMachine.CurrentState == _playerStateMachine.GetState<LeftSideState>())
            _playerStateMachine.ChangeState(_playerStateMachine.GetState<CenterSideState>());
    }
}
