using UnityEngine;
using System.Collections;

public class Experience : MonoBehaviour {
	public int totalExp = 0;
	public int level = 1;

	public void gainExperience(int exp)
	{
		totalExp += exp;
		while (totalExp >= level * 2) {
			levelUp ();
		}
	}

	public int dropExperience()
	{
		return level;
	}

	public void getExperienceFromObject(Experience exp)
	{
		gainExperience (exp.dropExperience ());
	}

	void levelUp()
	{
		level++;
	}
}
