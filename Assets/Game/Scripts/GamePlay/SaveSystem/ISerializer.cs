﻿namespace Game
{
    public interface ISerializer
    {
        string Serialize<T>(T data);
        T Deserialize<T>(string serializedData);
    }
}