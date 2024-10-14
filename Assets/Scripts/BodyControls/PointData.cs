using UnityEngine;
using System;

namespace MovingBodies.BodyControls
{
    [Serializable]
    public class PointData
    {
        [SerializeField] private MovablePoint _point;
        [SerializeField] private MovableSurface _surface;

        private IControlPoint _controlPoint;

        public MovablePoint Point => _point;
        public MovableSurface Surface => _surface;

        public void Init(IControlPoint controlPoint)
        {
            _point.Activate();
            var startPosition = _point.GetTransform().position;
            _controlPoint = controlPoint;
            _controlPoint.Show();
            controlPoint.UpdatePosition(startPosition);
        }

        public void Update()
        {
            _controlPoint.UpdatePosition(_point.GetTransform().position);
        }

        public void FadeOut()
        {
            _controlPoint.FadeOut();
            _point.Deactivate();
        }
    }
}