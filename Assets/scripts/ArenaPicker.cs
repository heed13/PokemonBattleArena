using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaPicker : MonoBehaviour {
	public List<GameObject> arenas;
	public Arena currentArena;
	public GameObject tmpBaddieSpawn;

	// Use this for initialization
	void Start ()
	{
		PickRandomArena ();
		TmpSpawnBaddies ();
	}

	public void PickRandomArena()
	{
		int randIndex = Random.Range (0, arenas.Count);
		SpawnArena (arenas [randIndex]);
	}

	void SpawnArena(GameObject arena)
	{
		GameObject go = (GameObject)Instantiate (arena, Vector3.zero, Quaternion.identity);
		currentArena = go.GetComponent<Arena>();
	}

	void TmpSpawnBaddies()
	{
		for (int i = 0; i < currentArena.spawnPoints.Count; i++) {
			GameObject baddie = (GameObject)Instantiate (tmpBaddieSpawn, currentArena.spawnPoints[i].transform.position, currentArena.spawnPoints[i].transform.rotation);
			baddie.SetActive (true);
		}
	}
}
