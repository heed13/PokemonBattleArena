using UnityEngine;
using System.Collections;

public class GameMode : Photon.MonoBehaviour
{
	public static GameMode gameMode;

	protected void Start()
	{
		// If game mode doesn't exist, this is it
		if (gameMode == null) {
			gameMode = this;
			// If game mode exists, destory this
		} else if (gameMode != this) {
			Destroy(gameObject);
		}
	}

	public virtual void connectToLobby()
	{
		NetworkManager.manager.JoinLobby ();
	}

	public virtual void spawnMyCharacter (PokemonInfo info)
	{
	}


	protected virtual void setCameraToFollowObject(Transform trans)
	{
		Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow> ().enabled = true;
		Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow> ().target = trans;
	}
}
