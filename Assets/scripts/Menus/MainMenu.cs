using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {


	public void QuickPlay()
	{
//		SceneManager.LoadScene ("SCENE");
//		Application.LoadLevel (1); // outdated
	}

	public void Quit()
	{
		Debug.Log ("quitting...");
		Application.Quit ();
	}
}
