using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLeave : MonoBehaviour {

	// Use this for initialization
	void OnTriggerExit2D(Collider2D other) {
		Destroy (other.gameObject);
	}
}
