using UnityEngine;

namespace MovingBodies.BodyControls
{
    public abstract class MovePointListener : MonoBehaviour
    {
        public abstract void UpdatePercent(float percent);
    }
}