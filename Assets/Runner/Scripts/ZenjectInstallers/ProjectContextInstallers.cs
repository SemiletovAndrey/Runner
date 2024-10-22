using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextInstallers : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputServices();

        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle();
    }

    private void BindInputServices()
    {
        if (Application.isEditor)
        {
            Container.Bind<IInputService>().To<PCInputSystem>().AsSingle();
        }
        else
        {
            Container.Bind<IInputService>().To<MobileInputSystem>().AsSingle();
        }
    }



}
