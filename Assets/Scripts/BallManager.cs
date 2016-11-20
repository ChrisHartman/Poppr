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
	GameObject Ball;
	private int ballColor;
	private bool needNewBall;

	void Start () {
		PoppingSound = GetComponent<AudioSource>();
		Ball = Instantiate(BallPrefab);
		needNewBall = false;
		Invoke("NewBall", 1f);
	}
	
	void Update () {
		if (needNewBall) {
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

	public void Die() {
		Ball.gameObject.SetActive(false);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		int colorPopped = (int)(FindObjectOfType<SpikeBallController>().transform.eulerAngles.z / 90);
		if (ballColor == colorPopped) {
			PoppedCorrectColor();
		} else {
			PoppedIncorrectColor();
		}
		needNewBall = true;


	}

}
