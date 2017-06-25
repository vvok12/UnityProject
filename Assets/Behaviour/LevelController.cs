﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;

	private Vector3 startPos;


	void Awake() {
		current = this;
	}

	public void OnRabbitDeath(HeroRabbit rb){
		Transform rbt = rb.transform;
		rbt.position = this.startPos;

	}

	public void SetStartPosition (Vector3 sp){
		startPos.x = sp.x;
		startPos.y = sp.y;
	}

	public static bool isOn(MonoBehaviour someone, string layer){
		Vector3 from = someone.transform.position + Vector3.up * 0.3f;
		Vector3 to = someone.transform.position + Vector3.up * 0.1f;

		Debug.DrawLine (from, to);

		int layer_id = 1 << LayerMask.NameToLayer (layer);
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			return true;
		}
		return false;
	}
	public static RaycastHit2D getPlatform(MonoBehaviour someone, string layer){
		Vector3 from = someone.transform.position + Vector3.up * 0.3f;
		Vector3 to = someone.transform.position + Vector3.up * 0.1f;

		Debug.DrawLine (from, to);

		int layer_id = 1 << LayerMask.NameToLayer (layer);
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		return Physics2D.Linecast(from, to, layer_id);

	}
	public static void SetParent(Transform obj, Transform new_parent){
		if (obj.transform.parent != new_parent) {
			Vector3 pos = obj.transform.position;
			obj.transform.parent = new_parent;
			obj.position = pos;
		}
	}

}
