using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float MinX, MaxX, MinY, MaxY;
	public Vector2 Speed;
	public Transform _transform;

	public void Awake()
	{
		_transform = GetComponent<Transform>();
	}

	private void Update() 
	{
		Vector3 Offset = Speed * Time.deltaTime;

		_transform.Translate(Offset);    	
	}
}
