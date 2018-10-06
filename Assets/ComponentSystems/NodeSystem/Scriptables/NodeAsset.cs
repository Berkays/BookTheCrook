using UnityEngine;

namespace NodeSystem.ScriptableObjects
{
    [CreateAssetMenu()]
    public class NodeAsset : ScriptableObject
    {
        public Color NodeColor;
        public float GizmoSize;
    }
}