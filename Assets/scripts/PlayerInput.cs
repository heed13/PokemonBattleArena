using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public MoveController move;
	public AttackController attack;

	void Start()
	{
		
	}

	void Update()
	{
		GetPlayerAttack ();
		GetPlayerMovement ();
		PlayerMouseRotate ();
	}

	void GetPlayerAttack()
	{
		if (Input.GetAxisRaw ("Fire1") != 0) {
			attack.SetAttacking (true);
		} else {
			attack.SetAttacking (false);
		}
	}
	void GetPlayerMovement()
	{
		// Get Movement
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		move.MoveTo (x, y);
	}

	void PlayerMouseRotate()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 vec = new Vector2 (mousePos.x, mousePos.y) - new Vector2 (transform.position.x, transform.position.y);
		float deg = Mathf.Atan2 (vec.y, vec.x) * Mathf.Rad2Deg;
		move.rotateToDegree (deg);
	}
}
