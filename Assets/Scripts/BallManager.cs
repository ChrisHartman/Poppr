using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour {
	public GameObject BallPrefab;

	public event Action PoppedCorrectColor = delegate { };
	public event Action PoppedIncorrectColor = delegate { };
	private AudioSource PoppingSound;

	private Color[] BallColors = {
		new Color32(145, 233, 255, 0xFF),
		new Color32(255, 145, 145, 0xFF), 
		new Color32(255, 233, 145, 0xFF),  
		new Color32(189, 255, 145, 0xFF), 
	};
	public GameObject Ball;
	private int ballColor;
	private int oldColor;
	private int repeatCount;
	private bool needNewBall;
	private float newBallTime;

	void Start () {
		PoppingSound = GetComponent<AudioSource>();
		needNewBall = false;
		Invoke("NewBall", 1f);
		repeatCount = 0;
	}

	void Awake () {
		Ball = Instantiate(BallPrefab);
	}
	
	void Update () {
		if (needNewBall && newBallTime < Time.time) {
			NewBall();
		}
	}

	void NewBall() {
		Ball.SetActive(true);
		Ball.transform.position = new Vector3(0,0,0);
		Ball.GetComponent<Rigidbody2D>().velocity = new Vector3(0,7,0);	
		oldColor = ballColor;
		ballColor = UnityEngine.Random.Range(0,BallColors.Length);
		if (ballColor == oldColor) {
			repeatCount++;
		} else {
			repeatCount = 0;
		}
		if (repeatCount > 0) {
			while (ballColor == oldColor) {
				ballColor = UnityEngine.Random.Range(0,BallColors.Length);
			}
		}
		Ball.GetComponent<SpriteRenderer>().color = BallColors[ballColor];
		needNewBall = false;
	}

	public void Die() {
		Ball.transform.position = new Vector3(-1000,-1000, 0);
	}
	public void Revive() {
		Ball.gameObject.SetActive(true);
		Debug.Log("waking up!");
		//NewBall();
	}

	void OnTriggerExit2D(Collider2D other)
	{
		int colorPopped = (int)(FindObjectOfType<SpikeBallController>().transform.eulerAngles.z / 90);
		if (ballColor == colorPopped) {
			PoppedCorrectColor();
			newBallTime = Time.time;

		} else {
			PoppedIncorrectColor();
			Ball.SetActive(false);
			newBallTime = Time.time + .1f;
		}
		if (!(FindObjectOfType<ScoreManager>().LifeCount() < 0)) {
				needNewBall = true;
		}
	}

}
