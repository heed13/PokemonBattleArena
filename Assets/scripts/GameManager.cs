using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager;
	public Texture2D loadingScreenImage;

	// Use this for initialization
	void Awake()
	{
		// If game control doesn't exist, this is it
		if (gameManager == null) {
			gameManager = this;
			DontDestroyOnLoad (gameObject);
			// If game control exists, destory this
		} else if (gameManager != this) {
			Destroy(gameObject);
		}
	}

	// Loading Screen
	void OnGUI()
	{
	}

	public List<CharacterInfo> GetPokemonInfo()
	{
		List<CharacterInfo> info = new List<CharacterInfo> ();

		CharacterInfo charInfo = new CharacterInfo ();
		charInfo.name = "Char";
		charInfo.type = CharacterInfo.characterTypes.fire;
		charInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.grass,
			CharacterInfo.characterTypes.ghost
		};
		charInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		charInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.grass,
			CharacterInfo.characterTypes.ghost
		};

		CharacterInfo bulbInfo = new CharacterInfo ();
		bulbInfo.name = "Bulb";
		bulbInfo.type = CharacterInfo.characterTypes.grass;
		bulbInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		bulbInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		bulbInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};

		info.Add (charInfo);
		info.Add (bulbInfo);
		return info;

	}
}
