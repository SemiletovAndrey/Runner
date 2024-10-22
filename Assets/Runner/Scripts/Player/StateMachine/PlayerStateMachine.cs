using System;
using System.Collections.Generic;
using Zenject;

public class PlayerStateMachine : IPlayerStateMachine
{
    private IPlayerState _currentState;
    private IPlayerState _previousState;

    public IPlayerState CurrentState {  get { return _currentState; } }

    public void Initialize(IPlayerState startingState)
    {
        _currentState = startingState;
        _currentState.Enter();
    }

    public void ChangeState(IPlayerState newState)
    {
        if (_currentState != newState)
        {
            _currentState.Exit();
            _previousState = _currentState;
            _currentState = newState;
            _currentState.Enter();
        }
    }

    public void RevertToPreviousState()
    {
        if (_previousState != null)
        {
            ChangeState(_previousState);
        }
    }


    public void Update()
    {
        _currentState.Update();
    }
}
