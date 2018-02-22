using UnityEngine;
using System.Collections;

public class MoveByInput : MonoBehaviour
{
	public float MinX, MaxX, MinY, MaxY;
	public string HorizontalAxis, VerticalAxis;
	public float Speed;
	public Transform _transform;
	public bool Local = true;

	public void Awake() 
	{
		if(_transform == null)
		{
			_transform = GetComponent<Transform>();
		}
	}

	private void Update() 
	{
		float horizontalOffset = 0f, verticalOffset = 0f;

		if (HorizontalAxis != "") {
			horizontalOffset = Input.GetAxis (HorizontalAxis) * Speed * Time.deltaTime;
			var desiredX = _transform.position.x + horizontalOffset;
			if (desiredX > MaxX) 
				horizontalOffset = MaxX - _transform.position.x;
			
			if (desiredX < MinX)
				horizontalOffset = MinX - _transform.position.x;
		}
			
		if (VerticalAxis != "") {
			verticalOffset = Input.GetAxis(VerticalAxis) * Speed * Time.deltaTime;
			var desiredY = _transform.position.y + verticalOffset;
			if (desiredY > MaxY) 
				verticalOffset = MaxY - _transform.position.y;
			
			if (desiredY < MinY)
				verticalOffset = MinY - _transform.position.y;
		}

		_transform.Translate(new Vector3(horizontalOffset, verticalOffset),
			Local? Space.Self : Space.World);        	
	}
}
