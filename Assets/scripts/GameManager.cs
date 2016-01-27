using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager;
	public Texture2D loadingScreenImage;

	private List<CharacterInfo> selectedSixPokemonInfo;

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

	public void startGame()
	{
		// TODO: save a search game type option to pass into this 
		SceneManager.LoadScene("SCENE");
	}
	public void setSelectedPokemon(List<CharacterInfo> info)
	{
		selectedSixPokemonInfo = info;
	}
	public List<CharacterInfo> getSelectedPokemon()
	{
		return selectedSixPokemonInfo;
	}

	public List<CharacterInfo> GetPokemonInfo()
	{
		List<CharacterInfo> info = new List<CharacterInfo> ();

		CharacterInfo charInfo = new CharacterInfo ();
		charInfo.name = "Charmander";
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
		charInfo.portrait = Resources.Load ("images/portraits/Charmander") as Texture;
		charInfo.prefab = Resources.Load ("pokemon/charmander") as GameObject;

		CharacterInfo bulbInfo = new CharacterInfo ();
		bulbInfo.name = "Bulbasaur";
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
		bulbInfo.portrait = (Texture)Resources.Load ("images/portraits/Bulbasaur") as Texture;
		bulbInfo.prefab = Resources.Load ("pokemon/bulbasaur") as GameObject;

		CharacterInfo abraInfo = new CharacterInfo ();
		abraInfo.name = "Abra";
		abraInfo.type = CharacterInfo.characterTypes.psychic;
		abraInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.ghost,
			CharacterInfo.characterTypes.fighting
		};
		abraInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		abraInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		abraInfo.portrait = (Texture)Resources.Load ("images/portraits/Abra") as Texture;
		abraInfo.prefab = Resources.Load ("pokemon/abra") as GameObject;

		CharacterInfo gastlyInfo = new CharacterInfo ();
		gastlyInfo.name = "Gastly";
		gastlyInfo.type = CharacterInfo.characterTypes.ghost;
		gastlyInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		gastlyInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		gastlyInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		gastlyInfo.portrait = (Texture)Resources.Load ("images/portraits/Gastly") as Texture;
		gastlyInfo.prefab = Resources.Load ("pokemon/gastly") as GameObject;

		CharacterInfo geodInfo = new CharacterInfo ();
		geodInfo.name = "Geodude";
		geodInfo.type = CharacterInfo.characterTypes.rock;
		geodInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		geodInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		geodInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		geodInfo.portrait = (Texture)Resources.Load ("images/portraits/Geodude") as Texture;
		geodInfo.prefab = Resources.Load ("pokemon/geodude") as GameObject;

		CharacterInfo machInfo = new CharacterInfo ();
		machInfo.name = "Machop";
		machInfo.type = CharacterInfo.characterTypes.fighting;
		machInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		machInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		machInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		machInfo.portrait = (Texture)Resources.Load ("images/portraits/Machop") as Texture;
		machInfo.prefab = Resources.Load ("pokemon/machop") as GameObject;

		CharacterInfo meowInfo = new CharacterInfo ();
		meowInfo.name = "Meowth";
		meowInfo.type = CharacterInfo.characterTypes.normal;
		meowInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		meowInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		meowInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		meowInfo.portrait = (Texture)Resources.Load ("images/portraits/Meowth") as Texture;
		meowInfo.prefab = Resources.Load ("pokemon/meowth") as GameObject;

		CharacterInfo pikaInfo = new CharacterInfo ();
		pikaInfo.name = "Pikachu";
		pikaInfo.type = CharacterInfo.characterTypes.electric;
		pikaInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		pikaInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		pikaInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		pikaInfo.portrait = (Texture)Resources.Load ("images/portraits/Pikachu") as Texture;
		pikaInfo.prefab = Resources.Load ("pokemon/pikachu") as GameObject;

		CharacterInfo squiInfo = new CharacterInfo ();
		squiInfo.name = "Squirtle";
		squiInfo.type = CharacterInfo.characterTypes.water;
		squiInfo.strong = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.rock
		};
		squiInfo.weak = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.fire,
			CharacterInfo.characterTypes.normal
		};
		squiInfo.resistant = new CharacterInfo.characterTypes[] {
			CharacterInfo.characterTypes.water,
			CharacterInfo.characterTypes.electric
		};
		squiInfo.portrait = (Texture)Resources.Load ("images/portraits/Squirtle") as Texture;
		squiInfo.prefab = Resources.Load ("pokemon/squirtle") as GameObject;

		info.Add (charInfo);
		info.Add (bulbInfo);
		info.Add (abraInfo);
		info.Add (gastlyInfo);
		info.Add (geodInfo);
		info.Add (machInfo);
		info.Add (meowInfo);
		info.Add (pikaInfo);
		info.Add (squiInfo);
		return info;

	}
}
