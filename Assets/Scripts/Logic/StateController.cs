using UnityEngine;

public class StateController : MonoBehaviour
{
    public GameState InitialState;
    public GameState CurrentState;

    void Start()
    {
        ChangeState(this.InitialState);
    }

    public void ChangeState(GameState newState)
    {
        if (newState == null)
            return;

        newState.TriggerEvents();
    }

}
