public interface IPlayerStateMachine
{
    IPlayerState CurrentState { get; }

    void ChangeState(IPlayerState newState);
    void Initialize(IPlayerState startingState);
    void RevertToPreviousState();
    void Update();
}