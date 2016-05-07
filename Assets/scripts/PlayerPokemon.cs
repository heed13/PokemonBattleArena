using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPokemon : MonoBehaviour
{
	public PokemonInfo currentPokemon; // current poke info

	private bool colliderSet = false;
	// we pretty much need to know about everything... so... here it goes
	public MoveController mc;
	public AttackController ac;
	public TeamMember tm;
	public Health hp;
	public Experience xp;
	public Animator an;
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public BoxCollider2D bc;

	void Awake()
	{
		mc = GetComponent<MoveController> ();
		ac = GetComponent<AttackController> ();
		tm = GetComponent<TeamMember> ();
		hp = GetComponent<Health> ();
		xp = GetComponent<Experience> ();
		an = GetComponentInChildren<Animator> ();
		rb = GetComponentInChildren<Rigidbody2D> ();
		sr = GetComponentInChildren<SpriteRenderer> ();
		bc = GetComponentInChildren<BoxCollider2D> ();

	}
	void Start()
	{
		if (sr.sprite != null) {
			//set collider to size of sprite
			Vector2 S = sr.sprite.bounds.size;
			bc.size = S;
			colliderSet = true;
		}
	}
	void Update()
	{
		if (!colliderSet && sr.sprite != null) {
			//set collider to size of sprite
			Vector2 S = sr.sprite.bounds.size;
			bc.size = S;
			colliderSet = true;
		}
	}
	//todo this is just for testing, pls remove
	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, 100, 50), "Spawn Again")) {
			GameObject.Find ("InstantGUI").SetActive (true);
			GameObject.Find ("InstantGUI").transform.FindChild ("background").gameObject.SetActive (true);
			GameObject.Find ("InstantGUI").transform.FindChild ("Window").gameObject.SetActive (true);
		}
	}
	public void prepSprite(PokemonInfo pokemon, PlayerInfo player = default(PlayerInfo))
	{
		currentPokemon = pokemon;
		// Set weaknesses/resistances
		hp.weakAgainst = new List<pokemonType> (pokemon.weak);
		hp.resistantTo = new List<pokemonType> (pokemon.resistant);

		// Set animation controller
		an.runtimeAnimatorController = pokemon.animator;

		// set attack controller info
		ac.pokemonInfo = pokemon;
		ac.prepareProjectilePool ();
	}

	public void evolve()
	{
		prepSprite (currentPokemon.nextEvolution);
	}

}
