using UnityEngine;
using System.Collections.Generic;
using System;

public class PokeEvolutions  {
	static Dictionary<string, string> families = new Dictionary<string, string>()
	{
		{"Charmander", "Charmeleon"},
		{"Charmeleon", "Charizard"},
		{"Squirtle", "Wartortle"},

	};

	public static string getEvolution(string pokemon)
	{
		try {
			return families[pokemon];
		}
		catch (Exception) {
			Debug.Log (pokemon + " HAS NO FAMILY!!");
			return null;
		}
	}
}
