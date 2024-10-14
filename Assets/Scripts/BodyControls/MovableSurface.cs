using UnityEngine;

namespace MovingBodies.BodyControls
{
    public class MovableSurface : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;
        public Collider Collider => _collider;
    }
}