using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game Manager { get; private set;  }
	public int Lives;
	public int Score;
	public Paddle PlayerPaddle;
	public bool IsDead = true;

	//public bool IsDead {
	//	get {
	//		return _isDead;
	//	}

	//	set {
	//		_isDead = value;
	//	}
	//}

	void Awake () {
		if (Manager != null) {
			Destroy(gameObject);
			return;
		}

		Manager = this;
	}

	public void AddScore(int change) {
		Score += change;
	}
	
}
