using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	public float selfDestructTime = 1.0f;
	public bool dontDestroy = false;

	private float timeToDie = 0;

	void Awake()
	{
		timeToDie = selfDestructTime;
	}
	// Update is called once per frame
	void Update () 
	{
		timeToDie -= Time.deltaTime;

		if (timeToDie <= 0) {
			timeToDie = selfDestructTime;
			killMe();
		}
	}

	void killMe()
	{
		if (!dontDestroy)
			Destroy (this.gameObject);
		else
			gameObject.SetActive (false);
	}
}
