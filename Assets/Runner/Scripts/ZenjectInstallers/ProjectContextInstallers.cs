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
        Debug.Log("Bind");
        if (Application.isEditor)
        {
            Container.Bind<IInputService>().To<MobileInputSystem>().AsSingle();
        }
        else
        {
            Container.Bind<IInputService>().To<PCInputSystem>().AsSingle();
        }
    }
}