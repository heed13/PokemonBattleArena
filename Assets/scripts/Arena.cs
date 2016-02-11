using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arena : MonoBehaviour 
{
	public List<SpawnPoint> spawnPoints;

	void Awake()
	{
		spawnPoints = new List<SpawnPoint> (GameObject.FindObjectsOfType<SpawnPoint>());
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
}
