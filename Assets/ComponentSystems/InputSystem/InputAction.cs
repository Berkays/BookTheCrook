using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InputAction
{
	[SerializeField]
	public InputPath Path;

	public UnityEvent Action;
}
