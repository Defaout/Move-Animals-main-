using System.Collections;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageEndRotator : StageListenerBase
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _localEulerAngles;
        [SerializeField] private float _time;

        public override void OnStarted()
        {
        }

        public override void OnEnded()
        {
            StartCoroutine(Rotating());
        }

        private IEnumerator Rotating()
        {
            var start = _target.localRotation;
            var end = Quaternion.Euler(_localEulerAngles);
            var elapsed = 0f;
            var time = _time;
            while (elapsed <= time)
            {
                _target.localRotation = Quaternion.Lerp(start, end, elapsed / time);
                elapsed += Time.deltaTime;
                yield return null;
            }
            _target.localRotation = end;
        }
    }
}