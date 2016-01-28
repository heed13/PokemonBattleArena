using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class AttackController : MonoBehaviour {

	public GameObject projectile;
	public float attackDelay = 0.5f;
	public int poolAmount = 20;

	[System.Serializable]
	public class MyEventType : UnityEvent<Attack> { }
	public MyEventType onHit;
	public MyEventType onKill;

	private int teamId;
	private Rigidbody2D rb;
	private List<GameObject> projectiles;
	private float nextAttack = 0;
	private Animator anim;
	private bool attacking = false;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		teamId = GetComponent<TeamMember> ().teamId;

		projectiles = new List<GameObject> ();
		for (int i = 0; i < poolAmount; i++) {
			GameObject obj = (GameObject)Instantiate (projectile);
			obj.GetComponent<Projectile> ().teamId = teamId;
			obj.SetActive (false);
			projectiles.Add (obj);
		}
	}
	void Update()
	{
		if (attacking)
			NormalAttack ();
	}


	public void SetAttacking(bool val)
	{
		anim.SetBool ("attacking", val);
		attacking = val;
	}

	public void NormalAttack()
	{
		if (Time.time >= nextAttack) {
			nextAttack = Time.time + attackDelay;

			// get mouse pos
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 vec = new Vector2 (mousePos.x, mousePos.y) - new Vector2 (transform.position.x, transform.position.y);
			float deg = Mathf.Atan2 (vec.y, vec.x) * Mathf.Rad2Deg - 90;

			for (int i = 0; i < projectiles.Count; i++) {
				if (!projectiles [i].activeInHierarchy) {
					projectiles [i].transform.position = transform.position;
					projectiles [i].transform.eulerAngles = new Vector3 (0, 0, deg);
					projectiles [i].GetComponent<Attack> ().Attacker = gameObject;
					projectiles [i].GetComponent<Attack> ().hitCallback = onhitCallback;
					projectiles [i].GetComponent<Attack> ().deathCallback = onKillCallback;
					projectiles [i].SetActive (true);
					break;
				}
			}
		}
	}

	public void onhitCallback(Attack atk)
	{
		onHit.Invoke (atk);
	}
	public void onKillCallback(Attack atk)
	{
		onKill.Invoke (atk);
	}
}
