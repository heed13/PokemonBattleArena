using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]
public class Video : MonoBehaviour {
	public MovieTexture movie;
	private AudioSource audio;

	void Start () 
	{
		StartCoroutine ("waitForMovie");

	}
	IEnumerator waitForMovie()
	{
		while (!movie.isReadyToPlay) {
			yield return 0;
		}
		GetComponent<InstantGuiElement> ().style.main.texture = movie as MovieTexture;
		//GetComponent<RawImage> ().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;

		movie.Play ();
		audio.Play ();
		yield return null;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && movie.isPlaying) {
			movie.Pause ();
			audio.Pause ();
		} else if (Input.GetKeyDown (KeyCode.Space) && !movie.isPlaying) {
			movie.Play ();
			audio.Play ();
		}
	}
}
