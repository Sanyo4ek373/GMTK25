using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Game {
    [DefaultExecutionOrder(-100)]
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Tilemap _groundTileMap;
        [SerializeField] private Tilemap _decorationTileMap;
        
        [SerializeField] private TownHallInspectorView _townHallInspectorView;
        [SerializeField] private TownHallConfig _townHallConfig;
        [SerializeField] private TilesDB _tilesDB;
        
        [SerializeField] private DefaultResources _resources;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.Bind<DefaultResources>().FromInstance(_resources);
            
            Container.Bind<PlayerModelRef>().FromNew().AsSingle();
            Container.Bind<ISerializer>().To<JsonSerializer>().AsSingle();
            Container.Bind<ISaveManager>().To<FileSaveManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveSystem>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<PlayerControls>().AsSingle().NonLazy();
            Container.Bind<TilesDB>().FromInstance(_tilesDB);
            
            Container.Bind<TownHallInspectorView>().FromInstance(_townHallInspectorView);
            Container.Bind<TownHallConfig>().FromInstance(_townHallConfig);
            Container.Bind<TownHallModel>().FromNew().AsSingle();
            
            Container.Bind<Tilemap>()
                .WithId(GridSystem.k_GroundTileMap)
                .FromInstance(_groundTileMap);
            Container.Bind<Tilemap>()
                .WithId(GridSystem.k_DecorationTileMap)
                .FromInstance(_decorationTileMap);
            
            Container.BindInterfacesAndSelfTo<GridSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerBrush>().AsSingle().NonLazy();
        }
    }
}