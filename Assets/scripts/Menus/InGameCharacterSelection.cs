using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameCharacterSelection : MonoBehaviour {
	public InstantGuiElement window;
	public InstantGuiElement background;

	public InstantGuiButton[] btns;

	List<PokemonInfo> selectedCharacterInfo;

	void Start()
	{
		selectedCharacterInfo = GameManager.gameManager.getSelectedPokemon ();
		setButtons (selectedCharacterInfo);
	}

	void spawnCharacter(int index)
	{
		GameMode.gameMode.spawnMyCharacter (selectedCharacterInfo [index]);
	}

	public void setButtons(List<PokemonInfo> info)
	{
		for (int i = 0; i < info.Count; i++) {
			btns [i].style.main.texture = info [i].portrait;
			btns [i].onPressed.message = "spawn"+i.ToString();
		}
	}

	public void showSelectionMenu()
	{
		window.gameObject.SetActive (true);
		background.gameObject.SetActive (true);
	}

	public void spawn0()
	{
		spawnCharacter (0);
	}
	public void spawn1()
	{
		spawnCharacter (1);
	}
	public void spawn2()
	{
		spawnCharacter (2);
	}
	public void spawn3()
	{
		spawnCharacter (3);
	}
	public void spawn4()
	{
		spawnCharacter (4);
	}
	public void spawn5()
	{
		spawnCharacter (5);
	}



}
