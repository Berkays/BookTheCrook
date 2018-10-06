using UnityEngine;

using NodeSystem.Runtime;

public class ActionController : MonoBehaviour
{
    private ActionSet CurrentActionSet;

    public GameEvent OnActionChange;

    public PlayerVariable CurrentPlayer;

    public bool reset = false;

    void Start()
    {
        //Reset action set asset
        this.CurrentActionSet = ScriptableObject.CreateInstance<ActionSet>();
    }

    void Update()
    {
        if (reset == true)
        {
            this.CurrentActionSet.RemoveAll();
            OnActionChange.Raise();
        }
    }

    public void MovePlayer(int newNode)
    {
        var nodeManager = FindObjectOfType<NodeManager>();

        CurrentPlayer.Value.CurrentNode = newNode;
        CurrentPlayer.Value.transform.localPosition = nodeManager[newNode].transform.localPosition;

        PlayerAction moveAction = new PlayerAction(ActionType.MOVE,newNode);
        CurrentActionSet.Add(moveAction);

        OnActionChange.Raise();
    }

    public void Interact(int interactionId)
    {
        //var player = CurrentPlayer.Value;

        PlayerAction interactAction = new PlayerAction(ActionType.INTERACT,interactionId);
        CurrentActionSet.Add(interactAction);

        OnActionChange.Raise();
    }

    public void RevertLastAction()
    {
        this.CurrentActionSet.RemoveLast();

        OnActionChange.Raise();
    }

    public ActionSet GetActions()
    {
        return this.CurrentActionSet;
    }

    public void RevertActions()
    {
        //var reverseActions = this.actionSet.actionSet.Reverse();
    }

    public void PlayRemotePlayerActions()
    {

    }
}
