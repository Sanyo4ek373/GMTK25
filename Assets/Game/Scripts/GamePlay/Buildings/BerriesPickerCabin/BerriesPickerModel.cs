namespace Game
{
    public class BerriesPickerModel
    {
        public BerriesPickerCabinConfig Config { get; private set; }
        
        public int Workes { get; set; }
        public int Level { get; set; }

        public BerriesPickerModel(BerriesPickerCabinConfig config)
        {
            Config = config;
        }
    }
}