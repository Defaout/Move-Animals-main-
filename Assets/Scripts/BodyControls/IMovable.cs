using System;
using UnityEngine;

namespace MovingBodies.BodyControls
{
    public interface IMovable
    {
        event Action OnDeactivated;
        void Deactivate();
        Transform GetTransform();
    }
}