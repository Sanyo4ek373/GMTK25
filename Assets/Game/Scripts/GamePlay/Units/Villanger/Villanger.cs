using UnityEngine;
using Zenject;

namespace Game.Villanger
{
    public class Villanger : Unit
    {
        private IWork _work = new Unemployed();
        public IWork Work => _work;
        
        private PathFinder _pathFinder;
        private GridSystem _gridSystem;

        private int _currentIndex;
        private Vector3 _targetPosition;
        
        [Inject]
        public void Construct(PathFinder pathFinder, GridSystem gridSystem)
        {
            _pathFinder = pathFinder;
            _gridSystem = gridSystem;
        }

        private void Start()
        {
            var position = _gridSystem.WorldToCell(transform.position);
            var destination = _gridSystem.WorldToCell(transform.position) + new Vector3Int(5, 5, 0);
            
            var path = _pathFinder.FindPath(position, destination);
            
        }
        
        private void Update()
        {
            var direction = transform.position - _targetPosition;
            transform.position += Vector3.one * Time.deltaTime;
        }
    }
}