using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// NPC manager.
/// </summary>
public class NPCManager : MonoBehaviour 
{
	public int totalNPCs = 3;
	public int spawnDelay = 5; // How many seconds pass before we fill an empty spot
	public bool randomDoor = true;
	public GameObject npcPrefab;

	private List<Door> doors;
	private int currentNpcs = 0;
	private float nextSpawn = 0;
	private int nextDoor = 0;

	void Start ()
	{
		Init ();
		for (int i = 0; i < doors.Count; i++) {
			SpawnNPC ();
		}
	}

	void Init()
	{
		doors = new List<Door>(GameObject.FindObjectsOfType<Door> ());
	}

	// we don't really care to run this too much
	void FixedUpdate () 
	{
		if (doors.Count == 0)
			Init ();
		if (currentNpcs < totalNPCs && Time.time >= nextSpawn) {
			nextSpawn = Time.time + spawnDelay;
			SpawnNPC ();
		}
	}

	void SpawnNPC()
	{
		Door door = GetSpawnDoor ();
		GameObject npc = (GameObject)Instantiate (npcPrefab, door.transform.position, door.transform.rotation);
		currentNpcs++;
		door.SpawnObject (npc);
	}

	Door GetSpawnDoor()
	{
		if (randomDoor) {
			return doors [Random.Range (0, doors.Count)].GetComponent<Door> ();
		} else {
			return doors [NextDoorNum ()];
		}
	}

	int NextDoorNum()
	{
		int door = nextDoor++;
		nextDoor = nextDoor % doors.Count;
		return door;
	}
}
