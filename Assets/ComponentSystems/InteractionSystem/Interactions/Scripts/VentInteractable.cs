using UnityEngine;

using NodeSystem;

public class VentInteractable : Interactable
{
    public VentInteractable ExitVent; //Endpoint
    public NodeObject ExitMovementNode;

    void setCooldown()
    {
        //Set both vents cooldown
        this.Cooldown = InteractionAsset.Cooldown; 
        ExitVent.Cooldown = InteractionAsset.Cooldown;
    }

    bool isInteractionReady()
    {
        return this.Cooldown == 0;
    }


    public override void Highlight()
    {
        var touchComponent = GetComponent<Touchable>();

        if (isInteractionReady())
        {
            //Higlight red
            touchComponent.AcceptInput = false;
        }
        else
        {
            //Higlight blue
            touchComponent.AcceptInput = true;
        }
    }

    public override void Interact(PlayerVariable player)
    {
        if (!isInteractionReady())
            return;

        setCooldown();

        Debug.Log("Interacted with vent");
        var actionController = FindObjectOfType<ActionController>();
        actionController.Interact(0);
        actionController.MovePlayer(ExitVent.ExitMovementNode.Id);
    }

}
