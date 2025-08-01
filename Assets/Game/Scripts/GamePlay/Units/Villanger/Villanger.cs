namespace Game.Villanger
{
    public class Villanger : Unit
    {
        private IWork _work = new Unemployed();
        public IWork Work => _work;

        public override void Update()
        {
            
        }
    }
}