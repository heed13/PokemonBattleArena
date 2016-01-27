using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameCharacterSelection : MonoBehaviour {
	public InstantGuiElement window;
	public InstantGuiElement background;

	public InstantGuiButton[] btns;

	List<CharacterInfo> selectedCharacterInfo;

	void Start()
	{
		selectedCharacterInfo = GameManager.gameManager.getSelectedPokemon ();
		setButtons (selectedCharacterInfo);
	}
	void spawnCharacter(int index)
	{
		GameObject playerGO = (GameObject)Instantiate (selectedCharacterInfo [index].prefab, Vector3.zero, Quaternion.identity);
		playerGO.tag = "Player";

	}

	public void setButtons(List<CharacterInfo> info)
	{
		Debug.Log (info.Count);
		Debug.Log (btns.Length);
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
