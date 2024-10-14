using System.Collections;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class Painter : StageListenerBase
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private Transform _target;
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private float _delay;
        [SerializeField] private PlayerInput _playerInput;

        private Coroutine _painting;
        
        public void Activate()
        {
            Stop();
            _painting = StartCoroutine(Painting());
        }

        public void Stop()
        {
            if(_painting != null)
                StopCoroutine(_painting);
        }

        private IEnumerator Painting()
        {
            yield return new WaitForSeconds(_delay);
            _particles.Play();
            while (true)
            {
                if (_playerInput.IsMovingTarget)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hit, 100, _mask))
                    {
                        _target.position = hit.point;
                    }
                }
                yield return null;
            }
        }

        public override void OnStarted()
        {
            Activate();
        }

        public override void OnEnded()
        {
        }
    }
}