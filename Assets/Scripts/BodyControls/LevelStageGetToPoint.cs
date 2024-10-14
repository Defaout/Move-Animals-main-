using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace MovingBodies.BodyControls
{
    public class LevelStageGetToPoint : LevelStageBase, ISurfaceKeeper
    {
        [SerializeField] private string _message;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Transform _bodyTransf;
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private float _minRequerDistance;
        [SerializeField] private List<PointData> _pointsData;
        [SerializeField] private List<StageListenerBase> _listeners;

        private float _distance;
        private Coroutine _ticking;
        private bool _isActive;
        private Dictionary<IMovable, Collider> _pointToSurface;

        public void SetMessage(string message)
        {
            _message = message;
            if (_isActive)
                GC.GameplayPanel.SetGameMessage(_message);
        }

        public override void Activate()
        {
            if (_isActive)
                return;
            GC.GameplayPanel.SetGameMessage(_message);
            _isActive = true;
            _pointToSurface = new Dictionary<IMovable, Collider>();
            foreach (var data in _pointsData)
            {
                data.Init(GC.ControlPointsPool.GetPoint());
                _pointToSurface.Add(data.Point, data.Surface.Collider);
            }
            StopTicking();
            _ticking = StartCoroutine(Ticking());

            _input.Activate(this);
        }

        public Collider GetSurfaceForPoint(IMovable movable)
        {
            if (_pointToSurface.TryGetValue(movable, out var result))
                return result;
            else
                return null;
        }

        public override void Deactivate()
        {
            if (!_isActive)
                return;
            foreach (var point in _pointsData)
                point.FadeOut();
            _isActive = false;
            _input.Stop();
            StopTicking();
        }

        private void StopTicking()
        {
            if (_ticking != null)
                StopCoroutine(_ticking);
        }

        private IEnumerator Ticking()
        {
            foreach (var listener in _listeners)
                listener.OnStarted();
            yield return new WaitForEndOfFrame();
            _distance = Vector3.Distance(_targetPoint.position, _bodyTransf.position) - _minRequerDistance;
            while (true && _distance > 0)
            {
                foreach (var point in _pointsData)
                    point.Update();

                float curDistance = Vector3.Distance(_targetPoint.position, _bodyTransf.position) - _minRequerDistance;
                _progress = (_distance - curDistance) / _distance;
                if (_progress > 1) 
                    _progress = 1;
                GC.GameplayPanel.SetProgress(_progress);
                if (_progress >= 1f)
                {
                    Deactivate();

                    foreach (var listener in _listeners)
                        listener.OnEnded();
                    RaiseOnCompleted();
                }
                yield return null;
            }

            Deactivate();
            foreach (var listener in _listeners)
                listener.OnEnded();
            RaiseOnCompleted();
        }
    }
}