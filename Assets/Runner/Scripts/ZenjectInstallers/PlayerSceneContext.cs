using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerSceneContext : MonoInstaller
{
    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private Collider _centerCollider;
    [SerializeField] private Collider _jumpCollider;
    [SerializeField] private Collider _slideCollider;
    [SerializeField] private Rigidbody _rigidbodyPlayer;
    [SerializeField] private Transform _playerTransform;

    public override void InstallBindings()
    {

        Container.Bind<IPlayerStateFactory>().To<PlayerStateFactory>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle();


        Container.Bind<PlayerModel>()
            .AsSingle()
            .WithArguments(_rigidbodyPlayer, _centerCollider, _jumpCollider, _slideCollider);

        Container.Bind<PlayerView>()
            .AsSingle()
            .WithArguments(_animatorPlayer);

        Container.Bind<Transform>().WithId("PlayerTransform").FromInstance(_playerTransform);
    }
}
