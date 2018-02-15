using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Wait : MonoBehaviour
{
    /// <summary> Wait time, in seconds </summary>
    public float Time;

    /// <summary> What to do once the timer expires </summary>
    public UnityEvent Callback;

	void Do ()
	{
	    StartCoroutine(WaitTime());
	}
	
	IEnumerator WaitTime () {
	    yield return new WaitForSeconds(Time);
	    Callback.Invoke();
	}
}
