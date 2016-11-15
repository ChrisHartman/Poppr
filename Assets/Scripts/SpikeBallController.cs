using UnityEngine;
using System.Collections;

public class SpikeBallController : MonoBehaviour {
	public KeyCode right;
	public KeyCode left;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKey(right) || ((Input.touchCount == 1) && Input.GetTouch(0).position.x > Screen.width/2)) {
		if (Input.GetKey(left) || ((Input.touchCount == 1) && Input.GetTouch(0).position.x < Screen.width/2)) {
			rb.AddTorque(200*Time.deltaTime);
		}
		if (Input.GetKey(right) || ((Input.touchCount == 1) && Input.GetTouch(0).position.x > Screen.width/2)) {
			rb.AddTorque(-200*Time.deltaTime);
		}
	}
}
