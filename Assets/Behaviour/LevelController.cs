using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;

	private Vector3 startPos;


	void Awake() {
		current = this;
	}

	public void OnRabbitDeath(HeroRabbit rb){
		//throw new UnityException ();
		Transform rbt = rb.transform;
		rbt.position = this.startPos;
		//rbt.rotation.SetLookRotation (Vector3 (0, 0, 0));
		//rbt. = Vector3(0,0,0);
		//rbt.eulerAngles.x =0;
		//rbt.eulerAngles.y =0;
		//rbt.eulerAngles.z =0;
	}

	public void SetStartPosition (Vector3 sp){
		startPos.x = sp.x;
		startPos.y = sp.y;
	}
}
