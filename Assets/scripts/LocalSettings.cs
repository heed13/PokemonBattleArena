using UnityEngine;

/// <summary>
/// Settings. static class used to read and write player settings to the local device
/// </summary>
public static class LocalSettings 
{
	private const string musicVolumeKey = "musicVolume";
	private const string soundVolumeKey = "soundVolume";
	private const string usernameKey = "username";

	public static void setVolume(float music, float sound) 
	{
		PlayerPrefs.SetFloat (musicVolumeKey, music);
		PlayerPrefs.SetFloat (soundVolumeKey, sound);
	}
	public static float getMusicVolume()
	{
		return PlayerPrefs.GetFloat (musicVolumeKey);
	}
	public static float getSoundVolume()
	{
		return PlayerPrefs.GetFloat (soundVolumeKey);
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
