using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth;
	public float health;
	public float healthRegen;
	public RectTransform healthBar;

	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= maxHealth) {
			health = health + healthRegen;
		}
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0) {
			health = 0;
			Debug.Log ("Object is dead");
			Destroy (this.gameObject);
		}
		healthBar.sizeDelta = new Vector2 (health, healthBar.sizeDelta.y);
	}
}
