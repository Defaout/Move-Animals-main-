using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageEndDisabler : StageListenerBase
    {
        [SerializeField] private List<GameObject> _targets;
        public override void OnStarted()
        {
        }

        public override void OnEnded()
        {
            foreach (var target in _targets)
                target.SetActive(false);
        }

    }
}