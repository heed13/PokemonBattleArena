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

		info.Add( new CharacterInfo ("Charmander",CharacterInfo.characterTypes.fire));

		info.Add( new CharacterInfo ("Bulbasaur",CharacterInfo.characterTypes.grass));

		info.Add( new CharacterInfo ("Abra",CharacterInfo.characterTypes.psychic));

		info.Add( new CharacterInfo ("Gastly",CharacterInfo.characterTypes.ghost));

		info.Add( new CharacterInfo ("Geodude",CharacterInfo.characterTypes.rock));

		info.Add( new CharacterInfo ("Machop",CharacterInfo.characterTypes.fighting,"machop_port","machop_anim"));

		info.Add(  new CharacterInfo ("Meowth",CharacterInfo.characterTypes.normal));

		info.Add( new CharacterInfo ("Pikachu",CharacterInfo.characterTypes.electric));

		info.Add( new CharacterInfo ("Squirtle",CharacterInfo.characterTypes.water));


		return info;

	}
}
