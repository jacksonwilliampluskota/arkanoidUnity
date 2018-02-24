using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	public Vector3 StartDirection = new Vector3(0f,2f,0f);
	private Rigidbody _rb;

	void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetButton("Jump")  && Game.Manager.IsDead)
		{
			ApplyStartForce();
		}
	}

	void ApplyStartForce()
	{
		_rb.AddForce(StartDirection);
		Game.Manager.IsDead = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == Game.Manager.PlayerPaddle.gameObject)
			return;
		var cell = collision.gameObject.GetComponent<Cell>();

		if (cell == null)
			return;
		cell.WasHit();
		
	}
}
