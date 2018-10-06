using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NodeSystem.Development
{
    [ExecuteInEditMode()]
    public class NodeHelper : MonoBehaviour
    {

        public Transform Container;
        public SerializedNodeTypeDictionary typeMap = new SerializedNodeTypeDictionary();

        private HashSet<int> idMap;

        void OnEnable()
        {
            if (Application.isPlaying == false)
                BuildMap();
        }

        public void BuildMap()
        {
            idMap = new HashSet<int>();

            var nodes = FindObjectsOfType<NodeObject>();

            for (int i = 0; i < nodes.Length; i++)
                idMap.Add(nodes[i].Id);
        }

        public GameObject CreateNode(NodeType nodeType)
        {
            var uniqueId = findUniqueId();

            var obj = PrefabUtility.InstantiatePrefab(typeMap[nodeType]) as GameObject;
            obj.name = $"{nodeType.ToString()}: {uniqueId}";
            obj.transform.parent = Container;

            var component = obj.GetComponent<NodeObject>();

            component.Id = uniqueId;

            idMap.Add(uniqueId);

            return obj;
        }

        private int findUniqueId()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (idMap.Contains(i) == false)
                    return i;
            }

            return 0;
        }

        public void Connect(params NodeObject[] nodes)
        {
            Undo.RecordObjects(nodes, "Connect nodes");
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                for (int k = i + 1; k < nodes.Length; k++)
                {
                    var pNode = nodes[i];
                    var sNode = nodes[k];

                    if (!pNode.Neighbours.Contains(sNode))
                        pNode.Neighbours.Add(sNode);

                    if (!sNode.Neighbours.Contains(pNode))
                        sNode.Neighbours.Add(pNode);

                    EditorUtility.SetDirty(pNode);
                    EditorUtility.SetDirty(sNode);
                }
            }
        }

        public void Disconnect(params NodeObject[] nodes)
        {
            Undo.RecordObjects(nodes, "Disconnect nodes");
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                for (int k = i + 1; k < nodes.Length; k++)
                {
                    var pNode = nodes[i];
                    var sNode = nodes[k];

                    if (pNode.Neighbours.Contains(sNode))
                        pNode.Neighbours.Remove(sNode);

                    if (sNode.Neighbours.Contains(pNode))
                        sNode.Neighbours.Remove(pNode);

                    EditorUtility.SetDirty(pNode);
                    EditorUtility.SetDirty(sNode);
                }
            }
        }

        public void Destroy(NodeObject node)
        {
            var nodes = FindObjectsOfType<NodeObject>();

            foreach (var item in nodes)
            {
                if (item.Neighbours.Contains(node))
                    item.Neighbours.Remove(node);
            }

            idMap.Remove(node.Id);
        }
    }

    public enum NodeType
    {
        Movement = 0,
        Interaction
    }
}