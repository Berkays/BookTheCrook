using UnityEngine;

[CreateAssetMenu(fileName = "New Interaction Data", menuName = "Custom Assets/Interaction/Interaction", order = 1)]
public class InteractionAsset : ScriptableObject
{
    public string Name;
    public string Information;
    public string OpponentInformation;
    public int Cooldown;
    public int MovementCost;
}
