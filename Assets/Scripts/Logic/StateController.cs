using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    public GameState State;
    public GameState InitialState;
    void Start()
    {
        ChangeState(this.InitialState);
    }
    public void ChangeState(GameState newState)
    {
        if (newState == null)
            return;
        if (this.State != null)
            this.State.OnStateExit();
            
        this.State = newState;
        this.State.OnStateEnter();
    }
}
