using UnityEngine;

[CreateAssetMenu(fileName = "Player Type", menuName = "Custom Assets/Player/Player Type", order = 1)]
public class PlayerType : ScriptableObject
{
    public string Name;
    public Color UIColor;
}
