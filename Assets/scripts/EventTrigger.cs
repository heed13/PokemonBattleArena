using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using System;

public class EventTrigger : MonoBehaviour {

	public bool isActive = false;
	public int numOfTimesToTrigger = 1;
	int timesTriggered = 0;

	[HideInInspector]
	public bool triggerPropertiesFold = true;
	[Serializable]
	public class MyEventType : UnityEvent { }
	[HideInInspector]
	public MyEventType onTrigger;


	void OnTriggerEnter(Collider col)
	{
		if (isActive && timesTriggered < numOfTimesToTrigger) {
			timesTriggered++;
			onTrigger.Invoke ();
		}
	}
}
