//using UnityEngine;
//using System.Collections;
//
//public class NetworkPlayer : MonoBehaviour
//{
//	private Animator anim;
//	private AttackController ac;
//
//	bool isAlive = true;
//	Vector3 lastKnownPos;
//	float lerpSmoothing = 5f;
//
//	void Start()
//	{
//		anim = GetComponent<Animator> ();
//		ac = GetComponent<AttackController> ();
//		if (photonView.isMine) {
//			GetComponent<PlayerInput> ().enabled = true;
//			GetComponent<PlayerScore> ().enabled = true;
//		} else {
//			//StartCoroutine ("moveToPosition");
//		}
//	}
//	
//	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//	{
//		if (stream.isWriting) {
//			
//			// Send position 
//			stream.SendNext (transform.position);
//			// Send Anim params
//			stream.SendNext (anim.GetBool(MoveController.animMovingParam));
//			stream.SendNext (anim.GetBool (AttackController.animAttackingParam));
//			stream.SendNext (anim.GetFloat (MoveController.animDirXParam));
//			stream.SendNext (anim.GetFloat (MoveController.animDirYParam));
//			stream.SendNext (anim.GetFloat (MoveController.animRotationParam));
//			// Send attack info
//			stream.SendNext(ac.attacking);
//
//		} else {
//			// get position
//			lastKnownPos = (Vector3)stream.ReceiveNext ();
//			// get anim vars
//			anim.SetBool(MoveController.animMovingParam, (bool)stream.ReceiveNext ());
//			anim.SetBool(AttackController.animAttackingParam, (bool)stream.ReceiveNext ());
//			anim.SetFloat(MoveController.animDirXParam, (float)stream.ReceiveNext ());
//			anim.SetFloat(MoveController.animDirYParam, (float)stream.ReceiveNext ());
//			anim.SetFloat(MoveController.animRotationParam, (float)stream.ReceiveNext ());
//			// Send attack info
//			ac.attacking = (bool)stream.ReceiveNext();
//		}
//
//	}
//
//	void Update()
//	{
//		if (!photonView.isMine) {
//			transform.position = Vector3.Lerp (transform.position, lastKnownPos, lerpSmoothing * Time.deltaTime);
//		}
//	}
//	IEnumerator moveToPosition()
//	{
//		while (isAlive) {
//			yield return null;
//		}
//	}
//
//
//}
