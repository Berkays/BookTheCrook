using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Input Set", menuName = "Custom Assets/Input/Set", order = 1)]
public class InputSet : ScriptableObject
{
    [SerializeField]
    public List<InputPath> InputPaths;
}
