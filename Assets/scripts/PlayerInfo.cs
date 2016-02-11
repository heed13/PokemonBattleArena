using UnityEngine;
using System.Collections;

public struct PlayerInfo 
{
	public PlayerInfo(string user, string nick, string id) 
	{
		this.username = user;
		this.nickname = nick;
		this.userId = id;
	}

	public static PlayerInfo GetFromLocalSettings()
	{
		PlayerInfo player = new PlayerInfo();
		player.username = LocalSettings.getUsername ();
		return player;
	}

	public string username; // username of the player
	public string nickname; // desired display name of the user
	public string userId; // user id of player
}
