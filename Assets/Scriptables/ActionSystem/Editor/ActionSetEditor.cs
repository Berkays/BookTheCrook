// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionSet))]
public class ActionSetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //GUI.enabled = Application.isPlaying;

        ActionSet e = target as ActionSet;
        if (GUILayout.Button("Fill"))
            e.TestFill();
        if (GUILayout.Button("Print"))
            e.Print();
    }
}