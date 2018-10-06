using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeSystem.Development
{
    public class InteractionGizmoDrawer : NodeGizmoDrawer
    {
        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            var node = GetComponent<InteractionNode>();

            if (node.Interaction != null)
            {
                Gizmos.color = node.NodeAsset.NodeColor;
                Gizmos.DrawLine(this.transform.localPosition, node.Interaction.transform.localPosition);
                Gizmos.DrawSphere(node.Interaction.transform.localPosition, 0.1f);
            }
        }
    }
}