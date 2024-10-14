using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace MovingBodies.BodyControls
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action PointGrabbed;

        [SerializeField] private LayerMask _movableMask;
        [SerializeField] private LayerMask _movableSurfaceMask;
        private IMovable _target;
        private Camera _camera;
        private Coroutine _inputTaking;
        private ISurfaceKeeper _surfaceKeeper;

        public bool IsMovingTarget => _target != null;
        
        public void Activate()
        {
            CLog.LogWHeader(nameof(PlayerInput), "Input activated", "g", "w");
            Stop();
            _surfaceKeeper = null;
            _inputTaking = StartCoroutine(InputTaking());
        }
        
        public void Activate(ISurfaceKeeper surfaceKeeper)
        {
            CLog.LogWHeader(nameof(PlayerInput), "Input activated", "g", "w");
            Stop();
            _surfaceKeeper = surfaceKeeper;
            _inputTaking = StartCoroutine(InputTaking());
        }

        public void Stop()
        {
            if(_inputTaking != null)
                StopCoroutine(_inputTaking);
            _surfaceKeeper = null;
        }
        
        
        private IEnumerator InputTaking()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (GC.GameplayTimeController.IsPlaying)
                    {
                        GetTarget();
                        if (_target == null)
                            CLog.LogWHeader(nameof(PlayerInput), "No Target Raycasted", "r", "w");
                        else
                            PointGrabbed?.Invoke();
                    }
                }
                else if (Input.GetMouseButton(0))
                {
                    if (_target != null)
                    {
                        if (_surfaceKeeper == null)
                            Move();
                        else
                            MoveOnSurface();
                    }
                }
                else if(Input.GetMouseButtonUp(0))
                {
                    if(_target != null)
                        _target.OnDeactivated -= OnPointDeactivated;
                    _target = null;
                }
                
                yield return null;
            }
        }

        private void MoveOnSurface()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = new RaycastHit[5];
            if (Physics.RaycastNonAlloc(ray, hits, 100, _movableSurfaceMask) > 0)
            {
                var collider = _surfaceKeeper.GetSurfaceForPoint(_target);
                for (int i = 0; i < hits.Length; i++)
                    if (collider == hits[i].collider)
                        _target.GetTransform().position = hits[i].point;
            }
        }

        private void Move()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100, _movableSurfaceMask))
                _target.GetTransform().position = hit.point;
        }

        private void GetTarget()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 100, _movableMask))
            {
                _target = hit.collider.GetComponent<IMovable>();
                _target.OnDeactivated += OnPointDeactivated;
            }
        }

        private void OnPointDeactivated()
        {
            _target.OnDeactivated -= OnPointDeactivated;
            _target = null;
        }
    }
}