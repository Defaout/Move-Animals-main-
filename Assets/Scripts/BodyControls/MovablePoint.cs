using System;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class MovablePoint : MonoBehaviour, IMovable
    {
        public event Action OnDeactivated;

        [SerializeField] private Collider _collider;

        private Transform _transform;

        public Transform GetTransform() => _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Deactivate()
        {
            OnDeactivated?.Invoke();
            _collider.enabled = false;
        }

        public void Activate()
        {
            _collider.enabled = true;
        }
    }
}