using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeBlock : MonoBehaviour {
	public Image[] images = new Image[2];
	// Use this for initialization
	private Image image;
	private bool done;
	private int state;
	private float nudgeTime;
	private float waitTime = 3f;
	void Awake () {
		state = 0;
		foreach (Image i in images) 
			i.canvasRenderer.SetAlpha(0f);
		image = images[state];
		done = false;
	}
	void Start () {
		Invoke("FadeInAndOut", 1f);	
		FindObjectOfType<BallManager>().Die();
		nudgeTime = Time.time + waitTime + 1f;
	}

	void Update () {
		if (CheckForInput(state)) {
			nudgeTime = Time.time + waitTime + 1f;
			Debug.Log("Input!");
			state++;
			if (state > 1) {

				FindObjectOfType<BallManager>().Revive();
				Debug.Log("Wake up");
				return;
			}
			image = images[state];
			Invoke("FadeInAndOut", 1f);	
		} else if (Time.time > nudgeTime && state < 2) {
			FadeInAndOut();
			nudgeTime = Time.time + waitTime;
		}
	}

	void FadeInAndOut () {
		if (state < 2) {
 			FadeIn();
			Invoke("FadeOut", .5f);
			done = true;
		}
	}
	void FadeOut () {
		done = false;
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
