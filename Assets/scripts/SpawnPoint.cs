using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public float spawnDetectionRaduis = 1.5f;

	private CircleCollider2D col;

	void Start()
	{
		col = GetComponent<CircleCollider2D> ();
		col.radius = spawnDetectionRaduis;
	}
}
