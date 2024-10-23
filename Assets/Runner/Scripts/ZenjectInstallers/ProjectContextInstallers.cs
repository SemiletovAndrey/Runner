using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectContextInstallers : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputServices();

    }

    private void BindInputServices()
    {
        if (Application.isMobilePlatform)
        {
            Container.Bind<IInputService>().To<MobileInputSystem>().AsSingle();
        }
        else
        {
            Container.Bind<IInputService>().To<PCInputSystem>().AsSingle();
        }
    }



}
