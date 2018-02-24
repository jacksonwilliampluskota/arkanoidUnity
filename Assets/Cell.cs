using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

	internal void WasHit()
	{
		GetComponent<Collider>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = false;
	}
}
