using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour {
	public GameObject BallPrefab;

	public event Action PoppedCorrectColor = delegate { };
	public event Action PoppedIncorrectColor = delegate { };

	private Color[] BallColors = {
		new Color32(145, 233, 255, 0xFF),
		new Color32(255, 145, 145, 0xFF), 
		new Color32(255, 233, 145, 0xFF),  
		new Color32(189, 255, 145, 0xFF), 
	};
	GameObject Ball;
	private int ballColor;
	private bool needNewBall;

	//GameObject[] Balls = new GameObject[4];
	// {{189, 255, 145}, {255, 233, 145}, {255, 145, 145}, {145, 233, 255}}
	// Use this for initialization
	void Start () {
		// for (int i = 0; i < Balls.Length; i++) {
		// 	Balls[i] = Instantiate(BallPrefab);
		// 	Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector3(0,5,0);
		// 	Balls[i].SetActive(false);
		// 	Balls[i].GetComponent<SpriteRenderer>().color = BallColors[i];
		// }
		// NewBall();
		Ball = Instantiate(BallPrefab);
		needNewBall = false;
		Invoke("NewBall", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (needNewBall && Time.timeScale > 0) {
			NewBall();
		}
	}

	void NewBall() {
		Ball.transform.position = new Vector3(0,0,0);
		Ball.GetComponent<Rigidbody2D>().velocity = new Vector3(0,7,0);	
		ballColor = UnityEngine.Random.Range(0,BallColors.Length);
		Ball.GetComponent<SpriteRenderer>().color = BallColors[ballColor];
		needNewBall = false;
	}
	/// Sent when another object leaves a trigger collider attached to
	/// this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerExit2D(Collider2D other)
	{
		int colorPopped = (int)(FindObjectOfType<SpikeBallController>().transform.eulerAngles.z / 90);
		// print(string.Format("Popped = {0}, Color = {1}",colorPopped, ballColor));
		if (ballColor == colorPopped) {
			PoppedCorrectColor();
		} else {
			PoppedIncorrectColor();
		}
		needNewBall = true;


	}

}
