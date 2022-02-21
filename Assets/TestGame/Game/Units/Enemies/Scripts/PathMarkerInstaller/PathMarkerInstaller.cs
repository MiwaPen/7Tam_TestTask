using UnityEngine;
using Zenject;

public class PathMarkerInstaller : MonoInstaller
{
    [SerializeField] private EnemiesPathMarkerList markerList;
    public override void InstallBindings()
    {
        Container.Bind<EnemiesPathMarkerList>()
            .FromInstance(markerList)
            .AsSingle()
            .NonLazy();
    }
}