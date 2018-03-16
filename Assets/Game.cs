using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public static Game Manager { get; private set;  }
	public int Lives;
	public Paddle PlayerPaddle;
	public bool IsDead = true;

	private int _score;
	public int Score {
		get { return _score;  }

		set
		{
			_score = value;
			if (ScoreTxt != null)
				ScoreTxt.text = "Score: " + Score;
		}
	}

	public Text ScoreTxt;

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
