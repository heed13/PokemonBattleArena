//using UnityEngine;
//using System.Collections;
//[ExecuteInEditMode]
//
//public class NetworkManager : MonoBehaviour {
//	//public static NetworkManager manager;
//
//	string registeredName = "PokemonBattle";
//	float refreshRequestLength = 3.0f;
//	HostData[] hostData;
//	public string chosenGameName = "";
//	public NetworkPlayer myPlayer;
//	public NetworkView nView;
//
//
//	void Awake()
//	{
//
//		// If game control doesn't exist, this is it
//		//if (manager == null) {
//		//	manager = this;
//		//	// If game control exists, destory this
//		//} else if (manager != this) {
//		//	Destroy(gameObject);
//		//}
//	}
//
//	void Start ()
//	{
//		nView = GetComponent<NetworkView> ();
//	}
//
//	void StartServer()
//	{
//		Network.InitializeServer (16, Random.Range (2000, 2500), !Network.HavePublicAddress ());
//		MasterServer.RegisterHost (registeredName, chosenGameName);
//	}
//
//	void OnServerInitialized()
//	{
//		if (Network.isServer) {
//			myPlayer = Network.player;
//		}
//	}
//		
//
//
//	void OnGUI()
//	{
//	//	GUI.Label (new Rect (0, 0, 100, 50), PhotonNetwork.connectionState.ToString ());
//	}
//
//	// ---------- Public Functions ------------
//
//}
