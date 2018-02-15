using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GetButtonInput : MonoBehaviour
{
	public String ButtonName;
	public UnityEvent EventToFire;

	public void Update () {
		if (ButtonName == "")
			return;
		if (Input.GetButton(ButtonName))
			EventToFire.Invoke();
	}
}
