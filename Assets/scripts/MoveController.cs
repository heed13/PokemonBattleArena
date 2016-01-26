using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float moveSpeed = 60;
	float rotationalShift = -22.5f;

	Rigidbody2D rb;
	Vector3 lastPos;
	Animator anim;

	Vector3 currentMovement;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	public void MoveTo (float x = 0.0f, float y = 0.0f)
	{
		//update anim
		if (x != 0 || y != 0) {
			anim.SetBool ("moving", true);
			anim.SetFloat ("dirX", x);
			anim.SetFloat ("dirY", y);
		} else {
			anim.SetBool ("moving", false);
		}

		// Move in dir
		currentMovement = new Vector2 (x, y).normalized * moveSpeed;
		rb.velocity = currentMovement * Time.deltaTime;
	}

	public void rotateToDegree(float deg)
	{
		deg -= rotationalShift;
		if (deg < 0)
			deg += 360;

		anim.SetFloat ("rotationDeg", deg);
	}
}