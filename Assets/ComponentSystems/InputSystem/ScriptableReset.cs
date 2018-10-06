using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableReset : MonoBehaviour
{
    public InputPath InputPath;

    void Start()
    {
        if (InputPath != null)
        {
            InputPath.Clear();
        }
    }

}
