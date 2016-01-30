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
	}

	public void saveInfo()
	{
		GameManager.manager.saveUsername (usernameTextbox.text); // todo gm shouldn't be in charge of this
		SoundPlayer.soundPlayer.setMusicVolume(musicVolumeSlider.value);
		SoundPlayer.soundPlayer.setSoundEffectsVolume(soundEffectsVolumeSlider.value);

		SoundPlayer.soundPlayer.playSound ("MenuClick");
	}
	public void backBtnPressed()
	{
		SoundPlayer.soundPlayer.playSound ("MenuClick");
		this.gameObject.SetActive (false);
	}
}
