using UnityEngine;

public class MovementMarker : MonoBehaviour
{
    public int NodeId;

    public void Move()
    {
        var actionController = FindObjectOfType<ActionController>();
        actionController.MovePlayer(this.NodeId);
    }
}

