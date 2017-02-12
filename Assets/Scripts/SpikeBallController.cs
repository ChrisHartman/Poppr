using UnityEngine;
using System.Collections;

public class SpikeBallController : MonoBehaviour {
	public float Torque = 175f;
	public KeyCode right, left;
	
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if (Input.GetKey(right) || ((Input.touchCount == 1) && Input.GetTouch(0).position.x > Screen.width/2)) {
		if (Input.GetKey(left) || ((Input.touchCount == 1) && Input.GetTouch(0).position.x < Screen.width/2)) {
			rb.AddTorque(Torque*Time.fixedDeltaTime); 
		}
		if (Input.GetKey(right) || ((Input.touchCount == 1) && Input.GetTouch(0).position.x > Screen.width/2)) {
			rb.AddTorque(-Torque*Time.fixedDeltaTime);
		}
	}
}
