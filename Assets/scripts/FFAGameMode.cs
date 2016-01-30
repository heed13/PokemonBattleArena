using UnityEngine;
using System.Collections;

public class FFAGameMode : GameMode 
{
	public string playerPrefabName;

	public GameObject myCharacter;
	public GameObject[] enemies;

	public InGameCharacterSelection selectionMenu;

	private SpawnPoint[] spawnPoints;
	private int currentTeamId = 0;

	new void Start()
	{
		base.Start ();
		NetworkManager.manager.connect (connectToLobby);
		SoundPlayer.soundPlayer.playMusic ("battleMusic",0.1f);
	}

	public override void spawnMyCharacter(PokemonInfo pokemon)
	{
		if (myCharacter == null) { // If this is the first time spawning, create a new guy
			
			//Thinking this call should be RPC'd so that master can do most of the tracking ??? maybe
			GameObject playerGO = PhotonNetwork.Instantiate (playerPrefabName, Vector3.zero, Quaternion.identity, 0);
			playerGO.GetComponent<TeamMember> ().teamId = currentTeamId++; // todo RPC this, var should be masters
			playerGO.tag = "Player";
			setCameraToFollowObject (playerGO.transform);
			myCharacter = playerGO;
		} 

		// Prep sprite
		photonView.RPC ("setCharacterInfoForPlayer", PhotonTargets.OthersBuffered, myCharacter.GetPhotonView().viewID, pokemon.name);
		myCharacter.GetComponent<PlayerSprite> ().prepSprite (pokemon); // this should be RPC

		myCharacter.transform.position = getRandomSpawnPoint (); // RPC?
	}

	public Vector3 getRandomSpawnPoint()
	{
		return SpawnPoint.getRandomSpawnPoint (SpawnPoint.getAllSpawnPoints (), TeamMember.TeamFFA).transform.position;
	}

	public void connectToLobby (bool connected)
	{
		if (connected) {
			NetworkManager.manager.JoinLobby ((bool val) => {
				selectionMenu.showSelectionMenu ();
			});
		}
	}

	// ------------ Public RPC functions ------------
	[PunRPC]
	public void setCharacterInfoForPlayer(int viewId, string pokemonName)
	{
		Debug.Log ("attempting to set other players sprite info: viewId: "+viewId);

		// Find the correct Object
		PhotonView view = PhotonView.Find (viewId);
		if (view == null)
			return;
		Debug.Log ("found id, setting info");

		// call prep sprite on the object
		view.gameObject.GetComponent<PlayerSprite> ().prepSprite (PokemonInfoManager.manager.getInfoByPokemonName (pokemonName));
			
	}
}
