using UnityEngine;
using System.Collections;
using System;

public class Attack : MonoBehaviour {
	public CharacterInfo.characterTypes type;
	public float damage;
	public float totalDmgDone = 0;
	public GameObject Attacker; // TODO this needs to be redefined
	public Action<Attack> hitCallback;
	public Action<Attack> deathCallback;

}
