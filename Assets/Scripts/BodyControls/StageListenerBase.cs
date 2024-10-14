using UnityEngine;

namespace MovingBodies.BodyControls
{
    public abstract class StageListenerBase : MonoBehaviour
    {
        public abstract void OnStarted();
        public abstract void OnEnded();
        
    }
}