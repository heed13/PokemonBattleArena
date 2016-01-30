using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour {
	public float destroyAfterTime = 2.0f;

	void OnEnable()
	{
		Invoke ("Destroy", destroyAfterTime);
	}

	public void Destroy()
	{
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}
