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

			// Set player vars
			playerGO.GetComponent<TeamMember> ().teamId = currentTeamId++;
			playerGO.tag = "Player";
			myCharacter = playerGO;

			// Set camera to follow this target
			setCameraToFollowObject (playerGO.transform);

			// Link health panel to this pokemon
			GameObject.FindObjectOfType<PokemonInfoPanel> ().linkPokemon (myCharacter.GetComponent<PlayerPokemon> ());

		} 

		// Prep sprite
		myCharacter.GetComponent<PlayerPokemon> ().prepSprite (pokemon);

		// Spawn player at random location
		myCharacter.transform.position = getRandomSpawnPoint ();
	}

	public Vector3 getRandomSpawnPoint()
	{
		return SpawnPoint.getRandomSpawnPoint (SpawnPoint.getAllSpawnPoints (), TeamMember.TeamFFA).transform.position;
	}
}
