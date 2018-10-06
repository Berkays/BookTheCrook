using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ShowDistance : Editor
{
    [MenuItem("Tools/Show Distance")]
    public static void ShowDistanceObjects()
    {
        var selection = Selection.gameObjects.Take(2).ToArray();

        Debug.Log(Vector3.Distance(selection[0].transform.position, selection[1].transform.position));
    }
}
