using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public string mainMenuMusic = "MainMenuMusic";


	void Start()
	{
		SoundPlayer.soundPlayer.setMusicVolume (75.0f);
		SoundPlayer.soundPlayer.setSoundEffectsVolume (75.0f);
		SoundPlayer.soundPlayer.playMusic (mainMenuMusic,1.0f);
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
