using System.Linq;

public class SelectableTouchable : Touchable
{
    public GameEvent OnSelectEvent;
    public GameEvent OnDeselectEvent;

    private bool _selected;
    public bool Selected
    {
        get
        {
            return _selected;
        }
        set
        {
            _selected = value;

            if (_selected)
            {
                if (OnSelectEvent != null)
                    OnSelectEvent.Raise();
            }
            else
            {
                if (OnDeselectEvent != null)
                    OnDeselectEvent.Raise();
            }
        }
    }

    public override void OnClick()
    {
        //base.OnClick();
        bool isAdded = CurrentPath.Add(this.InputType);

        if (!isAdded)
            CurrentPath.RemoveLast();


        if (Selected)
        {
            Selected = false;

            CurrentPath.LastSelectable = null;
        }
        else
        {
            Selected = true;

            CurrentPath.LastSelectable = this;
        }
    }
}
