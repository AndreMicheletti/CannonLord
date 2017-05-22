using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile {

	override protected void updateProjectile () {
		Move ();
	}

	override protected void Rotate() {

	}
}
