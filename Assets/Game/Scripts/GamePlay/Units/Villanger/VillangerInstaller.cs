using UnityEngine;
using Zenject;

namespace Game
{
    public class VillangerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(transform);
            Container.Bind<Animator>().FromInstance(GetComponentInChildren<Animator>());
            
            Container
                .BindInterfacesAndSelfTo<PathFollower>()
                .FromNew()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<VillangerAnimator>()
                .FromNew()
                .AsSingle();
        }
    }
}