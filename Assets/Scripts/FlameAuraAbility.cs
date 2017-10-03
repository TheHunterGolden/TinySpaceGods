using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlameAuraAbility : NetworkBehaviour {


	public GameObject myOwner;
	public GameObject bomb;
	public float duration;
	float timer;

	bool noBomb;
	GameObject newBomb;
	private float currentDamage;
	 
	// Use this for initialization
	void Start () {
		
		currentDamage = myOwner.GetComponent<PlayerStats> ().getDamage ();
		timer = duration;
		noBomb = true;
		myOwner.GetComponent<PlayerStats> ().setDamage (currentDamage / 2);
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer - Time.deltaTime;

		transform.position = myOwner.transform.position;

		if ((timer < .75) && noBomb) {
			
			newBomb = (GameObject) Instantiate (bomb, myOwner.transform.position, bomb.transform.rotation);
			noBomb = false;
		}
		if (newBomb != null) {
		
			newBomb.transform.position = myOwner.transform.position;
		
		}

		if (timer <= 0) {
			
			Death ();
		}
	}

	public void Death() {
		Destroy (gameObject);
		if (newBomb != null) {
		
			Destroy (newBomb);
		
		}
		myOwner.GetComponent<PlayerStats> ().setDamage (-1 * (currentDamage / 2));
	}
}
