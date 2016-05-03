using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Experience : MonoBehaviour {
	public int totalExp = 0;
	public int level = 1;
	public bool setDropXp = false;
	public int setDropAmount = 1;
	private int xpRequired = 2;

	public Animator lvlUpObject;

	public void resetXp()
	{
		totalExp = 0;
		level = 1;
		xpRequired = 2;
	}
	public void gainExperience(int exp)
	{
		totalExp += exp;
		while (totalExp >= xpRequired) {
			levelUp ();
		}
	}

	public int dropExperience()
	{
		if (setDropXp)
			return setDropAmount;
		return level*2;
	}

	public void getExperienceFromObject(Experience exp)
	{
		gainExperience (exp.dropExperience ());
	}

	void levelUp()
	{
		// Play anim
		lvlUpObject.SetTrigger("lvlup");
		level++;
		xpRequired += level + 1;

	}
}
