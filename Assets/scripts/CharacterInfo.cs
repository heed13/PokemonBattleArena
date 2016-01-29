using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterInfo {
	public enum characterTypes {
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

	public string name;

	public characterTypes type;
	public List<characterTypes> weak;
	public List<characterTypes> resistant;
	public List<characterTypes> immune;

	public List<Sprite> mugRotation;
	public Texture portrait;
	public RuntimeAnimatorController animator;
	public RuntimeAnimatorController attackAnimator;

	public CharacterInfo(string _name, characterTypes _type, string portraitName = default(string), string animatorName =  default(string))
	{
		// set basic vars
		name = _name;
		type = _type;

		// set portraits
		if (portraitName == default(string)) {
			portraitName = name.ToLower ().Substring (0, 4) + "_port";
		}
		if (animatorName == default(string)) {
			animatorName = name.ToLower ().Substring (0, 4) + "_anim";
		}
		portrait = (Texture)Resources.Load ("pokemon/" + name + "/" + portraitName);
		animator = Resources.Load ("pokemon/" + name + "/" + animatorName) as RuntimeAnimatorController;

		// set type balances
		weak = new List<characterTypes>();
		resistant = new List<characterTypes> ();
		immune = new List<characterTypes> ();
		FigureTypeBalances(type);
		loadAttackAnimators (type);
	
	}
	public CharacterInfo()
	{
	}

	// todo please please please change this
	private void FigureTypeBalances(characterTypes type)
	{
		switch (type) {
		case characterTypes.fire:
			weak.Add (characterTypes.water);
			weak.Add (characterTypes.rock);
			resistant.Add (characterTypes.grass);
			resistant.Add (characterTypes.ghost);
			break;

		case characterTypes.water:
			weak.Add (characterTypes.grass);
			weak.Add (characterTypes.electric);
			resistant.Add (characterTypes.fire);
			resistant.Add (characterTypes.water);
			resistant.Add (characterTypes.rock);
			break;

		case characterTypes.grass:
			weak.Add (characterTypes.fire);
			weak.Add (characterTypes.normal);
			resistant.Add (characterTypes.water);
			resistant.Add (characterTypes.grass);
			resistant.Add (characterTypes.electric);
			break;

		case characterTypes.ghost:
			weak.Add (characterTypes.fire);
			weak.Add (characterTypes.ghost); // todo i dont want types countering itself
			weak.Add (characterTypes.electric);
			weak.Add (characterTypes.psychic);
			immune.Add (characterTypes.normal);
			immune.Add (characterTypes.fighting);
			break;

		case characterTypes.normal:
			weak.Add (characterTypes.normal); // todo, again dont want types countering itself
			break;

		case characterTypes.electric:
			weak.Add (characterTypes.fighting);
			break;

		case characterTypes.psychic:
			weak.Add (characterTypes.ghost);
			weak.Add (characterTypes.rock);
			resistant.Add (characterTypes.psychic);
			break;

		case characterTypes.fighting:
			weak.Add (characterTypes.psychic);
			resistant.Add (characterTypes.rock);
			break;

		default:
			break;
		}
	}

	private void loadAttackAnimators(characterTypes type)
	{
		switch (type) {
		case characterTypes.fire:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/FireBlast") as RuntimeAnimatorController;
			break;

		case characterTypes.water:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Water") as RuntimeAnimatorController;
			break;

		case characterTypes.grass:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Grass") as RuntimeAnimatorController;
			break;

		case characterTypes.ghost:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Ghost") as RuntimeAnimatorController;
			break;

		case characterTypes.normal:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Normal") as RuntimeAnimatorController;
			break;

		case characterTypes.electric:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Electric") as RuntimeAnimatorController;
			break;

		case characterTypes.psychic:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Psychic") as RuntimeAnimatorController;

			break;

		case characterTypes.fighting:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Fighting") as RuntimeAnimatorController;
			break;
		case characterTypes.rock:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Rock") as RuntimeAnimatorController;
			break;

		default:
			attackAnimator = Resources.Load ("attacks/AttackAnimation/Fighting") as RuntimeAnimatorController;
			break;
		}
	}

}
