using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour {

	public float turnSpeed = 0.5f;
	public float maxAngle = 30f;

	private float angle = 0;
	private float dir = 1;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameManager.instance.paused == true)
			return;
		
		if (dir == 1) {
			if (angle < maxAngle)
				angle += turnSpeed;
			else
				dir = -1;
		} else {
			if (angle > -maxAngle)
				angle -= turnSpeed;
			else
				dir = 1;
		}
		transform.rotation = new Quaternion(0,0, angle * Mathf.Deg2Rad ,1);
	}
}
