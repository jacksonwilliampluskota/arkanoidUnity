using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	public Vector3 StartDirection = new Vector3(0f,2f,0f);
	private Rigidbody _rb;

	private bool _collided;

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

	void FixedUpdate()
	{
		if (!_collided)
			return;
		//var ySpeedDiff = StartDirection.y - _rb.velocity.y;
		//_rb.velocity = new Vector3(0,0,0);
		var newY = (_rb.velocity.y > 0f) ? StartDirection.y : -StartDirection.y;
		_rb.AddForce(new Vector3(0, newY * 0.01f, 0f), ForceMode.VelocityChange);
		//_rb.velocity = new Vector3(_rb.velocity.x, newY * 0.01f, 0f);
		_collided = false;
	}

	void ApplyStartForce()
	{
		_rb.AddForce(StartDirection);
		Game.Manager.IsDead = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		_collided = true;
		if (collision.gameObject == Game.Manager.PlayerPaddle.gameObject)
			return;
		var cell = collision.gameObject.GetComponent<Cell>();

		if (cell == null)
			return;
		cell.WasHit();
	}
}
