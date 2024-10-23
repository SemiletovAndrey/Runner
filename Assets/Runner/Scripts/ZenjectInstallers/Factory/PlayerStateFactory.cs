using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateFactory : IPlayerStateFactory
{
    private readonly DiContainer _container;

    public PlayerStateFactory(DiContainer container)
    {
        _container = container;
    }

    public T CreateTState<T>() where T : IPlayerState
    {
        return _container.Instantiate<T>();
    }
}
