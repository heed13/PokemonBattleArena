using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
			info.hitSoundKey = "FireHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/FireBlast") as RuntimeAnimatorController;
			break;

		case pokemonType.water:
			info.attackSoundKey = "WaterAttack";
			info.hitSoundKey = "WaterHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Water") as RuntimeAnimatorController;
			break;

		case pokemonType.grass:
			info.attackSoundKey = "GrassAttack";
			info.hitSoundKey = "GrassHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Grass") as RuntimeAnimatorController;
			break;

		case pokemonType.ghost:
			info.attackSoundKey = "GhostAttack";
			info.hitSoundKey = "GhostHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Ghost") as RuntimeAnimatorController;
			break;

		case pokemonType.normal:
			info.attackSoundKey = "NormalAttack";
			info.hitSoundKey = "NormalHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Normal") as RuntimeAnimatorController;
			break;

		case pokemonType.electric:
			info.attackSoundKey = "ElectricAttack";
			info.hitSoundKey = "ElectricHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Electric") as RuntimeAnimatorController;
			break;

		case pokemonType.psychic:
			info.attackSoundKey = "PsychicAttack";
			info.hitSoundKey = "PsychicHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Psychic") as RuntimeAnimatorController;
			break;

		case pokemonType.fighting:
			info.attackSoundKey = "FightingAttack";
			info.hitSoundKey = "FightingHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Fighting") as RuntimeAnimatorController;
			break;
		case pokemonType.rock:
			info.attackSoundKey = "RockAttack";
			info.hitSoundKey = "RockHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Rock") as RuntimeAnimatorController;
			break;

		default:
			info.attackSoundKey = "NormalAttack";
			info.hitSoundKey = "NormalHit";
			info.attackAnimator = Resources.Load ("attacks/AttackAnimation/Fighting") as RuntimeAnimatorController;
			break;
		}
	}

}
