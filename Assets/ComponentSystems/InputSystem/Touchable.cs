using System.Linq;
using UnityEngine;

public class Touchable : MonoBehaviour
{
    public bool AcceptInput = true;

    public InputGroup InputType; //Set in inspector
    public InputPath CurrentPath; //Set in inspector

    public InputAction[] InputActions;

    public virtual void OnClick()
    {
        if (false && !AcceptInput)
            return;

        //Add to current path
        bool isAdded = CurrentPath.Add(this.InputType);

        if (isAdded)
        {

            var inputActions = InputActions.Where(n => CurrentPath.Match(n.Path)).ToArray();

            foreach (var inputAction in inputActions)
            {
                inputAction.Action.Invoke();
            }

            if (inputActions.Length > 0)
            {
                if (CurrentPath.LastSelectable != null)
                    CurrentPath.LastSelectable.Selected = false;

                CurrentPath.Clear();
            }

        }
        else
        {
            //Remove same element
            CurrentPath.RemoveLast();
        }

    }
}
