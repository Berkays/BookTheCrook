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
        base.OnClick();

        if (Selected)
            Selected = false;
        else
            Selected = true;
    }
}
