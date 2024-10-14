using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class OnStageStartParticlesPlayer : StageListenerBase
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Painter _positioner;
        public override void OnStarted()
        {
            _particle.Play();
            _positioner.Activate();
        }

        public override void OnEnded()
        {
            _particle.Stop();
        }
    }
}