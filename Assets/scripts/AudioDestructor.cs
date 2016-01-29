using UnityEngine;
using System.Collections;

public class AudioDestructor : PoolObject {
	new public AudioSource audio;
	bool timerSet = false;
	bool secondTimerSet = false;
	float timeSet = 0;
	float checkTime = 3;
	void Awake()
	{
		 audio = GetComponent<AudioSource> ();
	}

	void LateUpdate()
	{
		if (!timerSet && audio.clip != null) {
			timerSet = true;
			timeSet = Time.time;
			float time = audio.clip.length;
			Invoke ("Destroy", time);
		} else if (timerSet && !secondTimerSet && !audio.isPlaying && Time.time - timeSet > checkTime) {
			secondTimerSet = true;
			Invoke ("Destroy", 1.0f);
		}
	}
	void OnEnable()
	{
		timerSet = false;
	}
}
