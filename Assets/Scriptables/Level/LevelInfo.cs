using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Level Information", menuName = "Custom Assets/Level/Level Information", order = 1)]
public class LevelInfo : ScriptableObject
{
	public string LevelName;
	public int ThiefSpawnNode;
    public int CopSpawnNode;
}

