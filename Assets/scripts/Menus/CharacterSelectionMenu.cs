using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CharacterSelectionMenu : MonoBehaviour {
	public InstantGuiButton electricBtn;
	public InstantGuiButton psychicBtn;
	public InstantGuiButton fireBtn;
	public InstantGuiButton ghostBtn;
	public InstantGuiButton fightingBtn;
	public InstantGuiButton rockBtn;
	public InstantGuiButton grassBtn;
	public InstantGuiButton waterBtn;
	public InstantGuiButton normalBtn;
	public InstantGuiButton randomBtn;

	public InstantGuiButton[] selectedBtns;
	private int currentSelectedIndex = 0;

	List<pokemonType> selectedSixTypes;
	List<InstantGuiButton> selectedSixBtns;
	int selectedMax = 6;

	List<PokemonInfo> characterInfoList;
	List<PokemonInfo> selectedCharacterInfoList;


	public InstantGuiElement pokemonNameLbl;
	public InstantGuiElement pokemonTypeLbl;
	public InstantGuiElement pokemonStrong1;
	public InstantGuiElement pokemonStrong2;
	public InstantGuiElement pokemonWeak1;
	public InstantGuiElement pokemonWeak2;
	public InstantGuiElement pokemonResistant1;
	public InstantGuiElement pokemonResistant2;


	public InstantGuiElement readyMenu;


	// --------------------------- Functions ---------------------------
	void Awake()
	{
		selectedSixTypes = new List<pokemonType> (selectedMax);
		selectedSixBtns = new List<InstantGuiButton> (selectedMax);
	}
	void Start()
	{
		// fetch pokemon data
		characterInfoList = GameManager.gameManager.GetPokemonInfo();	
		selectedCharacterInfoList = new List<PokemonInfo> (selectedMax);
	}

	void popCharacter(int index)
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");

		if (index < selectedSixTypes.Count) {
			//put image back
			Debug.Log ("pop type: " + selectedSixTypes[index].ToString ());

			moveImage(selectedSixTypes[index], false, index);

			//shift images up one if we didnt remove the last item
			if (index != selectedSixTypes.Count - 1) {
				Debug.Log ("looping");
				for (int i = index; i < selectedSixTypes.Count-1; i++) {
					Debug.Log ("swapping: "+i.ToString()+" with: "+(i+1).ToString());
					swapTextures (ref selectedBtns [i], ref selectedBtns [i + 1]);
				}
			}
			selectedSixTypes.RemoveAt (index);
			selectedSixBtns.RemoveAt (index);
			selectedCharacterInfoList.RemoveAt (index);

		}
	}

	void setCharacter(pokemonType type)
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");

		// character was picked, need to add it to array and set its image
		if (selectedSixTypes.Count < selectedMax && !selectedSixTypes.Contains(type)) {
			selectedSixTypes.Add (type);
			moveImage (type, true);

			// last slot was filled
			if (selectedSixTypes.Count == selectedMax) {
				readyMenu.gameObject.SetActive (true);
			}
			moveInfoToSelected (type);
		}

		setInfo (type);

	}

	void moveImage(pokemonType type, bool toSelected, int index = -1)
	{
		if (index == -1)
			index = currentSelectedIndex;
		
		InstantGuiButton typeBtn = null;

		switch (type) {
		case pokemonType.electric:
			typeBtn = electricBtn;
			break;
		case pokemonType.psychic:
			typeBtn = psychicBtn;
			break;
		case pokemonType.fire:
			typeBtn = fireBtn;
			break;
		case pokemonType.ghost:
			typeBtn = ghostBtn;
			break;
		case pokemonType.fighting:
			typeBtn = fightingBtn;
			break;
		case pokemonType.rock:
			typeBtn = rockBtn;
			break;
		case pokemonType.grass:
			typeBtn = grassBtn;
			break;
		case pokemonType.water:
			typeBtn = waterBtn;
			break;
		case pokemonType.normal:
			typeBtn = normalBtn;
			break;
		default:
			break;
		}
		if (typeBtn != null) {
			swapTextures (ref selectedBtns [index], ref typeBtn);
		}

		if (toSelected) {
			selectedSixBtns.Add (typeBtn);
			currentSelectedIndex++;
		}
		else
			currentSelectedIndex--;
	}

	void swapTextures(ref InstantGuiButton a, ref InstantGuiButton b)
	{
		Texture tmpTexture = a.style.main.texture;
		a.style.main.texture = b.style.main.texture;
		b.style.main.texture = tmpTexture;
	}

	void getTypeIcon(pokemonType type)
	{

	}

	void setInfo (pokemonType type)
	{
		return;
		//set info
		characterInfoList.ForEach (delegate (PokemonInfo obj) {
			if (obj.type == type) {
				pokemonNameLbl.text = obj.name;
				pokemonTypeLbl.text = obj.type.ToString();
				if (obj.weakIcons.Count >= 1) 
					pokemonWeak1.style.main.texture = obj.weakIcons[0];
				if (obj.weakIcons.Count > 1) 
					pokemonWeak2.style.main.texture = obj.weakIcons[1];
				if (obj.resistantIcons.Count >= 1) 
					pokemonResistant1.style.main.texture = obj.resistantIcons[0];
				if (obj.resistantIcons.Count > 1) 
					pokemonResistant2.style.main.texture = obj.resistantIcons[1];

			}
		});
	}
	public void moveInfoToSelected(pokemonType type)
	{
		//set info
		characterInfoList.ForEach (delegate (PokemonInfo obj) {
			if (obj.type == type) {
				selectedCharacterInfoList.Add(obj);
			}
		});
	}

	public void playGame()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");
		GameManager.gameManager.setSelectedPokemon (selectedCharacterInfoList);
		GameManager.gameManager.startGame ();
	}

	// Add Characters functions, these exist because the GUI system wont take params... freaking lame. I could build a better one... i just... dont have the time.
	public void setFire()
	{
		setCharacter (pokemonType.fire);
	}
	public void setRock()
	{
		setCharacter (pokemonType.rock);
	}
	public void setFighting()
	{
		setCharacter (pokemonType.fighting);
	}
	public void setElectric()
	{
		setCharacter (pokemonType.electric);
	}
	public void setWater()
	{
		setCharacter (pokemonType.water);
	}
	public void setGrass()
	{
		setCharacter (pokemonType.grass);
	}
	public void setPsychic()
	{
		setCharacter (pokemonType.psychic);
	}
	public void setGhost()
	{
		setCharacter (pokemonType.ghost);
	}
	public void setNormal()
	{
		setCharacter (pokemonType.normal);
	}
	public void setRandom()
	{
		pokemonType type = (pokemonType)Random.Range (0, (int)pokemonType.count);
		do {
			pokemonType tmp = type;
			type = (pokemonType)Random.Range (0, (int)pokemonType.count);
			if (type == pokemonType.none) {
				type = tmp;
			}
		}while (selectedSixTypes.Contains(type) && selectedSixTypes.Count < selectedMax);
		setCharacter (type);
	}
	public void pop1()
	{
		popCharacter (0);
	}
	public void pop2()
	{
		popCharacter (1);
	}
	public void pop3()
	{
		popCharacter (2);
	}
	public void pop4()
	{
		popCharacter (3);
	}
	public void pop5()
	{
		popCharacter (4);
	}
	public void pop6()
	{
		popCharacter (5);
	}


	public void HoldOnBtnPressed()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");
	}

}
