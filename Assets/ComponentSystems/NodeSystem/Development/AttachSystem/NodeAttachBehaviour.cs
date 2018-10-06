using UnityEngine;

namespace NodeSystem.Development
{
    public abstract class NodeAttachBehaviour : MonoBehaviour
    {
        public virtual bool Attach(GameObject objToAttach)
        {
            var node = this.GetComponent<NodeObject>();

            var nodeToAttach = objToAttach.GetComponent<NodeObject>();

            if (nodeToAttach != null)
            {
                var nodeHelper = FindObjectOfType<NodeHelper>();
                nodeHelper.Connect(node, nodeToAttach);

                return true;
            }

            return false;
        }
    }
}