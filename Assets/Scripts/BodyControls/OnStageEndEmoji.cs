using DG.Tweening;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageEndEmoji : StageListenerBase
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] private float _scaleTime;
        [SerializeField] private float _increasedScale = 1.1f;
        [SerializeField] private float _scaleBackTime ;

        public override void OnStarted()
        { }

        public override void OnEnded()
        {
            _target.gameObject.SetActive(true);
            _target.localScale = Vector3.zero;
            _target.DOScale(_targetScale * _increasedScale, _scaleTime).OnComplete(() =>
            {
                _target.DOScale(_targetScale, _scaleBackTime);
            });
        }

    }
}