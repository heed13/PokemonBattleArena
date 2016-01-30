using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public static NetworkManager manager;

	public string roomName = "MyRoom";
	public string pokemonPrefabName = "PokemonSprite";
	public bool autoJoinLobby = false;
	public System.Action<bool> onJoinRoomCallback;
	public System.Action<bool> onConnectedCallback;

	void Awake()
	{
		PhotonNetwork.autoJoinLobby = autoJoinLobby;

		// If game control doesn't exist, this is it
		if (manager == null) {
			manager = this;
			// If game control exists, destory this
		} else if (manager != this) {
			Destroy(gameObject);
		}
	}

	void Start ()
	{
	}
	void OnConnectedToMaster()
	{
		Debug.Log ("Connected to master");
		if (onConnectedCallback != null)
			onConnectedCallback(true);
	}
	void OnJoinedLobby()
	{
		Debug.Log ("Joined Lobby");
		RoomOptions options = new RoomOptions (){ isVisible = false, maxPlayers = 10 };
		PhotonNetwork.JoinOrCreateRoom (roomName, options, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{
		Debug.Log ("Joined Room");
		if (onJoinRoomCallback != null)
			onJoinRoomCallback (true);
	}
	void OnCreatedRoom()
	{
		Debug.Log ("Created Room");
		if (onJoinRoomCallback != null)
			onJoinRoomCallback (true);
	}
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log ("ahh, we failed to join a random");
	}


	void OnGUI()
	{
		GUI.Label (new Rect (0, 0, 100, 50), PhotonNetwork.connectionState.ToString ());
	}

	// ---------- Public Functions ------------

	public void connect(System.Action<bool> onConnect = null)
	{
		Debug.Log ("Connecting to server");

		onConnectedCallback = onConnect;
		PhotonNetwork.ConnectUsingSettings (GameManager.manager.version);
	}
	public void JoinLobby( System.Action<bool> onJoin = null)
	{
		Debug.Log ("Joining Lobby");
		onJoinRoomCallback = onJoin;
		PhotonNetwork.JoinLobby ();
	}

}
