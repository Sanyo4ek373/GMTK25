using System;

namespace Game
{
    [Serializable]
    public class PlayerModel
    {
        public ResourcesModel Resources { get; set; }

        public PlayerModel()
        {
            Resources = new();
        }

        public PlayerModel(ResourcesModel resources)
        {
            Resources = resources;
        }
    }

    public class PlayerModelRef
    {
        public PlayerModel PlayerModel { get; set; }
    }
}