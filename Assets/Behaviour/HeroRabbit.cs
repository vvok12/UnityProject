using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour {

	public float speed = 3.0f;
	public float jumpSpeed = 2;
	public float jumpMaxTime = 2;

	private float jumpTime = 0;

	private Rigidbody2D myRB = null;
	private SpriteRenderer mySR = null;
	private Animator myA = null;
	// Use this for initialization
	void Start () {
		//init variables
		myRB = this.GetComponent<Rigidbody2D>();
		mySR = this.GetComponent<SpriteRenderer> ();
		myA = this.GetComponent<Animator> ();
		//freeze rotation
		myRB.freezeRotation = true;
		//remember start position
		Vector3 myVec = this.transform.position;
		LevelController.current.SetStartPosition (myVec);
	}


	//private int action=0;

	private bool isGrounded (){
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			return true;
		}
		return false;
	}

	private void tryJump(){

		jumpTime+=Time.deltaTime;
		if (jumpTime < jumpMaxTime) {
			Vector2 vel = myRB.velocity;
			vel.y = jumpSpeed * (1.0f - jumpTime / jumpMaxTime);
			myRB.velocity = vel;
		}
	}

	void FixedUpdate () {
		float runvalue = Input.GetAxis ("Horizontal");
		int action = 0;
		bool isGroundedVar = isGrounded ();
		if (Input.GetButton ("Jump")) {
			if (isGroundedVar) {
				jumpTime = 0.0f;
			}
			tryJump ();

		}
		if (!isGroundedVar)
			action = 2;
		
		if (Mathf.Abs (runvalue) > 0) {
			Vector2 vel = myRB.velocity;
			vel.x = runvalue * speed;
			myRB.velocity = vel;

			if (action==0)
				action = 1;
		}

		myA.SetInteger ("action", action);

		if(runvalue < 0) {
			mySR.flipX = true;
		} else if(runvalue > 0) {
			mySR.flipX = false;
		}
	}
}
