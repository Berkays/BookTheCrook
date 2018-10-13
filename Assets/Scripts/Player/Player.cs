using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isLocalPlayer = false;

    public int CurrentNode { get; set; }

    public void Initialize()
    {
        //Set position on spawn point
        //this.transform.position = NodeManager.Instance.GetPosition(this.CurrentNode);
    }

}
