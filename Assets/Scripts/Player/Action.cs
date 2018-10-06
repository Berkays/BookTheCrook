using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAction
{
	public ActionType ActionType;
    public int Value;

    public PlayerAction(ActionType actionType,int value)
    {
        this.ActionType = actionType;
        this.Value = value;
    }

    public override string ToString()
    {
        if (this.ActionType == ActionType.MOVE)
        {
            return "Move Player to Node " + this.Value;
        }
        else
        {
            return "Interact with object " + this.Value;
        }
    }
}

public enum ActionType
{
    MOVE = 0,
    INTERACT
}
