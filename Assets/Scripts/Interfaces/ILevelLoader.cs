using System;

namespace MovingBodies
{
    public interface ILevelLoader
    {
        public Action<BaseLevel> NewLevelLoaded { get; set; }
        void LoadNextLevel();
        void LoadCurrent();
    }
}