using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	public float selfDestructTime = 1.0f;
	
	// Update is called once per frame
	void Update () 
	{
		selfDestructTime -= Time.deltaTime;

		if (selfDestructTime <= 0) {
			killMe();
		}
	}

	void killMe()
	{
		Destroy(this.gameObject);
	}
}
