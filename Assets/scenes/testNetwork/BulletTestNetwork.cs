using UnityEngine;
using System.Collections;

public class BulletTestNetwork : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		var hit = col.gameObject;
		var hitPlayer = hit.GetComponent<MovementNetworkTest> ();
		if (hitPlayer != null) {
			Destroy (gameObject);
		}
	}
}
