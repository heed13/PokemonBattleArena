using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arena : MonoBehaviour 
{
	public string displayName;
	public int maxPlayerCount = 6;
	public List<SpawnPoint> spawnPoints;

	void Awake()
	{
		spawnPoints = new List<SpawnPoint> (GameObject.FindObjectsOfType<SpawnPoint>());
	}
}
