namespace Game
{
    public interface ISaveManager
    {
        void Save<T>(T data);
        T Load<T>(T defaultData);
        void Delete();
    }
}