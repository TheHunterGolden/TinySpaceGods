using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Networking;
using UnityEngine.Networking;

public class MinionManager : NetworkBehaviour {

	public float timer;
	public float counter;
	public GameObject minion;
	public Transform[] spawnPoints;

	void Start () {

		counter = 30;
		Transform[] spawnPoints = GetComponentsInChildren<Transform> ();
		timer = 0;

	}

	public void OnStartServer() {
		//Transform[] spawnPoints = GetComponentsInChildren<Transform> ();
		//counter = 30;
		//timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		counter -= Time.deltaTime;
		if (counter <= 0) {
			spawnMinions ();
			counter = 30;
		}
	}

	public void spawnMinions() {
		
		foreach (Transform child in transform) {
			Instantiate (minion, child.position, transform.rotation);	
		}
			//GameObject newMinion = (GameObject)Instantiate (minion, spawnPoint);
			//Instantiate (minion, spawnPoint);	
			

	}
}
