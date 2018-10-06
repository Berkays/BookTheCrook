using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game State", menuName = "Custom Assets/State/New Game State", order = 1)]
public class GameState : ScriptableObject
{
    public GameEvent OnStateEnterEvent;
    public GameEvent OnStateExitEvent;
    public void OnStateEnter()
    {
        if (OnStateEnterEvent != null)
            OnStateEnterEvent.Raise();
    }

    public void OnStateExit()
    {
        if (OnStateExitEvent != null)
            OnStateExitEvent.Raise();
    }
}
