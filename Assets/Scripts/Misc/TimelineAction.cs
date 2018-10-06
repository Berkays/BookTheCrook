using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineAction : MonoBehaviour
{

    public UnityEvent Action;

    void OnEnable()
    {
        if (Action != null)
            Action.Invoke();
    }
}
