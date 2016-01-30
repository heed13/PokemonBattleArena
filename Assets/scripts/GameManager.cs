using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager manager;
	public string version = "v0.0.1";

	public PlayerInfo player;

	void Awake()
	{
		player = new PlayerInfo ();
		// If game control doesn't exist, this is it
		if (manager == null) {
			manager = this;
			DontDestroyOnLoad (gameObject);
			// If game control exists, destory this
		} else if (manager != this) {
			Destroy(gameObject);
		}

	}
		
	/// <summary>
	/// Saves the username. Please move this somewhere else
	/// </summary>
	/// <param name="username">Username.</param>
	public void saveUsername(string username)
	{
		player.username = username;
		player.nickname = username;
	}

	public void startGame()
	{
		// TODO: save a search game type option to pass into this 
		SceneManager.LoadScene("SCENE");
	}




}
