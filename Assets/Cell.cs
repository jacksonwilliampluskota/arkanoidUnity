using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

	public int Bounty = 10;
	public void WasHit()
	{
		GetComponent<Collider>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = false;

		Game.Manager.AddScore(Bounty);
	}
}
