using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public InteractionAsset InteractionAsset;

    public int Cooldown;

    public abstract void Highlight();
    public abstract void Interact(PlayerVariable player);
}
