using UnityEngine;
using System.Collections;

public class FloatingText : PoolObject {
	public float xStrength = 1;
	public float yStrength = .4f;
	float xForce;
	float yForce;

	// Use this for initialization
	void Start ()
	{
		xForce = Random.Range (-xStrength, xStrength) * Time.deltaTime;
		yForce = Random.Range (-yStrength, yStrength) * Time.deltaTime;
	}
	
	void FixedUpdate () 
	{
		transform.position = new Vector3 (transform.position.x+xForce , transform.position.y+yForce, transform.position.z);
	}

}
