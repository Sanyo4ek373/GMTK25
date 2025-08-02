using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PathFollower
    {
        private const float k_minSqrDistance = 0.01f;
        
        private Vector3Int _target;
        private List<Vector3Int> _path;
        
        private readonly PathFinder _pathFinder;
        private readonly GridSystem _gridSystem;
        private Transform _transform;
        
        private Vector3 _targetPosition;
        private int _pathIndex;
        
        public PathFollower(PathFinder pathFinder, GridSystem gridSystem, Transform transform)
        {
            _pathFinder = pathFinder;
            _gridSystem = gridSystem;
            _transform = transform;
        }

        public Vector3Int Target
        {
            get => _target;
            set
            {
                _target = value;
                
                var position = _gridSystem.WorldToCell(_transform.position);
                
                _path = _pathFinder.FindPath(position, _target);
                if (_path == null)
                    return;

                _pathIndex = 0;
                _targetPosition = _gridSystem.CellToWorld(_path[_pathIndex]);
            }
        }
        
        public Vector3 GetDirection()
        {
            if (_path == null)
                return Vector3.zero;
            
            var offset = _targetPosition - _transform.position;
            if (offset.sqrMagnitude < k_minSqrDistance)
            {
                _pathIndex += 1;
                if (_pathIndex >= _path.Count)
                    return Vector3.zero;

                _targetPosition = _gridSystem.CellToWorld(_path[_pathIndex]);
            }

            return offset.normalized;
        }
    }
}