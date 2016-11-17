using UnityEngine;
using System.Collections;

public class GameOverScoreManager : MonoBehaviour {
	//private int score	// Use this for initialization

	public static int score;
	void Start () {
		
	
	}

	void Awake () {
		//DontDestroyOnLoad(transform.gameObject);
	}

	public void Set(int s) {
		score = s;
	}

	public int Get() {
		return score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
