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

    public void MovePlayer(int nodeId)
    {
        var nodeManager = FindObjectOfType<NodeManager>();

        CurrentPlayer.Value.CurrentNode = nodeId;
        CurrentPlayer.Value.transform.localPosition = nodeManager[nodeId].transform.localPosition;

        PlayerAction moveAction = new PlayerAction(ActionType.MOVE,nodeId);
        CurrentActionSet.Add(moveAction);

        OnActionChange.Raise();
    }

    public void Interact(int nodeId)
    {
        //var player = CurrentPlayer.Value;

        PlayerAction interactAction = new PlayerAction(ActionType.INTERACT,nodeId);
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
