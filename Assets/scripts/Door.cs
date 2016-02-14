using UnityEngine;
using System.Collections;

/// <summary>
/// Door. Basically just a NPC spawnpoint. However, this can be used for the player for future entrance / exits for buildings.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
	public bool npcOnly = true;
	public Vector2 exitOff = new Vector2(0.0f,-0.1f);

	private GameObject spawningGO;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
	}

	public void SpawnObject(GameObject obj)
	{
		spawningGO = obj;
		MoveSpawnObject ();
	}

	void MoveSpawnObject()
	{
		spawningGO.GetComponent<MoveController> ().MoveTo (exitOff [0], exitOff [1]);
	}
}
