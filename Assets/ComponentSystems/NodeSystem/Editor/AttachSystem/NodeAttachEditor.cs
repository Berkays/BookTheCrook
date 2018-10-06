using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NodeSystem.Development
{
    [CustomEditor(typeof(NodeAttachBehaviour), editorForChildClasses: true)]
    public class NodeAttachEditor : Editor
    {
        private bool isAttaching = false;



        private Vector3 LineEnd;
        private const float RAY_DISTANCE = 50f;

        private Vector3[] circlePoints;
        private Vector3 cachedPosition;
        private const float circleRadius = 0.2f;
        private const int stepSize = 90;

        private Collider lastHit = null;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Label($"Attaching: {isAttaching}");

            if (isAttaching)
            {
                if (GUILayout.Button("Stop Attaching"))
                {
                    isAttaching = false;
                }
            }
            else
            {
                if (GUILayout.Button("Start Attaching"))
                {
                    isAttaching = true;
                }
            }
        }

        void OnEnable()
        {
            SceneView.onSceneGUIDelegate += SceneGUI;
        }

        void SceneGUI(SceneView sceneView)
        {
            if (Event.current.button == 1)
            {
                if (isAttaching)
                {
                    if (lastHit != null)
                    {
                        var attachBehaviour = target as NodeAttachBehaviour;
                        var attachMade = attachBehaviour.Attach(lastHit.gameObject);

                        if (attachMade)
                            isAttaching = false;
                    }
                }
            }
        }

        void OnSceneGUI()
        {
            if (!isAttaching)
                return;

            var node = target as NodeAttachBehaviour;

            var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RAY_DISTANCE))
            {
                Handles.color = Color.yellow;
                LineEnd = hit.collider.transform.localPosition;
            }
            else
            {
                Handles.color = Color.white;
                LineEnd = ray.origin + (ray.direction * RAY_DISTANCE);
            }

            if (circlePoints == null || node.transform.localPosition != cachedPosition)
            {
                cachedPosition = node.transform.localPosition;
                circlePoints = getCirclePoints(node.transform.localPosition);
            }

            for (int i = 0; i < circlePoints.Length; i++)
            {
                Handles.DrawLine(circlePoints[i], LineEnd);
            }

            Handles.SphereHandleCap(0, LineEnd, Quaternion.identity, 0.1f, EventType.Repaint);

            if (lastHit == hit.collider)
            {

            }
            else
            {
                lastHit = hit.collider;
                SceneView.RepaintAll();
            }

        }

        private Vector3[] getCirclePoints(Vector3 origin)
        {
            int stepCount = 360 / stepSize;

            Vector3[] points = new Vector3[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                var angle = i * stepSize * Mathf.Deg2Rad;
                var x = Mathf.Cos(angle) * circleRadius;
                var y = Mathf.Sin(angle) * circleRadius;

                points[i] = new Vector3(x, y) + origin;
            }

            return points;
        }
    }
}