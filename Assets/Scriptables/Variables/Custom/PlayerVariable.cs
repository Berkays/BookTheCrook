using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Variable", menuName = "Variables/Player", order = 1)]
public class PlayerVariable : ScriptableObject
{
    [SerializeField]
    public Player Value;
}
