using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public enum kAttackTypes {
		fire,
		water,
		etc,
		count
	}
	public kAttackTypes type;
	public float damage;
	public GameObject Attacker;
}
