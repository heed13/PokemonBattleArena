using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonInfoManager : MonoBehaviour
{
	public static PokemonInfoManager manager;
	public List<PokemonInfo> allPokemonInfo;
	public List<PokemonInfo> selectedSixPokemonInfo;


	void Awake()
	{
		// If game control doesn't exist, this is it
		if (manager == null) {
			manager = this;
			DontDestroyOnLoad (gameObject);
			// If game control exists, destory this
		} else if (manager != this) {
			Destroy(gameObject);
		}
	}

	void Start()
	{
		GetPokemonInfo ();
	}

	public void setSelectedPokemon(List<PokemonInfo> info)
	{
		selectedSixPokemonInfo = info;
	}

	public List<PokemonInfo> getSelectedPokemon()
	{
		return selectedSixPokemonInfo;
	}

	public PokemonInfo getInfoByPokemonName(string name)
	{
		for (int i = 0; i < allPokemonInfo.Count; i++) {
			if (allPokemonInfo [i].name == name)
				return allPokemonInfo [i];
		}
		return default(PokemonInfo);
	}



	// ####################################  BEWARE OF ANYTHING BELOW THIS LINE ###############################################
	// ####### CODE WAS BORN IN THE WILD AND IS NOT FULLY DOMESTICATED. USE CAUTION, CODE MAY ATTACK.

	/// <summary>
	/// Gets all pokemon info. sets it if it doesn't exist
	/// </summary>
	/// <returns>list of pokemon info.</returns>
	public List<PokemonInfo> GetPokemonInfo()
	{
		if (allPokemonInfo == null) {

			allPokemonInfo = new List<PokemonInfo> ();

			allPokemonInfo.Add (PokemonInfoManager.create ("Charmander", pokemonType.fire));
			allPokemonInfo.Add (PokemonInfoManager.create ("Bulbasaur", pokemonType.grass));
			allPokemonInfo.Add (PokemonInfoManager.create ("Abra", pokemonType.psychic));
			allPokemonInfo.Add (PokemonInfoManager.create ("Gastly", pokemonType.ghost));
			allPokemonInfo.Add (PokemonInfoManager.create ("Geodude", pokemonType.rock));
			allPokemonInfo.Add (PokemonInfoManager.create ("Machop", pokemonType.fighting, "machop_port", "machop_anim"));
			allPokemonInfo.Add (PokemonInfoManager.create ("Meowth", pokemonType.normal));
			allPokemonInfo.Add (PokemonInfoManager.create ("Pikachu", pokemonType.electric));
			allPokemonInfo.Add (PokemonInfoManager.create ("Squirtle", pokemonType.water));
		}

		return allPokemonInfo;
	}


	// ------- Static Functions ---------

	/// <summary>
	/// Create a pokemon Info Struct with specified _name, _type, portraitName and animatorName.
	/// </summary>
	/// <param name="_name">Name.</param>
	/// <param name="_type">Type.</param>
	/// <param name="portraitName">Portrait name.</param>
	/// <param name="animatorName">Animator name.</param>
	public static PokemonInfo create(string _name, pokemonType _type, string portraitName = default(string), string animatorName =  default(string))
	{
		PokemonInfo info = new PokemonInfo();
		// set basic vars
		info.name = _name;
		info.type = _type;
		info.level = 0;

		// set portraits
		if (portraitName == default(string)) {
			portraitName = info.name.ToLower ().Substring (0, 4) + "_port";
		}
		if (animatorName == default(string)) {
			animatorName = info.name.ToLower ().Substring (0, 4) + "_anim";
		}

		info.portrait = (Texture)Resources.Load ("pokemon/" + info.name + "/" + portraitName);
		info.animator = Resources.Load ("pokemon/" + info.name + "/" + animatorName) as RuntimeAnimatorController;

		// set type balances
		info.weak = new List<pokemonType>();
		info.resistant = new List<pokemonType> ();
		info.immune = new List<pokemonType> ();
		FigureTypeBalances(ref info, info.type);

		// get attack animators
		loadAttackAnimators (ref info, info.type);


		// get icons
		info.typeIcon = (Texture)Resources.Load("images/icons/bigCircle/"+_type.ToString().ToLower());
		info.weakIcons = new List<Texture> ();
		info.resistantIcons = new List<Texture> ();
		for (int i = 0; i < info.weak.Count; i++) {
			info.weakIcons.Add ((Texture)Resources.Load ("images/icons/bigCircle/" + info.weak [i].ToString ().ToLower ()));
		}
		for (int i = 0; i < info.resistant.Count; i++) {
			info.resistantIcons.Add ((Texture)Resources.Load ("images/icons/bigCircle/" + info.resistant [i].ToString ().ToLower ()));
		}

		return info;
	}

	// todo please please please change this
	private static void FigureTypeBalances(ref PokemonInfo info ,pokemonType type)
	{
		switch (type) {
		case pokemonType.fire:
			info.weak.Add (pokemonType.water);
			info.weak.Add (pokemonType.rock);
			info.resistant.Add (pokemonType.grass);
			info.resistant.Add (pokemonType.ghost);
			break;

		case pokemonType.water:
			info.weak.Add (pokemonType.grass);
			info.weak.Add (pokemonType.electric);
			info.resistant.Add (pokemonType.fire);
			info.resistant.Add (pokemonType.water);
			info.resistant.Add (pokemonType.rock);
			break;

		case pokemonType.grass:
			info.weak.Add (pokemonType.fire);
			info.weak.Add (pokemonType.normal);
			info.resistant.Add (pokemonType.water);
			info.resistant.Add (pokemonType.grass);
			info.resistant.Add (pokemonType.electric);
			break;

		case pokemonType.ghost:
			info.weak.Add (pokemonType.fire);
			info.weak.Add (pokemonType.ghost); // todo i dont want types countering itself
			info.weak.Add (pokemonType.electric);
			info.weak.Add (pokemonType.psychic);
			info.immune.Add (pokemonType.normal);
			info.immune.Add (pokemonType.fighting);
			break;

		case pokemonType.normal:
			info.weak.Add (pokemonType.normal); // todo, again dont want types countering itself
			break;

		case pokemonType.electric:
			info.weak.Add (pokemonType.fighting);
			break;

		case pokemonType.psychic:
			info.weak.Add (pokemonType.ghost);
			info.weak.Add (pokemonType.rock);
			info.resistant.Add (pokemonType.psychic);
			break;

		case pokemonType.fighting:
			info.weak.Add (pokemonType.psychic);
			info.resistant.Add (pokemonType.rock);
			break;

		default:
			break;
		}
	}

	private static void loadAttackAnimators(ref PokemonInfo info, pokemonType type)
	{
		switch (type) {
		case pokemonType.fire:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/FireBlast") as RuntimeAnimatorController;
			break;

		case pokemonType.water:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Water") as RuntimeAnimatorController;
			break;

		case pokemonType.grass:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Grass") as RuntimeAnimatorController;
			break;

		case pokemonType.ghost:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Ghost") as RuntimeAnimatorController;
			break;

		case pokemonType.normal:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Normal") as RuntimeAnimatorController;
			break;

		case pokemonType.electric:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Electric") as RuntimeAnimatorController;
			break;

		case pokemonType.psychic:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Psychic") as RuntimeAnimatorController;

			break;

		case pokemonType.fighting:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Fighting") as RuntimeAnimatorController;
			break;
		case pokemonType.rock:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Rock") as RuntimeAnimatorController;
			break;

		default:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Fighting") as RuntimeAnimatorController;
			break;
		}
	}
}
