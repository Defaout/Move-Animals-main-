using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class StageStartJointConnector : StageListenerBase
    {
        [SerializeField] private List<Joint> _joints;
        [SerializeField] private Rigidbody _rigidbody;
        public override void OnStarted()
        {
            foreach (var joint in _joints)
                joint.connectedBody = _rigidbody;
        }

        public override void OnEnded()
        {
        }
    }
}