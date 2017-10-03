using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ablities : MonoBehaviour {

	public Texture2D abilityIcon;
	public GameObject flameAura;
	public float ability1CoolDown;
	public float ability1CoolDownTimer;
	public float energyCost;
	// Use this for initialization
	void Start () {
		energyCost = 80;
	}
	
	// Update is called once per frame
	void Update () {

		bool AB1 = Input.GetKeyDown (KeyCode.Alpha1);

		if (ability1CoolDownTimer > 0) {
			
			ability1CoolDownTimer -= Time.deltaTime;

		}

		if (ability1CoolDownTimer < 0) {
		
			ability1CoolDownTimer = 0;
			Debug.Log ("Ability off cooldown");

		}

		if ((AB1 && (ability1CoolDownTimer == 0)) && gameObject.GetComponent<PlayerStats>().canUseSpell(energyCost)) {
			Ability1 ();
			ability1CoolDownTimer = ability1CoolDown;
		} 
	}

	void OnGUI () {

		GUI.DrawTexture (new Rect (50, 350, abilityIcon.width/4, abilityIcon.height/4), abilityIcon);

	}

	void Ability1 () {
		
		GameObject myFlameAura = (GameObject) Instantiate (flameAura, transform.position, flameAura.transform.rotation);
		FlameAuraAbility flameAuraScript = myFlameAura.GetComponent<FlameAuraAbility> ();
		flameAuraScript.myOwner = this.gameObject;

	}
}
