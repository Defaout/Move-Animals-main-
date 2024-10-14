using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class RigRotateActivator : MovePointListener
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _rotation;

        public override void UpdatePercent(float percent)
        {
            if (percent >= 1)
                _target.rotation = Quaternion.Euler(_rotation);                
        }
    }
}