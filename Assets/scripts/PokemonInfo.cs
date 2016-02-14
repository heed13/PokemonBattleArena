using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum pokemonType {
	none,
	fire,
	water,
	rock,
	fighting,
	electric,
	normal,
	psychic,
	ghost,
	grass,
	count
}

public struct PokemonInfo 
{
	public string name; // name of pokemon
	public int level; // current level of pokemon
	public pokemonType type; // pokemons elemental type
	public List<pokemonType> weak; // what the pokemon is weak to
	public List<pokemonType> resistant; // what the pokemon is resistant to
	public List<pokemonType> immune; // what the pokemon is immune to. PS I hate that this exists

	public Texture portrait; // mug shot of the pokemon
	public Texture typeIcon; // icon of this pokemons type
	public List<Texture> weakIcons; // icons of this pokemons weaknesses
	public List<Texture> resistantIcons; // icons of this pokemons resistances
	public RuntimeAnimatorController animator; // what animator does this pokemon use?
	public RuntimeAnimatorController attackAnimator; // what attack does this pokemon use? todo: this will probably change to some kind of dict later on

	public string attackSoundKey; // the sound key that should be played when this pokemon attacks
	public string hitSoundKey; // the sound key that should be played when this pokemon hits something
}

public class PokemonInfoHandler
{
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
			info.attackSoundKey = "FireAttack";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/FireBlast") as RuntimeAnimatorController;
			break;

		case pokemonType.water:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Water") as RuntimeAnimatorController;
			break;

		case pokemonType.grass:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Grass") as RuntimeAnimatorController;
			break;

		case pokemonType.ghost:
			info.attackSoundKey = "GhostAttack";
			info.hitSoundKey = "GhostHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Ghost") as RuntimeAnimatorController;
			break;

		case pokemonType.normal:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Normal") as RuntimeAnimatorController;
			break;

		case pokemonType.electric:
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Electric") as RuntimeAnimatorController;
			break;

		case pokemonType.psychic:
			info.attackSoundKey = "PsychicAttack";
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
