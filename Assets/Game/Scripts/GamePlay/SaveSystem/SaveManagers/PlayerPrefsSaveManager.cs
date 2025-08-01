using UnityEngine;

namespace Game
{
    public class PlayerPrefsSaveManager : ISaveManager
    {
        private readonly string _key;
        private readonly ISerializer _serializer;

        public PlayerPrefsSaveManager(ISerializer serializer, string key = "SaveData")
        {
            _serializer = serializer;
            _key = key;
        }

        public void Save<T>(T data)
        {
            var json = _serializer.Serialize(data);
            PlayerPrefs.SetString(_key, json);
            PlayerPrefs.Save();
        }

        public T Load<T>(T defaultData)
        {
            if (!PlayerPrefs.HasKey(_key)) 
                return defaultData;
            
            var json = PlayerPrefs.GetString(_key);
            return _serializer.Deserialize<T>(json);
        }

        public void Delete()
        {
            PlayerPrefs.DeleteKey(_key);
        }
    }
}