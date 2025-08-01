using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "DefaultResources", menuName = "Game/DefaultResources")]
    public class DefaultResources : ScriptableObject
    {
        [field: SerializeField] public ResourcesModel Model { get; private set; }
    }
}