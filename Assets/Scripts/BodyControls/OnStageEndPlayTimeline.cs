using UnityEngine;
using UnityEngine.Playables;

namespace MovingBodies.BodyControls
{
    public class OnStageEndPlayTimeline : StageListenerBase
    {
        [SerializeField] private PlayableDirector _playableDirector;

        public override void OnEnded()
        {
            _playableDirector.Play();
        }

        public override void OnStarted()
        {
        }
    }
}