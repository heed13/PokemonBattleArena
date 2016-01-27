using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EZ_Pooling;
using System;


public class Health : MonoBehaviour {
	// HP Vars
	public float currentHP;
	public float totalHP;

	// Type Vars
	public Attack.kAttackTypes weakAgainst;
	public Attack.kAttackTypes resistantTo;
	private float weaknessMultiplier = 2.0f;
	private float resistanceMultiplier = 0.5f;

	// HUD Vars
	public UIBarScript bar;
	public bool tracksObj;

	// Floating Text Vars
	public Transform FloatingTextPrefab;




	void Start()
	{
		currentHP = totalHP;
	}
	void LateUpdate()
	{
		if (tracksObj) {
			TrackBar ();
		}
	}
	void UpdateBar()
	{
		if (bar != null)
			bar.UpdateValue ((int)currentHP, (int)totalHP);
	}
	void ShowFloatingText(float amount)
	{
		Transform obj = EZ_PoolManager.Spawn (FloatingTextPrefab, transform.position, Quaternion.identity);
		if (obj != null) {
			obj.GetComponentInChildren<TextMesh> ().text = amount.ToString ("0");
		}
	}
	void TrackBar()
	{
		var wantedPos = Camera.main.WorldToScreenPoint (transform.position);
		wantedPos.y += 25;
		bar.transform.position = wantedPos;
	}
	void Die()
	{
		gameObject.SetActive (false);
		bar.gameObject.SetActive (false);
	}
		
	public void TakeDamage(Attack atk)
	{
		Debug.Log ("taking dmg: " + atk.damage.ToString ());
		float appliedDmg = atk.damage;

		if (atk.type == weakAgainst) {
			appliedDmg *= weaknessMultiplier;
		} else if (atk.type == resistantTo) {
			appliedDmg *= resistanceMultiplier;
		}
		currentHP -= appliedDmg;
		UpdateBar ();
		ShowFloatingText (appliedDmg);
		if (currentHP <= 0) {
			currentHP = 0;
			Die ();
		}
	}
}
