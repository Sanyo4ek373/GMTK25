namespace Game
{
    public class TownHallModel
    {
        public TownHallConfig Config { get; private set; }

        public int Workers { get; set; }
        public int Level { get; set; }
        
        public TownHallModel(TownHallConfig config)
        {
            Config = config;
        }
    }
}