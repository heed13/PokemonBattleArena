using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour 
{
	public float moveChance = 1f; // what are the odds of him moving?
	public float decisionInterval = 3; // How often does this npc make a decision
	public List<RuntimeAnimatorController> animators = new List<RuntimeAnimatorController> ();
	public Animator myAnim;
	public MoveController mc;

	private bool isMoving = false;
	private Vector2 targetPos;
	private float nextDecision = 0;
	private float arrivalThreshold = .001f;

	void Awake()
	{
		if (moveChance > 1)
			moveChance = moveChance / 100;
		
		myAnim.runtimeAnimatorController = animators [Random.Range (0, animators.Count)];
	}

	void Start () 
	{
		GetComponent<BoxCollider2D> ().size = GetComponent<SpriteRenderer> ().bounds.size;
	}
	
	void FixedUpdate () 
	{
		if (Time.time >= nextDecision) {
			nextDecision = Time.time + decisionInterval;
			MakeADecision ();
		}
		mc.MoveTo (targetPos.x, targetPos.y);

	}

	void MakeADecision()
	{
		Debug.Log ("NPC Making a decision");
		bool move = (Random.Range (0.0f, 1.0f) <= moveChance) ? true : false;	
		if (!move) {
			isMoving = false;
			targetPos = new Vector2 (0, 0);
			return;
		}
		// Pick a direction
		Vector3 dir = new Vector2(0,0);
		bool vertical = Random.Range(0.0f,1.0f) < 0.5f ? true : false;
		if (vertical) {
			dir.y = Random.Range (0.0f, 1.0f) < 0.5f ? -1 : 1;
		}
		else
			dir.x = Random.Range (0.0f, 1.0f) < 0.5f ? -1 : 1;

		targetPos = dir;
	}
}
