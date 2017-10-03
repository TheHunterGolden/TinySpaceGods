﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;

public class Movement : NetworkBehaviour {

	private Animator _animator;
	NavMeshAgent agent;
	public float maxSpeed;
	public Vector3 target;
	public Vector3 targetBullet;
	//variables for the players local velocity
	private Vector3 direction;          
	Vector3 localDirection;     
	float localDirectionZ;    
	float localDirectionX;        
	Vector3 lastPosition;     


	// Use this for initialization
	void Start () {
		target = new Vector3 (11, 11, 11);
		maxSpeed = 10;
		_animator = GetComponentInChildren<Animator> ();
		agent = GetComponent<NavMeshAgent>();
		InvokeRepeating("FindVelocity",0,0.1f);

	}
	
	// Update is called once per frame
	void Update () {


		//if (!isLocalPlayer) {
		//	return;
		//}


		if (_animator == null) {
			return;
		}
		//code to turn player towards mouse
		RaycastHit hit1;

		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit1, 1000)) {
			gameObject.transform.LookAt (new Vector3 (hit1.point.x, transform.position.y, hit1.point.z));

		}
		//target = new Vector3(hit1.point.x, transform.position.y, hit1.point.z);
		targetBullet = new Vector3(hit1.point.x, hit1.point.y, hit1.point.z);
		target = new Vector3(hit1.point.x, transform.position.y, hit1.point.z);
		var x = Input.GetAxis ("Horizontal");
		var y = Input.GetAxis ("Vertical");

		Move (x, y);
	}
	//function to move the player

	private void Move(float x, float y) {
	
		_animator.SetFloat ("VelX", localDirectionX);
		_animator.SetFloat ("VelY", localDirectionZ);


		transform.Translate (maxSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime * -1, 0f, maxSpeed * Input.GetAxis ("Vertical") * Time.deltaTime * -1, Space.World);
	
	}


	//finds the player velocity
	private void FindVelocity()
	{
		direction =      transform.position - lastPosition;
		localDirection =    transform.InverseTransformDirection(direction);
		localDirectionZ =    Mathf.Clamp(transform.InverseTransformDirection(direction).z,-1,1);
		localDirectionX =    Mathf.Clamp(transform.InverseTransformDirection(direction).x,-1,1);
		lastPosition =      transform.position;
	}


}
