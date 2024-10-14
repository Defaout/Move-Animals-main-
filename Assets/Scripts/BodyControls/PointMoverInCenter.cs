using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class PointMoverInCenter : MonoBehaviour
    {
        [SerializeField] private Transform _movingPoint;
        [SerializeField] private bool _freezY;
        [SerializeField] private List<Transform> _cornerPoints;

        private void Update()
        {
            Vector3 postition = Vector3.zero;
            foreach (var point in _cornerPoints)
                postition += point.position;

            postition = postition / _cornerPoints.Count;
            if (_freezY)
                postition.y = _movingPoint.position.y;
            _movingPoint.position = postition;
        }
    }
}