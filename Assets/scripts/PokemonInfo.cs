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

