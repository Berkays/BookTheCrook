using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAssigner : MonoBehaviour
{
    public PlayerVariable CurrentPlayer;

    public void Assign(PlayerVariable newCurrentPlayer)
    {
        this.CurrentPlayer.Value = newCurrentPlayer.Value;
    }
}
