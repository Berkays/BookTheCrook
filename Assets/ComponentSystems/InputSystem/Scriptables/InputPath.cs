using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Input Path", menuName = "Custom Assets/Input/Input Path", order = 1)]
public class InputPath : ScriptableObject
{
    [SerializeField]
    public List<InputGroup> Path;

    public bool ActionPath = true;
    public SelectableTouchable LastSelectable { get; set; }

    public InputGroup this[int index]
    {
        get
        {
            if (index < this.Path.Count && index >= 0)
                return this.Path[index];
            else
                return null;
        }
    }

    public bool Add(InputGroup inputGroup)
    {
        if (this.Path.Count == 0 || this.Path[this.Path.Count - 1] != inputGroup)
		{
            this.Path.Add(inputGroup);
			return true;
		}
		else
		{
			return false;
		}
    }

    public void RemoveLast()
    {
        if (this.Path.Count > 0)
            this.Path.RemoveAt(this.Path.Count - 1);
    }

	public void Clear()
	{
		this.Path.Clear();
	}
}

public static class InputPathExtension
{
    public static bool Match(this InputPath primaryPath, InputPath secondaryPath)
    {
        if (primaryPath.Path.Count != secondaryPath.Path.Count)
            return false;

        for (int i = 0; i < primaryPath.Path.Count; i++)
        {
            if (primaryPath.Path[i].name == "Any" || secondaryPath.Path[i].name == "Any")
                continue;
            if (primaryPath.Path[i] != secondaryPath.Path[i])
            {
                return false;
            }
        }

        return true;
    }
}



