using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isLocalPlayer = false;
    
    public Player_Type PlayerType;
    public int CurrentNode { get; set; }

    public void Initialize()
    {
        if (this.PlayerType == Player_Type.Cop)
            this.GetComponentInChildren<Renderer>().material.color = Color.blue;
        else if (this.PlayerType == Player_Type.Thief)
            this.GetComponentInChildren<Renderer>().material.color = Color.red;

        //Set position on spawn point
        //this.transform.position = NodeManager.Instance.GetPosition(this.CurrentNode);
    }

}
