using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeBlock : MonoBehaviour {
	public Image[] images = new Image[2];
	// Use this for initialization
	private Image image;
	private bool next;
	private int state;
	void Awake () {
		state = 0;
		foreach (Image i in images) 
			i.canvasRenderer.SetAlpha(0f);
		image = images[state];
		next = false;
	}
	void Start () {
		Invoke("FadeInAndOut", 1f);	
		FindObjectOfType<BallManager>().Die();
	}

	void Update () {
		if (CheckForInput(state)) {
			Debug.Log("Input!");
			state++;
			if (state > 1) {
				FindObjectOfType<BallManager>().Revive();
				Debug.Log("Wake up");
				return;
			}
			image = images[state];
			Invoke("FadeInAndOut", 1f);	
		}
	}

	void FadeInAndOut () {
		FadeIn();
		Invoke("FadeOut", .5f);
	}
	void FadeOut () {
		image.CrossFadeAlpha(0f, .5f, false);
	}
	void FadeIn () {
		image.CrossFadeAlpha(.2f, .3f, false);
	}
	
	// Update is called once per frame
	bool CheckForInput(int i) {
		if (i == 0) {
			return (Input.GetKey("left") || ((Input.touchCount == 1) && Input.GetTouch(0).position.x < Screen.width/2));
		}
		if (i == 1) {
			return (Input.GetKey("right") || ((Input.touchCount == 1) && Input.GetTouch(0).position.x > Screen.width/2));
		}
		else {
			return false;
		}
	}
}
