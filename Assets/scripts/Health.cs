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
	public CharacterInfo.characterTypes weakAgainst;
	public CharacterInfo.characterTypes resistantTo;
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
	void HideBar()
	{
		if (bar != null)
			bar.gameObject.SetActive (false);
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
		HideBar ();
	}
		
	void playHitSound(CharacterInfo.characterTypes type)
	{
		SoundPlayer.soundPlayer.playSound ("genericHurt", transform.position);
	}
	IEnumerator FlashOnHit()
	{
		Renderer r = GetComponent<Renderer> ();
		Color orig = r.material.color;
		r.material.color = Color.red;
		yield return new WaitForSeconds (0.1f);
		r.material.color = orig;
	}
	public void TakeDamage(Attack atk)
	{
		float appliedDmg = atk.damage;

		// Figure out weak/resistant
		if (atk.type == weakAgainst) {
			appliedDmg *= weaknessMultiplier;
		} else if (atk.type == resistantTo) {
			appliedDmg *= resistanceMultiplier;
		}

		// Apply damage
		currentHP -= appliedDmg;
		atk.totalDmgDone = appliedDmg;
		UpdateBar ();
		ShowFloatingText (appliedDmg);
		playHitSound (atk.type);
		StartCoroutine ("FlashOnHit");
		// Check Death
		if (currentHP <= 0) {
			// Kill object
			currentHP = 0;

			// Give exp
			atk.Attacker.GetComponent<Experience> ().gainExperience (GetComponent<Experience> ().dropExperience ());

			// End our misery
			Die ();
		}

		// Any callbacks the other player might have
		atk.hitCallback (atk);
		atk.deathCallback (atk);

	}
}
