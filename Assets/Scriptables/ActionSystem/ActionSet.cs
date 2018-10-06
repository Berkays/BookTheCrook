using UnityEngine;
using System.Collections.Generic;

public class ActionSet : ScriptableObject
{
    [SerializeField]
    private List<PlayerAction> actionSet = null;

    public PlayerAction this[int index]
    {
        get { return this.actionSet[index]; }
    }

    public int Count
    {
        get
        {
            if (actionSet != null)
                return this.actionSet.Count;
            else
                return 0;
        }
    }

    public void Add(PlayerAction action)
    {
        if (this.actionSet == null)
            this.actionSet = new List<PlayerAction>();

        this.actionSet.Add(action);
    }

    public void RemoveLast()
    {
        if (this.actionSet.Count == 0)
            return;
        else
            this.actionSet.RemoveAt(this.actionSet.Count - 1);
    }

    public void RemoveAll()
    {
        this.actionSet.Clear();
    }

    public void TestFill()
    {
        PlayerAction moveAction = new PlayerAction(ActionType.MOVE, 1);
        PlayerAction moveAction2 = new PlayerAction(ActionType.MOVE, 5);
        PlayerAction moveAction3 = new PlayerAction(ActionType.MOVE, 4);
        PlayerAction iAction = new PlayerAction(ActionType.INTERACT, 2);
        PlayerAction iAction2 = new PlayerAction(ActionType.INTERACT, 1);

        this.Add(moveAction);
        this.Add(moveAction2);
        this.Add(moveAction3);
        this.Add(iAction);
        this.Add(iAction2);
    }

    public void Print()
    {
        var str = JsonUtility.ToJson(this, true);
        Debug.Log(str);
    }
}