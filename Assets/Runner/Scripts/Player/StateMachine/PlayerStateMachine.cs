using System;
using System.Collections.Generic;
using Zenject;

public class PlayerStateMachine : IPlayerStateMachine, IInitializable
{
    private IPlayerState _currentState;
    private IPlayerState _previousState;
    private IPlayerStateFactory _playerStateFactory;

    private Dictionary<Type, IPlayerState> _playerStates = new Dictionary<Type, IPlayerState>();

    public IPlayerState CurrentState {  get { return _currentState; } }
    public IPlayerState PreviousState {  get { return _currentState; }
        set { _previousState = value; }}

    public PlayerStateMachine(IPlayerStateFactory playerStateFactory)
    {
        _playerStateFactory = playerStateFactory;
    }

    public void InitializeStates()
    {
        _playerStates[typeof(IdleState)] = _playerStateFactory.CreateTState<IdleState>();
        _playerStates[typeof(CenterSideState)] = _playerStateFactory.CreateTState<CenterSideState>();
        _playerStates[typeof(RightSideState)] = _playerStateFactory.CreateTState<RightSideState>();
        _playerStates[typeof(LeftSideState)] = _playerStateFactory.CreateTState<LeftSideState>();
        _playerStates[typeof(JumpState)] = _playerStateFactory.CreateTState<JumpState>();
        _playerStates[typeof(SlideState)] = _playerStateFactory.CreateTState<SlideState>();
        _playerStates[typeof(DeathState)] = _playerStateFactory.CreateTState<DeathState>();
    }

    public void Initialize()
    {
        InitializeStates();
        _currentState = _playerStates[typeof(IdleState)];
        _currentState.Enter();
        EventBus.OnRestartGame += RestartAllState;
    }

    public void ChangeState(IPlayerState newState)
    {
        if (_currentState != newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }

    public void RevertToPreviousState()
    {
        if (_previousState != null)
        {
            ReturnState(_previousState);
        }
    }

    private void ReturnState(IPlayerState previousState)
    {
        if (_currentState != previousState)
        {
            _currentState.Exit();
            _currentState = previousState;
            _currentState.ReturnState();
        }
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void RestartAllState()
    {
        _previousState = _playerStates[typeof(IdleState)];
        _currentState = _playerStates[typeof(IdleState)];
        _currentState.Enter();
    }

    public TState GetState<TState>() where TState : class, IPlayerState
    {
        return _playerStates[typeof(TState)] as TState;
    }
}
