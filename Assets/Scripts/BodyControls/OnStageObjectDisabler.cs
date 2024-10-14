using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageObjectDisabler : StageListenerBase
    {
        [SerializeField] private bool _onStart;
        [SerializeField] private List<GameObject> _gameObjects;

        public override void OnEnded()
        {
            if (_onStart) return;
            foreach (var obj in _gameObjects)
                obj.SetActive(false);
        }

        public override void OnStarted()
        {
            if (!_onStart) return;
            foreach (var obj in _gameObjects)
                obj.SetActive(false);
        }
    }
}
