using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Networking;
using UnityEngine.Networking;
using UnityEngine.AI;

public class MinionAI : NetworkBehaviour {

	public Transform target;
	Vector3 destination;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		destination = agent.destination;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (destination, target.position) > 1.0f) {
		
			destination = target.position;
			agent.destination = destination;

		}
	}
}
