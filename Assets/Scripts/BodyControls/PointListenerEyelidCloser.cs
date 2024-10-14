using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class PointListenerEyelidCloser : MovePointListener
    {
        [SerializeField] private SkinnedMeshRenderer _renderer1;
        [SerializeField] private SkinnedMeshRenderer _renderer2;
        [SerializeField] private int _index1;
        [SerializeField] private int _index2;
        

        public override void UpdatePercent(float percent)
        {
            percent *= 100;
            _renderer1.SetBlendShapeWeight(_index1, percent);
            _renderer2.SetBlendShapeWeight(_index2, percent);
            
        }
    }
}