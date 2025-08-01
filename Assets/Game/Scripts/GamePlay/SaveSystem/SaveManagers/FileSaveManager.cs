using System.IO;
using UnityEngine;

namespace Game
{
    public class FileSaveManager : ISaveManager
    {
        private readonly string _savePath;
        private readonly ISerializer _serializer;
        
        public FileSaveManager(ISerializer serializer, string fileName = "save.json")
        {
            _serializer = serializer;
            _savePath = Path.Combine(Application.persistentDataPath, fileName);
        }
        
        public void Save<T>(T data)
        {
            var json = _serializer.Serialize(data);
            File.WriteAllText(_savePath, json);
            Debug.Log($"Game saved to: {_savePath}");
        }
        
        public T Load<T>(T defaultData)
        {
            if (!File.Exists(_savePath))
                return defaultData;

            var json = File.ReadAllText(_savePath);
            return _serializer.Deserialize<T>(json);
        }

        public void Delete()
        {
            if (File.Exists(_savePath)) 
                File.Delete(_savePath);
        }
    }
}