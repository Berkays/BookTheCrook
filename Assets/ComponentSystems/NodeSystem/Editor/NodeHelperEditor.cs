using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NodeSystem.Development
{
    [CustomEditor(typeof(NodeHelper))]
    public class NodeHelperEditor : Editor
    {
        [MenuItem("Node System/Connect Nodes")]
        public static void Connect()
        {
            var selectedNodes = Selection.gameObjects.Where(n => n.GetComponent<NodeObject>() != null).Select(n => n.GetComponent<NodeObject>()).ToArray();

            if (selectedNodes.Length < 2)
                return;

            var nodeHelper = FindObjectOfType<NodeHelper>();
            if (nodeHelper != null)
            {
                nodeHelper.Connect(selectedNodes);

                Debug.Log("Connected selected nodes");
            }
        }

        [MenuItem("Node System/Disconnect Nodes")]
        public static void Disconnect()
        {
            var selectedNodes = Selection.gameObjects.Where(n => n.GetComponent<NodeObject>() != null).Select(n => n.GetComponent<NodeObject>()).ToArray();

            if (selectedNodes.Length < 2)
                return;

            var nodeHelper = FindObjectOfType<NodeHelper>();
            if (nodeHelper != null)
            {
                nodeHelper.Disconnect(selectedNodes);

                Debug.Log("Disconnected selected nodes");
            }
        }

        [MenuItem("Node System/Disconnect All Nodes")]
        public static void DisconnectAll()
        {
            var nodes = FindObjectsOfType<NodeObject>();

            if (nodes.Length == 0)
                return;

            Undo.RecordObjects(nodes, "Disconnect All nodes");
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].Neighbours.Clear();
            }

            Debug.Log("Disconnected all nodes");
        }

        [MenuItem("Node System/Create Connected Movement Node")]
        public static void CreateConnectedMovement()
        {
            var selectedNode = Selection.activeGameObject.GetComponent<NodeObject>();

            if (selectedNode == null)
                return;

            var nodeHelper = FindObjectOfType<NodeHelper>();
            if (nodeHelper != null)
            {
                var obj = nodeHelper.CreateNode(NodeType.Movement);
                var objComponent = obj.GetComponent<NodeObject>();

                nodeHelper.Connect(selectedNode, objComponent);

                Selection.activeGameObject = obj;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var t = target as NodeHelper;

            if (GUILayout.Button("Rebuild helper node map"))
                t.BuildMap();

            foreach (var item in t.typeMap)
            {
                if (GUILayout.Button($"Create {item.Key.ToString()}"))
                {
                    t.CreateNode(item.Key);
                }
            }
        }

    }
}