using UnityEngine;

/// <summary>
/// Settings. static class used to read and write player settings to the local device
/// </summary>
public static class LocalSettings 
{
	private const string musicVolumeKey = "musicVolume";
	private const string soundVolumeKey = "soundVolume";
	private const string usernameKey = "username";
	private const string volumeStateKey = "musicVolumeSet";
	private const string soundStateKey = "soundVolumeSet";


	public static void setVolume(float music, float sound) 
	{
		PlayerPrefs.SetInt (volumeStateKey, 1);
		PlayerPrefs.SetInt (soundStateKey, 1);
		PlayerPrefs.SetFloat (musicVolumeKey, music);
		PlayerPrefs.SetFloat (soundVolumeKey, sound);
	}
	public static float getMusicVolume()
	{
		if (PlayerPrefs.GetInt (volumeStateKey) != 0) {
			return PlayerPrefs.GetFloat (musicVolumeKey);
		}
		return -1.0f;
	}
	public static float getSoundVolume()
	{
		if (PlayerPrefs.GetInt (volumeStateKey) != 0) {
			return PlayerPrefs.GetFloat (soundVolumeKey);
		}
		return -1.0f;
	}
	public static void setUsername(string name)
	{
		PlayerPrefs.SetString (usernameKey, name);
	}
	public static string getUsername()
	{
		return PlayerPrefs.GetString (usernameKey);
	}
}
