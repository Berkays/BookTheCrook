using UnityEditor;
using UnityEngine;

namespace NodeSystem.Development
{
    public abstract class NodeGizmoDrawer : MonoBehaviour
    {
        private static readonly Color connectionColor = new Color(0, 0.5f, 1);
        private static readonly Vector3 labelOffset = new Vector3(0, -0.4f, 0);
        private NodeObject node;

        protected virtual void OnDrawGizmos()
        {
            if (node == null)
                node = GetComponent<NodeObject>();

            Handles.Label(this.transform.localPosition + labelOffset, $"Id: {node.Id}");

            Gizmos.color = connectionColor;

            if (node.Neighbours == null)
                return;

            for (int i = 0; i < node.Neighbours.Count; i++)
            {
                Vector3 p1 = this.transform.localPosition;
                Vector3 p2 = node.Neighbours[i].transform.localPosition;
                Vector3 center = Vector3.Lerp(p1, p2, 0.5f);

                Gizmos.DrawLine(p1, p2);
                Gizmos.DrawSphere(center, 0.05f);
            }

            if (node.NodeAsset != null)
            {
                Gizmos.color = node.NodeAsset.NodeColor;
                Gizmos.DrawSphere(this.transform.localPosition, node.NodeAsset.GizmoSize);
            }
        }
    }
}