using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {
	public string username;
	public string nickname;
	public string pokemonName;
	public int score;

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



			Destroy (gameObject);
		}
	}
	public void prepSprite(CharacterInfo info)
	{
		Debug.Log (info.animator);
		gameObject.tag = "Player";
		pokemonName = info.name;
	
		an.runtimeAnimatorController = info.animator;

		ac.attackAnim = info.attackAnimator;



	}


}
