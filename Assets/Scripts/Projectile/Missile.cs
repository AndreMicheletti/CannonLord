using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile {

	public float turnSpeed = 20f;
	public int AutoDestroyTime = 300;

	private Transform target;
	private int autoDestroyTimer = 0;

	void Start () {
		StartCoroutine (getTarget());
	}

	override protected void updateProjectile () {
		if (autoDestroyTimer < AutoDestroyTime) {
			autoDestroyTimer += 1;
		} else {
			destroyProjectile ();
			return;
		}

		Move ();
		Rotate ();

		if (target == null) {
			StartCoroutine (getTarget());
		}
	}

	override protected void Rotate () {
		if (target != null) {
			float orotation = Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - target.position.y ,transform.position.x - target.position.x);
			Quaternion targetRotation = Quaternion.Euler(0,0,orotation+90);

			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, turnSpeed);
		}
	}

	IEnumerator getTarget() {

		float distance = Mathf.Infinity;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")) {
			
			if (obj == null)
				continue;
			
			var diff = (obj.transform.position - transform.position).sqrMagnitude;

			if (diff < distance) {
				distance = diff;
				target = obj.transform;
			}
			yield return new WaitForSeconds (0.5f);
		}
	}
}
