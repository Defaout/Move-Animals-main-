namespace MovingBodies
{
    public interface IControlPointsPool
    {
        void Spawn();
        IControlPoint GetPoint();
        void ReturnPoint(IControlPoint point);
        void ReturnAllGiven();
    }
}