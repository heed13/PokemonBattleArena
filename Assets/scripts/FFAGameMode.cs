using UnityEngine;
using System.Collections;

public class FFAGameMode : GameMode 
{
	public GameObject playerPrefab;

	public GameObject myCharacter;
	public GameObject[] enemies;

	private SpawnPoint[] spawnPoints;
	private int currentTeamId = 0;

	new void Start()
	{
		base.Start ();
		SoundPlayer.soundPlayer.playMusic ("battleMusic",0.1f);
	}

	public override void spawnMyCharacter(PokemonInfo pokemon)
	{
		if (myCharacter == null) { // If this is the first time spawning, create a new guy
			
			GameObject playerGO = (GameObject)Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
			playerGO.GetComponent<TeamMember> ().teamId = currentTeamId++;
			playerGO.tag = "Player";
			setCameraToFollowObject (playerGO.transform);
			myCharacter = playerGO;

		} 
		myCharacter.GetComponent<PlayerSprite> ().prepSprite (pokemon);

		myCharacter.transform.position = getRandomSpawnPoint ();
	}

	public Vector3 getRandomSpawnPoint()
	{
		return SpawnPoint.getRandomSpawnPoint (SpawnPoint.getAllSpawnPoints (), TeamMember.TeamFFA).transform.position;
	}
}
