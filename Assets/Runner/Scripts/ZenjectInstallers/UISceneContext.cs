using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class UISceneContext : MonoInstaller
{
    [SerializeField] private UIManager _uiManager;
    public override void InstallBindings()
    {
        Container.Bind<IUIService>().To<UIManager>().FromInstance(_uiManager).AsSingle();
    }
}
