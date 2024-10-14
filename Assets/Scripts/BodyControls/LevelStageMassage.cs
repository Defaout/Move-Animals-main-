using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class LevelStageMassage : LevelStageBase
    {
        public List<PointData> Points => _points;

        [SerializeField] private string _message;
        [SerializeField] private List<StageListenerBase> _listeners;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private List<PointData> _points;
        private Coroutine _ticking;

        private bool _isActive;

        #if UNITY_EDITOR
        private void OnValidate()
        {
            if(_playerInput == null)
                _playerInput = FindObjectOfType<PlayerInput>();
        }
        #endif

        public void SetMessage(string message)
        {
            _message = message;
            if (_isActive)
                GC.GameplayPanel.SetGameMessage(_message);
        }

        public override void Activate()
        {
            GC.GameplayPanel.SetGameMessage(_message);
            StopTicking();
            _ticking = StartCoroutine(Ticking());
            _playerInput.Activate();
            _isActive = true;
        }

        public override void Deactivate()
        {
            StopTicking();   
            _playerInput.Stop();
            _isActive = false;
        }
        
        private void StopTicking()
        {
            if(_ticking != null)
                StopCoroutine(_ticking);
        }
        
        private IEnumerator Ticking()
        {
            foreach (var pointData in _points)
                pointData.Init(GC.ControlPointsPool.GetPoint());
            foreach (var listener in _listeners)
                listener.OnStarted();
            while (true)
            {
                var progress = 0f;
                foreach (var pointData in _points)
                {
                    pointData.Update();
                    progress += pointData.progress;
                }
                progress /= _points.Count;
                _progress = progress;
                GC.GameplayPanel.SetProgress(_progress);
                if (_progress >= 1)
                {
                    StopTicking();
                    foreach (var listener in _listeners)
                        listener.OnEnded();
                    RaiseOnCompleted();
                }
                yield return null;
            }
        }
        
        
        
        [System.Serializable]
        public class PointData
        {
            public MovablePoint Point => _point;
            public float MaxDistance => _maxDistance;
            [SerializeField] private MovablePoint _point;
            [SerializeField] private float _maxDistance = 1;
            [NonSerialized]  public float progress;
            private Vector3 _prevPosition;
            private float _maxDistance2;
            private float _totalDistance2;
            private IControlPoint _controlPoint;
            private bool _active;
            
            public void Init(IControlPoint controlPoint)
            {
                _controlPoint = controlPoint;
                _point.Activate();
                _maxDistance2 = _maxDistance * _maxDistance;
                _prevPosition = _point.GetTransform().localPosition;
                _controlPoint.UpdatePosition(_prevPosition);
                _controlPoint.Show();
                _active = true;
            }

            public void Update()
            {
                if (!_active)
                    return;
                var pointPosition = _point.GetTransform().localPosition; 
                var distance2 = (pointPosition - _prevPosition).sqrMagnitude;
                _prevPosition = pointPosition;
                _totalDistance2 += distance2;
                // Debug.Log($"Total2 {_totalDistance2}, distance2: {distance2}, prev: {_prevPosition}, point: {pointPosition}");
                _controlPoint.UpdatePosition(_point.GetTransform().position);
                progress = (_totalDistance2 / _maxDistance2);
                if (progress > 1)
                    progress = 1;
                _controlPoint.AdjustColorToProgress(progress);
                if (progress == 1)
                {
                    _point.Deactivate();
                    _controlPoint.FadeOut();
                    _active = false;
                }
            }
            
        }
    }
}