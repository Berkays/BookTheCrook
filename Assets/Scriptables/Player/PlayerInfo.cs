using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Information", menuName = "Custom Assets/Player/Player Information", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public string Name;
    public Player_Type PlayerType;
}

