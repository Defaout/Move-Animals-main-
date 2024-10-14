using System.Collections.Generic;
using UnityEngine;
using System;

namespace MovingBodies.BodyControls
{
    public partial class LevelStageMove
    {
        [Serializable]
        public class PointData
        {
            public MovablePoint point;
            public Transform target;
            public MovableSurface surface;
            public float minDistance;
            public float maxDistance;
            public List<MovePointListener> listeners;
            
            private IControlPoint _controlPoint;
            private float _minDistance2;
            private float _maxDistance2;
            private bool _isActive;
            private float _snapPercent;
            private float _percent;

            public float Progress
            {
                get => _percent;
                set
                {
                    _percent = value;
                    foreach (var listener in listeners)
                        listener.UpdatePercent(_percent);
                }
            }
            

            public float DistanceToTarget() => (point.GetTransform().position - target.position).magnitude;

            public void Init(IControlPoint controlPoint, float snapPercent)
            {
                point.Activate();
                var startPosition = point.GetTransform().position;
                _snapPercent = snapPercent;
                _controlPoint = controlPoint;
                _controlPoint.Show();
                minDistance = 0.001f;
                _maxDistance2 = maxDistance * maxDistance;
                _minDistance2 = minDistance * minDistance;
                _isActive = true;
                controlPoint.UpdatePosition(startPosition);
            }
            
            public bool Update()
            {
                if (!_isActive)
                {
                    _controlPoint.UpdatePosition(point.GetTransform().position);
                    return false;
                }
                var pointPos = point.GetTransform().position;
                var targetPos = target.position;
                var d2 = (pointPos - targetPos).sqrMagnitude;
                if (d2 >= _maxDistance2)
                    Progress = 0;
                else if (d2 <= _minDistance2)
                    Progress = 1f;
                else
                    Progress = 1 - Mathf.InverseLerp(_minDistance2, _maxDistance2, d2);
                _controlPoint.UpdatePosition(pointPos);
                _controlPoint.AdjustColorToProgress(Progress);
                if (Progress >= _snapPercent)
                {
                    _isActive = false;
                    _controlPoint.FadeOut();   
                    point.Deactivate();
                    return true;
                }
                return false;
            }
        }
    }
}