using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer : MonoBehaviour {
	// Static var
	public static SoundPlayer soundPlayer;
	public float soundVolume = 0.4f;
	public float musicVolume = 1.0f;

	// audio clips
	public Transform audioPrefab;
	public NamedAudioClip[] audioClips;
	private AudioSource music;

	[System.Serializable]
	public struct NamedAudioClip {
		public string name;
		public AudioClip[] clips;
	}
	Dictionary<string, AudioClip[]> soundBites;

	// fading
	enum Fade {In,Out};
	float fadeTime = 4.0f;

	void Awake()
	{
		// If soundPlayer doesn't exist, this is it
		if (soundPlayer == null) {
			soundPlayer = this;
			// If soundPlayer exists, destory this
		} else if (soundPlayer != this) {
			Destroy(gameObject);
		}

		soundBites = new Dictionary<string, AudioClip[]> ();
		for (int i = 0; i < audioClips.Length; i++) {
			soundBites.Add (audioClips [i].name, audioClips [i].clips);
		}
	}

	public void playSound(string key, Vector2 location)
	{
		AudioClip[] clips = null;
		if (soundBites.ContainsKey (key)) {
			clips = soundBites [key];
		}
		if (clips != null) {
			Transform audioSourceTransform = EZ_Pooling.EZ_PoolManager.Spawn (audioPrefab, new Vector3(location.x, location.y, 0), Quaternion.identity);
			AudioSource source = audioSourceTransform.GetComponent<AudioSource> ();
			if (source.isPlaying) {
				Debug.Log ("WTF!!! the sound players isnt supposed to overlap audio already going!!");
			}
			source.clip = clips [Random.Range (0, clips.Length)];
			source.volume = soundVolume;
			source.Play ();
		}
	}
	public void playMusic(string key)
	{
		AudioClip[] clips = null;
		if (soundBites.ContainsKey (key)) {
			clips = soundBites [key];
		}
		if (clips != null) {
			if (music == null) {
				setMusic (key, clips);
				StartCoroutine(FadeMusic(music,fadeTime,Fade.In));
			}
			else {
				StartCoroutine (FadeMusic (music, fadeTime, Fade.Out, (bool value) => {
					setMusic(key, clips);
					StartCoroutine (FadeMusic (music, fadeTime, Fade.In));
				}));
			}

		}
	}
	void setMusic(string key, AudioClip[] clips)
	{
		Transform audioSourceTransform = EZ_Pooling.EZ_PoolManager.Spawn (audioPrefab, Vector3.zero, Quaternion.identity);
		music = audioSourceTransform.GetComponent<AudioSource> ();
		music.clip = clips [Random.Range (0, clips.Length)];
		music.loop = true;
		music.volume = musicVolume;
	}


	IEnumerator FadeMusic(AudioSource audio, float timer, Fade fadeType, System.Action<bool> onComplete = null)
	{
		float start = fadeType == Fade.In ? 0.0f : musicVolume;
		float end = fadeType == Fade.In ? musicVolume : 0.0f;
		float i = 0.0f;
		float step = musicVolume / timer * Time.deltaTime;

		if (fadeType == Fade.In)
			audio.Play ();
		
		while (i < musicVolume) {
			i += step;
			audio.volume = Mathf.Lerp (start, end, i);
			yield return 0;
		}
		if (fadeType == Fade.Out)
			audio.Stop ();

		if (onComplete != null)
			onComplete (true);
		yield return null;
	}

}
