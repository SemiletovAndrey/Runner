public interface IPlayerStateFactory
{
    T CreateTState<T>() where T : IPlayerState;
}