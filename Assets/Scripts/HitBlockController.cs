using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HitBlockController : MonoBehaviour {
	private Image image;
	private bool gameOver;
	public bool practice;
	public float alpha;
	public float alphaincrementer;
	// Use this for initialization
	void Awake() {
		image = GetComponent<Image>();
		if (!gameOver) {
			image.canvasRenderer.SetAlpha(0f);
			var ballManager = FindObjectOfType<BallManager>();
			ballManager.PoppedIncorrectColor += FadeInAndOut;
		} else {
			image.canvasRenderer.SetAlpha(.5f);
		}
	}
	void Start () {
		if (!gameOver) {
			image.canvasRenderer.SetAlpha(0f);
		} else {
			image.canvasRenderer.SetAlpha(.5f);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FadeInAndOut () {
		// Debug.Log("Fading!");
		if (FindObjectOfType<ScoreManager>().LifeCount() > 0) {
			FadeIn();
			Invoke("FadeOut", .5f);
		} else {
			FadeInSlowly();
		}
		if(!practice) {

			alpha+=alphaincrementer;
		}
	}	
	void FadeOut () {
		image.CrossFadeAlpha(0f, .5f, false);
	}
	void FadeIn () {
		image.CrossFadeAlpha(alpha, .3f, false);
	}
	public void FadeInSlowly() {
		image.CrossFadeAlpha(alpha, 1f, false);
	}
	
}
