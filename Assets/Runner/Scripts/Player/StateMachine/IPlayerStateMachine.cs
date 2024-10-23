public interface IPlayerStateMachine
{
    IPlayerState CurrentState { get; }
    IPlayerState PreviousState { get; set; }

    void ChangeState(IPlayerState newState);
    TState GetState<TState>() where TState : class, IPlayerState;
    void RevertToPreviousState();
    void Update();
}