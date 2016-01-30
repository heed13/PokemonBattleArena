using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameCharacterSelection : MonoBehaviour {
	public GameObject prefab; // todo this doesn't belong here
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
		
		GameObject playerGO = (GameObject)Instantiate (prefab, Vector3.zero, Quaternion.identity);
		playerGO.GetComponent<PlayerSprite> ().prepSprite (selectedCharacterInfo [index]);
		SoundPlayer.soundPlayer.playMusic ("battleMusic",0.1f);

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
