using System.Collections;
using UnityEngine;

public class RemotePlayerReadyTrigger : MonoBehaviour
{
    public GameEvent RemotePlayerReadyEvent;

	public void StartTimer()
    {
        StartCoroutine(timer());
	}

    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);

        if (RemotePlayerReadyEvent != null)
            RemotePlayerReadyEvent.Raise();
    }
}
