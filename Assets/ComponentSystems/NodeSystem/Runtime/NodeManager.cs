using System.Collections.Generic;
using UnityEngine;

namespace NodeSystem.Runtime
{
    public class NodeManager : MonoBehaviour
    {
        private Dictionary<int, NodeObject> nodeMap = new Dictionary<int, NodeObject>();

        public NodeObject this[int key]
        {
            get { return this.nodeMap[key]; }
        }

        public void BuildMap()
        {
            var nodes = FindObjectsOfType<NodeObject>();

            foreach (var item in nodes)
                nodeMap.Add(item.Id, item);
        }

        public List<T> GetNodes<T>(int id) where T : NodeObject
        {
            var searchNode = nodeMap[id];

            if (searchNode == null)
                return null;

            List<T> found = new List<T>();

            foreach (var neighbour in searchNode.Neighbours)
            {
                var component = neighbour.GetComponent<T>();
                if (component != null)
                {
                    found.Add(component);
                }
            }

            return found;
        }
    }
}
