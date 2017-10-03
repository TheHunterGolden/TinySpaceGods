using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	private Animator anim;

	void Start() {

		anim = GetComponent<Animator> ();

	}

	void Update()
	{
		if (!isLocalPlayer) {
			return;
		}
		var x = Input.GetAxis ("Horizontal"); 
		var y = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(x, 0.0f, y);

		if (movement != Vector3.zero) {
			anim.SetBool ("speed", true);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (movement), 0.15F);
			transform.Translate (movement * 9.0f * Time.deltaTime, Space.World);
		}
		else {
			anim.SetBool ("speed", false);
		}

		bool swing = Input.GetButtonDown ("Fire1");
		anim.SetBool ("attack", swing);

	}

	public override void OnStartLocalPlayer()
	{
		
	}


}