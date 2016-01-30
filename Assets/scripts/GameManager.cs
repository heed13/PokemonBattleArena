using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager;
	public string test;
	public PlayerInfo player;
	private List<PokemonInfo> selectedSixPokemonInfo;

	// Use this for initialization
	void Awake()
	{
		player = new PlayerInfo ();
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

	public void saveUsername(string username)
	{
		player.username = username;
		player.nickname = username;
		test = username;
	}

	public void startGame()
	{
		// TODO: save a search game type option to pass into this 
		SceneManager.LoadScene("SCENE");
	}
	public void setSelectedPokemon(List<PokemonInfo> info)
	{
		selectedSixPokemonInfo = info;
	}
	public List<PokemonInfo> getSelectedPokemon()
	{
		return selectedSixPokemonInfo;
	}

	public List<PokemonInfo> GetPokemonInfo()
	{
		List<PokemonInfo> info = new List<PokemonInfo> ();

		info.Add(PokemonInfoHandler.create("Charmander",pokemonType.fire));
		info.Add(PokemonInfoHandler.create("Bulbasaur",pokemonType.grass));
		info.Add(PokemonInfoHandler.create("Abra",pokemonType.psychic));
		info.Add(PokemonInfoHandler.create("Gastly",pokemonType.ghost));
		info.Add(PokemonInfoHandler.create("Geodude",pokemonType.rock));
		info.Add(PokemonInfoHandler.create("Machop",pokemonType.fighting,"machop_port","machop_anim"));
		info.Add(PokemonInfoHandler.create("Meowth",pokemonType.normal));
		info.Add(PokemonInfoHandler.create("Pikachu",pokemonType.electric));
		info.Add(PokemonInfoHandler.create("Squirtle",pokemonType.water));

		return info;

	}
}
