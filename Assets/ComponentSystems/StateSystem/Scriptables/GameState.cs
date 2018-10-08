using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Custom Assets/State/New State", order = 1)]
public class GameState : ScriptableObject
{
    public List<GameEvent> StateEvents;
  
    public void TriggerEvents()
    {
        foreach (var @event in StateEvents)
        {
            @event.Raise();
        }
    }

}
