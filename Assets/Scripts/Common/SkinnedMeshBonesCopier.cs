using EditorUtils;
using UnityEditor;
using UnityEngine;

namespace Common
{
    public class SkinnedMeshBonesCopier : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _fromMesh;
        [SerializeField] private SkinnedMeshRenderer _toMesh;

        
        public void Copy()
        {
            var bones = _fromMesh.bones;
            Debug.Log($"Bones count: {bones.Length}");
            var newBonesArray = new Transform[bones.Length];
            var i = 0;
            foreach (var b in bones)
            {
                newBonesArray[i] = b;
                i++;
                Debug.Log($"bone: {b.name}");
            }
            _toMesh.bones = newBonesArray;
        }
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(SkinnedMeshBonesCopier))]
    public class SkinnedMeshBonesCopierEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var me = target as SkinnedMeshBonesCopier;
            if(EU.ButtonBig("Copy", EU.ForestGreen))
                me.Copy();
        }
    }
    #endif
    
}