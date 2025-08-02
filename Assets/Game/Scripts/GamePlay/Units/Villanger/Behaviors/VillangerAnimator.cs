using UnityEngine;
using Zenject;

namespace Game
{
    public class VillangerAnimator : ITickable
    {
        private Animator _animator;
        private PathFollower _pathFollower;

        private static readonly string[] StateNames = {
            "Right",      // 0
            "Up-Right",    // 1
            "Up",         // 2
            "Up-Left",     // 3
            "Left",       // 4
            "Down-Left",   // 5
            "Down",       // 6
            "Down-Right"   // 7
        };

        public VillangerAnimator(Animator animator, PathFollower pathFollower)
        {
            _animator = animator;   
            _pathFollower = pathFollower;
        }

        public void Tick()
        {
            var direction = _pathFollower.GetDirection();
            _animator.Play($"Base Layer.{GetDirectionName(direction)}");
        }
        
        private string GetDirectionName(Vector2 dir)
        {
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle = (angle + 360) % 360;
    
            var index = Mathf.FloorToInt((angle + 22.5f) / 45) % 8;
    
            return StateNames[index];
        }
    }
}