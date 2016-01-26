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

	List<CharacterInfo.characterTypes> selectedSixTypes;
	List<InstantGuiButton> selectedSixBtns;
	int selectedMax = 6;

	public InstantGuiElement pokemonNameLbl;
	public InstantGuiElement pokemonTypeLbl;
	public InstantGuiElement pokemonStrong1;
	public InstantGuiElement pokemonStrong2;
	public InstantGuiElement pokemonWeak1;
	public InstantGuiElement pokemonWeak2;
	public InstantGuiElement pokemonResistant1;
	public InstantGuiElement pokemonResistant2;
	List<CharacterInfo> characterInfoList;


	// --------------------------- Functions ---------------------------
	void Awake()
	{
		selectedSixTypes = new List<CharacterInfo.characterTypes> (selectedMax);
		selectedSixBtns = new List<InstantGuiButton> (selectedMax);
	}
	void Start()
	{
		// fetch pokemon data
		characterInfoList = GameManager.gameManager.GetPokemonInfo();	
	}

	void popCharacter(int index)
	{
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

		}
	}

	public void setInfo (CharacterInfo.characterTypes type)
	{
		//set info
		characterInfoList.ForEach (delegate (CharacterInfo obj) {
			if (obj.type == type) {
				pokemonNameLbl.text = obj.name;
				pokemonTypeLbl.text = obj.type.ToString();
			}
		});
	}
	public void getTypeIcon(CharacterInfo.characterTypes type)
	{
		
	}

	void setCharacter(CharacterInfo.characterTypes type)
	{
		// character was picked, need to add it to array and set its image
		if (selectedSixTypes.Count < selectedMax && !selectedSixTypes.Contains(type)) {
			selectedSixTypes.Add (type);
			moveImage (type, true);
		}
		setInfo (type);

	}

	void moveImage(CharacterInfo.characterTypes type, bool toSelected, int index = -1)
	{
		if (index == -1)
			index = currentSelectedIndex;
		
		InstantGuiButton typeBtn = null;

		switch (type) {
		case CharacterInfo.characterTypes.electric:
			typeBtn = electricBtn;
			break;
		case CharacterInfo.characterTypes.psychic:
			typeBtn = psychicBtn;
			break;
		case CharacterInfo.characterTypes.fire:
			typeBtn = fireBtn;
			break;
		case CharacterInfo.characterTypes.ghost:
			typeBtn = ghostBtn;
			break;
		case CharacterInfo.characterTypes.fighting:
			typeBtn = fightingBtn;
			break;
		case CharacterInfo.characterTypes.rock:
			typeBtn = rockBtn;
			break;
		case CharacterInfo.characterTypes.grass:
			typeBtn = grassBtn;
			break;
		case CharacterInfo.characterTypes.water:
			typeBtn = waterBtn;
			break;
		case CharacterInfo.characterTypes.normal:
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

	// Add Characters functions, these exist because the GUI system wont take params... freaking lame. I could build a better one... i just... dont have the time.
	public void setFire()
	{
		setCharacter (CharacterInfo.characterTypes.fire);
	}
	public void setRock()
	{
		setCharacter (CharacterInfo.characterTypes.rock);
	}
	public void setFighting()
	{
		setCharacter (CharacterInfo.characterTypes.fighting);
	}
	public void setElectric()
	{
		setCharacter (CharacterInfo.characterTypes.electric);
	}
	public void setWater()
	{
		setCharacter (CharacterInfo.characterTypes.water);
	}
	public void setGrass()
	{
		setCharacter (CharacterInfo.characterTypes.grass);
	}
	public void setPsychic()
	{
		setCharacter (CharacterInfo.characterTypes.psychic);
	}
	public void setGhost()
	{
		setCharacter (CharacterInfo.characterTypes.ghost);
	}
	public void setNormal()
	{
		setCharacter (CharacterInfo.characterTypes.normal);
	}
	public void setRandom()
	{
		CharacterInfo.characterTypes type;
		do {
			type = (CharacterInfo.characterTypes)Random.Range (0, (int)CharacterInfo.characterTypes.count);
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


}
