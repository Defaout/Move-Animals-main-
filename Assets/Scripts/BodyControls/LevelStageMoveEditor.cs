#if UNITY_EDITOR
using EditorUtils;
using UnityEditor;

namespace MovingBodies.BodyControls
{
    [CustomEditor(typeof(LevelStageMove))]
    public class LevelStageMoveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var me = target as LevelStageMove;
            if (EU.ButtonBig("Distance", EU.Gold))
                me.Distance();
        }
    }
}
#endif