using UnityEngine;
using System.Collections;

public class CharacterInfo {
	public enum characterTypes {
		fire,
		water,
		rock,
		fighting,
		electric,
		normal,
		psychic,
		ghost,
		grass,
		count
	}
	public string name;
	public characterTypes type;
	public characterTypes[] strong;
	public characterTypes[] weak;
	public characterTypes[] resistant;
	public Sprite[] mugRotation;

}
