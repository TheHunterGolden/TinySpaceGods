using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletBehavior : NetworkBehaviour {

	public float bulletSpeed;
	public float destroyTime;
	public float damage;
	public Vector3 target;
	// Use this for initialization

	void Start() {
		damage = 50.0f;
		//destroyTime = 3.0f;
		bulletSpeed = 20.0f;
	}
	public override void OnStartLocalPlayer () {
		
	}


	// Update is called once per frame
	void Update () {

		//transform.GetComponent<Rigidbody> ().AddForce (target);
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
		//Destroy(gameObject, destroyTime);

	}
	void OnCollisionEnter(Collision collision) {
		//if (!isLocalPlayer) {
		//	return;
		//}

		Destroy (gameObject);
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health != null) {
			health.TakeDamage (damage);
		} 
	}

	public void setTarget (Vector3 target) {
		//transform.LookAt (target);
	}
}
