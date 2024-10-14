using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class BackDeformer : StageListenerBase
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMesh;
        [SerializeField] private List<PointData> _points;

        public override void OnStarted()
        {
            foreach (var point in _points)
                point.Init(_skinnedMesh);
            StartCoroutine(Updating());
        }

        public override void OnEnded()
        {
            StopAllCoroutines();
        }


        private IEnumerator Updating()
        {
            while (true)
            {
                foreach (var point in _points)
                {
                    point.Update();
                }
                
                yield return null;
            }
        }
        
        [System.Serializable]
        public class PointData
        {
            [SerializeField] private Transform _point;
            [SerializeField] private Transform _p1;
            [SerializeField] private Transform _p2;
            [SerializeField] private int _indexStart;
            [SerializeField] private int _indexEnd;
            [SerializeField] private float _maxWeight = 100f;
            [SerializeField] private float _neighbourWeight = 100f;
            
            private SkinnedMeshRenderer _mesh;
            private int _count;
            
            public void Init(SkinnedMeshRenderer mesh)
            {
                _mesh = mesh;
                _count = _indexEnd - _indexStart + 1;
            }

            public void Update()
            {
                for (var i = _indexStart; i <= _indexEnd; i++)
                       _mesh.SetBlendShapeWeight(i, 0f);
                var lerp = Mathf.InverseLerp(_p1.localPosition.y, _p2.localPosition.y, _point.localPosition.y);
                var index = Mathf.RoundToInt(_count * lerp) + _indexStart;
                // Debug.Log($"central index: {index}");
                //_mesh.SetBlendShapeWeight(index, _maxWeight);
                if(index < _indexEnd)
                    _mesh.SetBlendShapeWeight(index + 1, _neighbourWeight);
                if(index > _indexStart)
                    _mesh.SetBlendShapeWeight(index - 1, _neighbourWeight);
            }

        }
    }
}