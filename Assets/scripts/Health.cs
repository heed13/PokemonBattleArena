using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EZ_Pooling;
using System;
using UnityEngine.Events;


public class Health : MonoBehaviour 
{
	// HP Vars
	public float currentHP;
	public float totalHP;

	// Type Vars
	public List<pokemonType> weakAgainst;
	public List<pokemonType> resistantTo;
	private float weaknessMultiplier = 2.0f;
	private float resistanceMultiplier = 0.5f;

	// HUD Vars
	public UIBarScript bar;
	public bool tracksObj;

	// Floating Text Vars
	public Transform FloatingTextPrefab;

	// OnKill/ OnHit events
	[System.Serializable]
	public class HPEventType : UnityEvent<HitInfo> { } // event type for a succesful hit/kill
	public HPEventType onHit; // triggered when this character hits something
	public HPEventType onKill; // triggered when this character kills something

	// Anim Vars
	private Animator anim;
	private const string animKilledTrigger = "killed";


	void Awake()
	{
		anim = GetComponent<Animator> ();
		anim.logWarnings = false;
	}

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
		anim.SetTrigger (animKilledTrigger);
		GetComponent<Collider2D> ().enabled = false;
		Invoke ("SetActive", 2.0f);
		HideBar ();
	}

	void SetActive()
	{
		gameObject.SetActive (false);
	}
		

	IEnumerator FlashOnHit()
	{
		Renderer r = GetComponent<Renderer> ();
		r.material.color = Color.red;
		yield return new WaitForSeconds (0.1f);
		r.material.color = Color.white;
	}


	// -------- Public Functions --------
	public void TakeDamage(AttackInfo atk)
	{
		HitInfo hitInfo = new HitInfo(); // Create new hitInfo to pass back to attacker
		float appliedDmg = atk.damage;

		// Figure out weaknesses
		if (weakAgainst.Contains(atk.type)) {
			appliedDmg *= weaknessMultiplier;
			hitInfo.weaknessDmg = appliedDmg - atk.damage;
		} // Figre out Resitances
		else if (resistantTo.Contains(atk.type)) {
			appliedDmg *= resistanceMultiplier;
			hitInfo.weaknessDmg =  atk.damage - appliedDmg;
		}

		// Set total DMG
		hitInfo.totalDmgDealt = appliedDmg;
		
		// Apply damage
		currentHP -= appliedDmg;

		// Let others know -- display stuff and whatnot
		UpdateBar ();
		SoundPlayer.soundPlayer.playSound (atk.hitSoundKey, transform.position);
		atk.hitCallback (hitInfo);
		onHit.Invoke (hitInfo);
		ShowFloatingText (appliedDmg);
		StartCoroutine ("FlashOnHit");

		// Check Death
		if (currentHP <= 0) {
			
			// Set vars, call onHit of attacker
			currentHP = 0;
			hitInfo.killed = true;
			atk.killCallback (hitInfo);
			onKill.Invoke (hitInfo);

			// End our misery
			Die ();
		}
	}
}
