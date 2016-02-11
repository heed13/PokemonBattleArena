using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public const string mainMenuMusic = "MainMenuMusic";

	void Start()
	{
		SoundPlayer.soundPlayer.playMusic (mainMenuMusic, 1.0f);
	}
		
	public void QuickPlay()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");
	}

	public void SettingsBtnPressed()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");
	}
	public void Quit()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");

		Debug.Log ("quitting...");
		Application.Quit ();
	}
}
