using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {
	public InstantGuiInputText usernameTextbox;
	public InstantGuiSlider musicVolumeSlider;
	public InstantGuiSlider soundEffectsVolumeSlider;


	void Start()
	{
		getObjects ();
		setDefaults ();

	}

	void OnEnable()
	{
		setDefaults ();
		getObjects ();
	}

	void getObjects()
	{
		if (usernameTextbox == null) {
			usernameTextbox = GameObject.Find ("usernameTxt").GetComponent<InstantGuiInputText> ();
			musicVolumeSlider = GameObject.Find ("musicVolumeSlider").GetComponent<InstantGuiSlider> ();
			musicVolumeSlider = GameObject.Find ("soundEffectsVolumeSlider").GetComponent<InstantGuiSlider> ();
		}
	}

	void setDefaults()
	{
		musicVolumeSlider.value = SoundPlayer.soundPlayer.musicVolume*100;
		soundEffectsVolumeSlider.value = SoundPlayer.soundPlayer.soundVolume*100;
		usernameTextbox.text = GameManager.gameManager.player.username;
	}

	public void saveInfo()
	{
		// Save username, volume, etc...
		GameManager.gameManager.player.username = usernameTextbox.text;
		SoundPlayer.soundPlayer.setMusicVolume(musicVolumeSlider.value);
		SoundPlayer.soundPlayer.setSoundEffectsVolume(soundEffectsVolumeSlider.value);

		// Tell settings to save it off to player prefs
		LocalSettings.setVolume (musicVolumeSlider.value, soundEffectsVolumeSlider.value);
		LocalSettings.setUsername (usernameTextbox.text);

		// play click sound
		SoundPlayer.soundPlayer.playSound ("MenuClick");
	}
	public void backBtnPressed()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");
		this.gameObject.SetActive (false);
	}
}
