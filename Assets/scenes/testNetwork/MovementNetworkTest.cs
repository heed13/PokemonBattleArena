using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

[NetworkSettings(channel=0,sendInterval = 0.033f)]
public class MovementNetworkTest : NetworkBehaviour {
	public GameObject bulletPrefab;

	[SyncVar(hook = "SyncPositionValues")]
	private Vector3 syncPos;

	[SerializeField] Transform myTransform;
	float lerpRate;
	private float normalLerpRate  = 30;
	private float fastLerpRate = 40;
	[SerializeField] Rigidbody2D rb;

	private Vector3 lastPos;
	private float threshold = 0.1f;

	private NetworkClient nClient;
	private int latency;
	private Text latencyText;

	private List<Vector3> syncPosList = new List<Vector3>();
	[SerializeField] private bool useHistoricalLerping = false;
	private float closeEnough = 0.11f;

	void Start()
	{
		myTransform = transform;
		nClient = GameObject.Find ("NetworkManager").GetComponent<NetworkManager> ().client;
		latencyText = GameObject.Find ("LatencyText").GetComponent<Text> ();
		lerpRate = normalLerpRate;
	}
		
	void FixedUpdate()
	{
		TransmitPosition ();
	}

	[Client]
	void SyncPositionValues(Vector3 latestPos)
	{
		syncPos = latestPos;
		syncPosList.Add (syncPos);
	}
	void LerpPosition()
	{
		if (useHistoricalLerping) {
			HistoricalLerping ();
		} else {
			OrdinaryLerping ();
		}
	}

	void HistoricalLerping()
	{
		if (syncPosList.Count > 0) {
			myTransform.position = Vector3.Lerp(myTransform.position, syncPosList[0], Time.deltaTime * lerpRate);
			if (Vector3.Distance (myTransform.position, syncPosList [0]) < closeEnough) {
				syncPosList.RemoveAt (0);//
			}
			if (syncPosList.Count > 10) {
				lerpRate = fastLerpRate;
			} else {
				lerpRate = normalLerpRate;
			}
			Debug.Log (syncPosList.Count);
		}
	}
	void OrdinaryLerping()
	{
		myTransform.position = Vector3.Lerp (myTransform.position, syncPos, Time.deltaTime * lerpRate);
	}


	// Update is called once per frame
	void Update () 
	{
		if (isLocalPlayer) {
			
			var x = Input.GetAxis ("Horizontal") * 0.1f;
			var y = Input.GetAxis ("Vertical") * 0.1f;

			transform.Translate (x, y, 0);
			//rb.velocity = new Vector3 (x, y, 0);

			if (Input.GetKeyDown (KeyCode.Space)) {
				CmdFire ();
			}
		} else {
			LerpPosition ();
		}
		ShowLatency ();

	}
	public override void OnStartLocalPlayer ()
	{
		GetComponentInChildren<SpriteRenderer> ().material.color = Color.red;
	}
	[Command]
	void CmdFire()
	{
		//create locally
		var bullet = (GameObject)Instantiate (bulletPrefab, transform.position - transform.forward, Quaternion.identity);

		bullet.GetComponent<Rigidbody2D> ().velocity = -transform.up*4;

		//spawn on clients
		NetworkServer.Spawn (bullet);

		Destroy (bullet, 2.0f);
	}
	[Command]
	void CmdProvidePositionToServer(Vector2 pos)
	{
		syncPos = pos;
	}
	[ClientCallback]
	void TransmitPosition()
	{
		if (isLocalPlayer && Vector3.Distance (myTransform.position, lastPos) > threshold) {
			CmdProvidePositionToServer (myTransform.position);
		}
	}

	void ShowLatency()
	{
		if (isLocalPlayer) {
			latency = nClient.GetRTT ();
			latencyText.text = latency.ToString ();
		}
	}

}
