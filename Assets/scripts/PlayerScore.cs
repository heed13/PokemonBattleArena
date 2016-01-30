using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScore : MonoBehaviour 
{
	public int totalKills = 0;
	public Dictionary<string, int> playerKills;

	public int score = 0;
	void Start()
	{
		playerKills = new Dictionary<string, int> ();
	}
	public void killedPlayer(HitInfo hit)
	{
		totalKills++; // increment total kills
		if (hit.player.nickname != null)
			playerKills [hit.player.nickname]++; // increment player kills - use nickname
		translateKillToScore (hit.pokemon.level); // transalte kill to score
	}

	void translateKillToScore(int level)
	{
		score += Mathf.CeilToInt(level * 1.5f);
	}
}
