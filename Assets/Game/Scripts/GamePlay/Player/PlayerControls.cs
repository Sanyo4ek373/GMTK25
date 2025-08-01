using System;
using Unity.VisualScripting;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Game
{
    public class PlayerControls : IInitializable, IDisposable
    {
        public Controls Controls { get; }

        public PlayerControls()
        {
            Controls = new Controls();
        }

        public void Initialize()
        {
            Controls.Enable();
        }

        public void Dispose()
        {
            Controls.Disable();
        }
    }
}