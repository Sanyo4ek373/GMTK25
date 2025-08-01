using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "TownHall", menuName = "Game/Buildings/TownHall")]
    public class TownHallConfig : ScriptableObject
    {
        [Serializable]
        public struct TownHallLevel
        {
            public int CapacityOfWorkers;
        }
        
        public List<TownHallLevel> Levels;
    }
}