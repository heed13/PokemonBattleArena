using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TeamMember), typeof(Animator))]
public class AttackController : MonoBehaviour
{
	// Public vars
	public GameObject projectile; // This should be the same for everyone. We load info to it dynamically
	public float attackDelay = 0.5f; // How many times per second can this person attack?
	public int poolAmount = 20; // how many projectiles should be allowed at any given time?

	[System.Serializable]
	public class MyEventType : UnityEvent<HitInfo> { } // event type for a succesful hit/kill
	public MyEventType onHit; // triggered when this character hits something
	public MyEventType onKill; // triggered when this character kills something

	// Character Info
	public PlayerInfo playerInfo; // Player info, cached for quick access
	public PokemonInfo pokemonInfo; // pokemon info, cached for quick access

	// Private Vars
	private const string attackingAnimParameter = "attacking";
	private int teamId; // team id this character is on. Cached for quick access
	private Animator anim; // animator, used to display attack animations
	private List<Projectile> projectiles; // todo Remove this?

	// Private Attack vars
	private float nextAttack = 0; // time that the attack becomes available
	private bool attacking = false; // is this person currently attacking

	// ------------ Private Functions ------------
	void Awake()
	{
		anim = GetComponent<Animator> ();
		teamId = GetComponent<TeamMember> ().teamId;
	}

	void Start()
	{
		playerInfo = GameManager.gameManager.player;
	}
		
	void Update()
	{
		// Check if we are attacking
		if (attacking)
			NormalAttack ();
	}
		
	void NormalAttack()
	{
		// If our attack cooldown is over
		if (Time.time >= nextAttack) {
			nextAttack = Time.time + attackDelay;

			// loop through projectiles to find one we can use, break on first available
			for (int i = 0; i < projectiles.Count; i++) {
				if (!projectiles [i].gameObject.activeInHierarchy) {
					LaunchProjectile (projectiles [i]);
					break;
				}
			}
		}
	}
	float getMousePos()
	{
		// get mouse pos
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 vec = new Vector2 (mousePos.x, mousePos.y) - new Vector2 (transform.position.x, transform.position.y);
		return Mathf.Atan2 (vec.y, vec.x) * Mathf.Rad2Deg - 90;
	}
	void LaunchProjectile(Projectile projectile)
	{
		float deg = getMousePos (); // get mouse position
		projectile.transform.position = transform.position; // Set position to ours
		projectile.transform.eulerAngles = new Vector3 (0, 0, deg); // set rotation to the mouse
		projectile.gameObject.SetActive (true); // mark it as active
	}
	AttackInfo prepareNormalAttack()
	{
		AttackInfo atk; 
		atk.teamId = teamId; 
		atk.type = pokemonInfo.type; 
		atk.damage = 1;
		atk.pokemon = pokemonInfo;
		atk.player = playerInfo;
		atk.hitCallback = onhitCallback;
		atk.killCallback = onKillCallback;
		return atk;
	}
	void setProjectileInfo(Projectile proj)
	{
		proj.teamId = teamId; // set team id
		proj.atkInfo = prepareNormalAttack (); // pass attack info
		proj.GetComponent<Animator> ().runtimeAnimatorController = pokemonInfo.attackAnimator; // set animator
		proj.gameObject.SetActive (false); // deactivate
	}
	// ------------ Public Functions ------------
	public void prepareProjectilePool ()
	{
		if (projectiles == null) {
			// Prep projectile pool
			projectiles = new List<Projectile> ();
			for (int i = 0; i < poolAmount; i++) {
				GameObject obj = (GameObject)Instantiate (projectile);
				setProjectileInfo (obj.GetComponent<Projectile> ());
				projectiles.Add (obj.GetComponent<Projectile> ()); // add to pool
			}
		} else {
			for (int i = 0; i < projectiles.Count; i++) {
				setProjectileInfo (projectiles [i]);
			}
		}
	}
	public void SetAttacking(bool val)
	{
		anim.SetBool (attackingAnimParameter, val);
		attacking = val;
	}

	public void onhitCallback(HitInfo hit)
	{
		onHit.Invoke (hit);
	}

	public void onKillCallback(HitInfo hit)
	{
		// update score
		SendMessage("killedPlayer", hit);
		//GetComponent<PlayerScore> ().killedPlayer (hit.player);

		// gain xp
		SendMessage("gainExperience", hit.xpGiven);
		//GetComponent<Experience> ().gainExperience (hit.xpGiven);

		// any custom calls
		onKill.Invoke (hit);
	}
}
