using UnityEngine;

public class Touchable : MonoBehaviour
{
    public bool AcceptInput = true;

    public InputGroup InputType; //Set in inspector
    public InputPath CurrentPath; //Set in inspector

    public InputAction[] InputActions;

    public virtual void OnClick()
    {
        //if (!AcceptInput)
        //    return;

        //Add to current path
        bool isAdded = CurrentPath.Add(this.InputType);

        if (isAdded)
        {
            foreach (var inputAction in InputActions)
            {
                if (CurrentPath.Match(inputAction.Path))
                    inputAction.Action.Invoke();
            }

            //bool clearPath = InputActions.Any(n => n.Path.ClearAfterInvoke == true);

            //if (clearPath)
            //{
            //    FindObjectOfType<InputController>().DeselectAllObjects();
            //    CurrentPath.Clear();
            //}

        }
        else
        {
            //Deselect
            CurrentPath.RemoveLast();
        }

    }
}
