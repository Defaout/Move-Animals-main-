using System;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public abstract class LevelStageBase : MonoBehaviour
    {

        public event Action OnCompleted;
        public virtual float GetProgress() => _progress;
        public abstract void Activate();
        public abstract void Deactivate();
        
        protected float _progress = 0;

        protected void RaiseOnCompleted()
        {
            OnCompleted?.Invoke();
        }
    }
}