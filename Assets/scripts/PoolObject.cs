using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour {
	public bool destroyOnCollision = true;
	public float destroyAfterTime = 2.0f;

	void OnEnable()
	{
		Invoke ("Destroy", destroyAfterTime);
	}

	void Destroy()
	{
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}
