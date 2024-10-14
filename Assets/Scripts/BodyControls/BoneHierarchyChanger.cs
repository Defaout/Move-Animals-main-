using RootMotion.FinalIK;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class BoneHierarchyChanger : MonoBehaviour
    {
        [SerializeField] private Transform _rootBone;
        [SerializeField] private Transform _pelvis;
        [SerializeField] private Transform _spineBase;
        [SerializeField] private Transform _spineBack;
        [SerializeField] private FullBodyBipedIK _fullBodyBipedIK;
        [SerializeField] private Animator _animator;

        [ContextMenu ("SwitchToIK")]
        public void SwitchToIKHierarchy()
        {
            _pelvis.SetParent(_rootBone);
            _spineBack.SetParent(_pelvis);
            _spineBase.SetParent(_spineBack);
            _fullBodyBipedIK.enabled = true;
            _animator.enabled = false;
        }

        [ContextMenu ("SwitchToAnimation")]
        public void SwitchToAnimationHierarchy()
        {
            _spineBase.SetParent(_rootBone);
            _spineBack.SetParent(_spineBase);
            _pelvis.SetParent(_spineBack);
            _fullBodyBipedIK.enabled = false;
            _animator.enabled = true;
        }
    }
}