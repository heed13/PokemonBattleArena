using UnityEngine;
using System.Collections;

public class CombatLog : MonoBehaviour {
	public static CombatLog combatLog;
	public string log = "";
	string logDelimiter = "|";

	// Use this for initialization
	void Awake()
	{
		// If combatLog doesn't exist, this is it
		if (combatLog == null) {
			combatLog = this;
		// If combatLog exists, destory this
		} else if (combatLog != this) {
			Destroy(gameObject);
		}
	}

	public void writeToLog(string text)
	{
		log += text + logDelimiter;
	}

	public void writeToActionLog()
	{
		
	}
}
