using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(AttackController))]
[RequireComponent(typeof(TeamMember))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Experience))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerScore))]
public class PlayerSprite : MonoBehaviour {

	private bool colliderSet = false;
	// we pretty much need to know about everything... so... here it goes
	private MoveController mc;
	private AttackController ac;
	private TeamMember tm;
	private Health hp;
	private Experience xp;
	private Animator an;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private BoxCollider2D bc;

	void Awake()
	{
		mc = GetComponent<MoveController> ();
		ac = GetComponent<AttackController> ();
		tm = GetComponent<TeamMember> ();
		hp = GetComponent<Health> ();
		xp = GetComponent<Experience> ();
		an = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		bc = GetComponent<BoxCollider2D> ();

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
	public void prepSprite(PokemonInfo info)
	{
		gameObject.tag = "Player";
	
		// Set weaknesses/resistances
		hp.weakAgainst = new List<pokemonType> (info.weak);
		hp.resistantTo = new List<pokemonType> (info.resistant);

		// Set animation controller
		an.runtimeAnimatorController = info.animator;

		// set attack controller info
		ac.pokemonInfo = info;
	}


}
