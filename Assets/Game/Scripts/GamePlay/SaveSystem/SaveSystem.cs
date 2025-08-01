using Zenject;

namespace Game
{
    public class SaveSystem : IInitializable
    {
        private DefaultResources _defaultResources;
        
        private PlayerModelRef _playerModel;
        private ISaveManager _saveManager;
            
        public SaveSystem(ISaveManager saveManager, PlayerModelRef playerModel, DefaultResources defaultResources)
        {
            _saveManager = saveManager;
            _defaultResources = defaultResources;
            _playerModel = playerModel;
        }
        
        public void Initialize()
        {
            _playerModel.PlayerModel = _saveManager.Load(new PlayerModel()
            {
                Resources = _defaultResources.Model
            });
        }
    }
}