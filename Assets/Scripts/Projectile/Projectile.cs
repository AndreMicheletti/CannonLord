using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

	public LayerMask ignoreLayers;

	public float speed = 1f;
	public int damageDealt = 1;

	public GameObject explodeEffect;

	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if (GameManager.instance.paused == false)
			updateProjectile ();
	}

	protected abstract void updateProjectile ();

	protected virtual void destroyProjectile () {
		if (explodeEffect != null)
			GameObject.Instantiate (explodeEffect, transform.position, Quaternion.identity);

		Destroy (gameObject);
	}

	protected abstract void Rotate();

	protected virtual void Move() {
		transform.position += (transform.up * Time.deltaTime * speed);
	}

	protected void OnTriggerEnter2D(Collider2D other) {
		
		// Ignorar se a camada do outro objeto estiver nas camadas ignoradas
		if (ignoreLayers == (ignoreLayers | (1 << other.gameObject.layer)))
			return;

		// Não colidir com objetos marcados como Bullet
		if (other.gameObject.tag == "Bullet")
			return;

		// Se o outro objeto for um inimigo
		if (other.gameObject.tag == "Enemy") {
			
			other.gameObject.GetComponent<Enemy> ().hit (damageDealt);
			destroyProjectile ();

		} else {
			
			destroyProjectile ();

		}
	}
}
