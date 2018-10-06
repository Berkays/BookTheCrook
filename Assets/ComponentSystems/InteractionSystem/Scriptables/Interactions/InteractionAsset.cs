using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interaction Data", menuName = "Custom Assets/Interaction/Interaction", order = 1)]
public class InteractionAsset : ScriptableObject
{
	public string Name;
	public string Information;
    public string OpponentInformation;
    public int Cooldown;
	public int MovementCost;

	public Player_Type PlayerType;
}

public enum Player_Type
{
	Cop = 0,
	Thief,
	Neutral
}
