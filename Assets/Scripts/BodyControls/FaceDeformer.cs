using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class FaceDeformer : StageListenerBase
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMesh;
        [SerializeField] private List<FacePoint> _facePoints;

        public override void OnEnded()
        {
            StopAllCoroutines();
        }
        
        public override void OnStarted()
        {
            foreach (var point in _facePoints)
                point.Init(_skinnedMesh);
            StartCoroutine(Updating());
        }

        private IEnumerator Updating()
        {
            while (true)
            {
                foreach (var point in _facePoints)
                    point.Update();
                yield return null;
            }
      
        }
        
        [System.Serializable]
        public class FacePoint
        {
            [SerializeField] private float _maxDistance;
            [SerializeField] private int _indexUp;
            [SerializeField] private int _indexRight;
            [SerializeField] private float _maxUpWeight = 100;
            [SerializeField] private float _maxRightWeight = 100;
            
            
            [SerializeField] private Transform _fromPoint;
            [SerializeField] private Transform _targetPoint;
            private SkinnedMeshRenderer _renderer;
            
            public void Init(SkinnedMeshRenderer renderer)
            {
                _renderer = renderer;
            }

            public void Update()
            {
                var local = _targetPoint.InverseTransformPoint(_fromPoint.position);
                var yVal = Mathf.InverseLerp(_maxDistance, 0, local.y) * _maxUpWeight;
                var xVal = Mathf.InverseLerp(_maxDistance, 0, local.x) * _maxRightWeight;
                _renderer.SetBlendShapeWeight(_indexRight, xVal);
                _renderer.SetBlendShapeWeight(_indexUp, yVal);
            }
        }

    }
}