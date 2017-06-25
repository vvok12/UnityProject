using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : Collectable {
	protected override void OnRabitHit(HeroRabbit rabit){
		this.CollectedHide ();
	}
}
