using System.Collections;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageEndPickItem : StageListenerBase
    {
        [SerializeField] private Transform _item;
        [SerializeField] private Transform _parent;
        [SerializeField] private float _moveTime = 0.5f;
        
        public override void OnStarted()
        { }

        public override void OnEnded()
        {
            StartCoroutine(Moving());
        }

        private IEnumerator Moving()
        {
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            _item.SetParent(_parent);
            var elapsed = 0f;
            var startPos = _item.localPosition;
            var startRot = _item.localRotation;
            while (elapsed <= _moveTime)
            {
                var t = elapsed / _moveTime;
                _item.localPosition = Vector3.Lerp(startPos, Vector3.zero, t);
                _item.localRotation = Quaternion.Lerp(startRot, Quaternion.identity, t);
                elapsed += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            _item.localRotation = Quaternion.identity;
            _item.localPosition = Vector3.zero;
        }
    }
}