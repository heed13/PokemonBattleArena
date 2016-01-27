using UnityEngine;
using System.Collections;

public class CombatLog : MonoBehaviour {
	string log = "";
	string logDelimiter = "|";

	public void writeToLog(string text)
	{
		log += text + logDelimiter;
	}

	public void writeToActionLog()
	{
		
	}
}
