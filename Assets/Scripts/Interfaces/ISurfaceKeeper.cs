using UnityEngine;

namespace MovingBodies.BodyControls
{
    public interface ISurfaceKeeper
    {
        Collider GetSurfaceForPoint(IMovable movable);
    }
}