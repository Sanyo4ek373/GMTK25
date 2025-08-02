using UnityEngine;
using Zenject;

namespace Game
{
    public class Villanger : Unit
    {
        private IWork _work = new Unemployed();
        public IWork Work => _work;

        private PathFollower _pathFollower;
        private GridSystem _gridSystem;

        [Inject]
        public void Construct(PathFollower pathFollower, GridSystem gridSystem)
        {
            _pathFollower = pathFollower;
            _gridSystem = gridSystem;
        }
        
        private void Start()
        {
            _pathFollower.Target = _gridSystem.WorldToCell(transform.position) + Vector3Int.up * 10;
        }

        private void Update()
        {
            transform.position += _pathFollower.GetDirection() * Time.deltaTime;
        }
    }
}