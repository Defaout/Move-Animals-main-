using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class StageEndReparenter : StageListenerBase
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _parent;
        
        public override void OnEnded()
        {
            _target.SetParent(_parent);
            _target.localPosition = Vector3.zero;
            _target.localRotation = Quaternion.identity;
        }

        public override void OnStarted()
        {
        }

    }
}