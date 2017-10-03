using UnityEngine;
using System.Collections;

using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerStats : NetworkBehaviour {


	[Tooltip("Object to be fired")]
	public GameObject bullet;
	public Transform tip;
	private float fire;
	private float fireCooldown;
	private Movement movementScript;
	//UI Stuff
	public RectTransform healthBar;

	//public float hp;
	public float damage;
	public float haste;
	public float armor;
	public float movementSpeed;
	public float energy;
	public float maxEnergy;
	public float rechargeRate;

	RaycastHit lastHit;


	void Start () {
		//fire = 0f;
		//hp = 1000.0f;
		//haste = 1.2f;
		//armor = 0;
		//movementSpeed = 10.0f;
		//maxEnergy = 400.0f;
		//energy = maxEnergy;
		//rechargeRate = 2;
		//fireCooldown = 0.2f;

	}

	public override void OnStartLocalPlayer()
	{
		movementScript = transform.GetComponent<Movement> ();
		//GetComponent<MeshRenderer>().material.color = Color.blue;
		Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
		fire = 0f;
		//hp = 1000.0f;
		haste = 1.2f;
		armor = 0;
		movementSpeed = 10.0f;
		maxEnergy = 400.0f;
		energy = maxEnergy;
		rechargeRate = 2;
		fireCooldown = 0.2f;

	}


	void Update () {

		if (!isLocalPlayer) {
			return;
		}
	

		if (energy < maxEnergy) {
			energy += rechargeRate * Time.deltaTime;
		} 
		if (energy > maxEnergy) {
			energy = maxEnergy;
		}

		//healthBar.sizeDelta = new Vector2 ( hp/10 , healthBar.sizeDelta.y);


		if (Input.GetMouseButtonDown (1) && (Time.time > (fire + fireCooldown))) {





			//if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out lastHit, 1500000)) {
				
				CmdFire ();

				fire = Time.time;
			
			//}
		}

		

		}
		

	public bool canUseSpell(float cost) {
		if ((energy - cost) >= 0) {
			return true;
		}
		Debug.Log ("You Don't Have Enough Energy Bro.");
		return false;
	}
	[Command]
	void CmdFire() {


		//transform.LookAt (hit.point + new Vector3(0, 2.5f));
		GameObject shot = (GameObject) Instantiate (bullet, tip.position, tip.rotation);
		Movement movementScript = GetComponent<Movement> ();
		shot.transform.LookAt (movementScript.targetBullet + new Vector3(0, 1.05f));

		//bulletScript.setTarget (new Vector3(transform.GetComponent<Movement>().target + new Vector3(0, 1.05f)));
		//shot.transform.LookAt(transform.GetComponent<Movement>().target);
		//shot.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
		//NetworkServer.Spawn(shot);
	
		// Add velocity to the bullet
		//shot.transform.Translate(Vector3.forward * 10 * Time.deltaTime,Space.Self);
		//Debug.Log (movementScript.target);
		// Destroy the bullet after 2 seconds
		Destroy(shot, 1.4f);
		//BulletBehavior bulletScript = shot.GetComponent<BulletBehavior> ();

		//bulletScript.setTarget (lastHit.point + new Vector3(0, 1.05f));
		//shot.transform.LookAt (lastHit.point + new Vector3(0, 1.05f));
		//NetworkServer.Spawn(shot);

		
	}



	public float getDamage () {
		return damage;
	}
	public float getHaste () {
		return haste;
	}
	public float getArmor () {
		return armor;
	}
	public float getMovespeed () {
		return movementSpeed;
	}
		
	public void setDamage (float amount) {
		damage = damage + amount;
	}
	public void setHaste (float amount) {
		haste = haste + amount;
	}
	public void setArmor (float amount) {
		armor = armor + amount;
	}
	public void setMovespeed (float amount) {
		movementSpeed = movementSpeed + amount;
	}

	public void setEnergy (float amount) {
		energy = energy + amount;
	}


		


}