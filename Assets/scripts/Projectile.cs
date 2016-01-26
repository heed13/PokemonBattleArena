using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed = 5;
	public Rigidbody2D rb;

	public int teamId;
	private bool expired = false; // used so that only 1 hit occurs

	// Update is called once per frame
	void OnEnable ()
	{
		rb.AddForce (transform.up * speed * 10);
		expired = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (!expired) {
			if (col.gameObject.CompareTag ("Enemy")) {
				col.gameObject.BroadcastMessage ("TakeDamage", GetComponent<Attack> ());
			} else if (col.gameObject.CompareTag ("Player") || col.gameObject.CompareTag("Projectile"))
				return;
			expired = true;
			SendMessage ("Destroy", 0.2f);
		}
	}
}