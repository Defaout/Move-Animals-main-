using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageObjectActivator : StageListenerBase
    {
        [SerializeField] private bool _onStart; 
        [SerializeField] private List<GameObject> _gameObjects;

        public override void OnEnded()
        {
            if (_onStart) return;
            foreach (var obj in _gameObjects)
                obj.SetActive(true);
        }

        public override void OnStarted()
        {
            if (!_onStart) return;
            foreach (var obj in _gameObjects)
                obj.SetActive(true);
        }
    }
}