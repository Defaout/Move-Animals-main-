using UnityEngine;

namespace MovingBodies
{
    public interface IControlPoint
    {
        void UpdatePosition(Vector3 worldPosition);
        void Show();
        void Hide();
        void AdjustColorToProgress(float lerpVal);
        void FadeOut();
    }
}