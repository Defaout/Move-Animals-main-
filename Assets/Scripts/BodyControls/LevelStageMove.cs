using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace MovingBodies.BodyControls
{
    public partial class LevelStageMove : LevelStageBase, ISurfaceKeeper
    {
        public List<PointData> Points => _points;

        [SerializeField] private string _message;
        [SerializeField] private List<StageListenerBase> _listeners;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private List<PointData> _points;
        [SerializeField] private float _pointSnapTime = 0.75f;
        [SerializeField] private float _snapPercent = .8f;

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
            foreach (var point in _points)
            {
                point.Init(GC.ControlPointsPool.GetPoint(), _snapPercent);
                _pointToSurface.Add(point.point, point.surface.Collider);
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
            _isActive = false;
            _input.Stop();
            StopTicking();
        }

        private void StopTicking()
        {
            if(_ticking != null)
                StopCoroutine(_ticking);
        }
        
        private IEnumerator Ticking()
        {
            foreach (var listener in _listeners)
                listener.OnStarted();
            while (true)
            {
                var progress = 0f;
                foreach (var point in _points)
                {
                    if (point.Update())
                        StartCoroutine(SnappingPoint(point));
                    progress += point.Progress;
                }
                progress /= _points.Count;
                _progress = progress;
                GC.GameplayPanel.SetProgress(_progress);
                if (progress >= 1f)
                {
                    Deactivate();
                    foreach (var listener in _listeners)
                        listener.OnEnded();
                    RaiseOnCompleted();
                }
                yield return null;
            }
        }

        private IEnumerator SnappingPoint(PointData point)
        {
            CLog.LogWHeader(nameof(LevelStageMove), "Snapping to point","g", "w");
            var time = _pointSnapTime;
            var elapsed = 0f;
            var tr = point.point.GetTransform();
            var startPos = tr.position;
            var targetPos = point.target.position;
            var progressStart = point.Progress;
            while (elapsed <= time)
            {
                var t = elapsed / time;
                
                tr.position = Vector3.Lerp(startPos, targetPos, t);
                point.Progress = Mathf.Lerp(progressStart, 1f, t);
                elapsed += Time.deltaTime;
                yield return null;
            }
            point.Progress = 1f;
            SoundManager.Instance.PlaySnappingSound();
            tr.position = targetPos;
        }

        #if UNITY_EDITOR
        public void Distance()
        {
            var ind = 0;
            foreach (var pp in _points)
            {
                var d = pp.DistanceToTarget();
                Debug.Log($"Point: {ind}, distance to target: {d}");
            }    
        }
        #endif
    }
}