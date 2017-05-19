using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabitBehaviour : MonoBehaviour {

	public float speed = 1.0f;

	private Rigidbody2D myRB = null;

	// Use this for initialization
	void Start () {
		myRB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
	//update is called once per frame
	void FixedUpdate () {
		float value = Input.GetAxis ("Horizontal");

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myRB.velocity;
			vel.x = value * speed;
			myRB.velocity = vel;
		}

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if(value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}
	}
}
