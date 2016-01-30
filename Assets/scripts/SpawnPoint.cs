using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class SpawnPoint : MonoBehaviour {
	public int teamId = -1; // -1 means FFA
	public new CircleCollider2D collider;

	void Start()
	{
		tag = "UnCollidable";
		// check team
		if (teamId == -1)
			teamId = TeamMember.TeamFFA;
	}

	public static SpawnPoint[] getAllSpawnPoints()
	{
		return GameObject.FindObjectsOfType<SpawnPoint> ();
	}

	//TODO ungaurded currently checks for any one, even those on the same team. This should only get enemies
	public static SpawnPoint getUngaurdedSpawn(SpawnPoint[] points, int teamId = TeamMember.TeamFFA)
	{
		// Look for ungaurded points
		for (int i = 0; i < points.Length; i++) {
			if ((teamId == TeamMember.TeamFFA || points[i].teamId == teamId) // If on our team, or team FFA
				&& Physics2D.OverlapCircleAll (points [i].transform.position, points [i].collider.radius).Length > 0) { // and nobody is close by
				return points [i];
			}
		}
		return null;
	}

	public static SpawnPoint getRandomSpawnPoint(SpawnPoint[] points, int teamId = TeamMember.TeamFFA, bool ungaurded = false) 
	{
		// If FFA just give a spot, but check ungaurded if desired
		if (teamId == TeamMember.TeamFFA) { 
			if (ungaurded) {
				SpawnPoint openPoint = getUngaurdedSpawn (points,teamId);
				if (openPoint)
					return openPoint;
			}
			return points [Random.Range (0, points.Length)];
		}

		// Get friendly points
		SpawnPoint[] allowedPoints = getTeamSpawnPoints (points, teamId);
		if (allowedPoints.Length == 0)
			return null;

		// check if ungaured is required
		if (ungaurded) {
			SpawnPoint openPoint = getUngaurdedSpawn (allowedPoints, teamId);
			if (openPoint)
				return openPoint;
		}
		
		return allowedPoints [Random.Range (0, allowedPoints.Length)];
	}

	public static SpawnPoint[] getTeamSpawnPoints(SpawnPoint[] allPoints, int teamId)
	{
		// If not then we need to find points with our team
		System.Collections.Generic.List<SpawnPoint> allowedPoints = new System.Collections.Generic.List<SpawnPoint>();
		for (int i = 0; i < allPoints.Length; i++) {
			if (allPoints[i].teamId == teamId)
				allowedPoints.Add(allPoints[i]);
		}
		return allowedPoints.ToArray ();
	}
}
