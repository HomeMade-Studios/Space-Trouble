using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Text levelReached;
	public static int maxLevel = 10;

	void Awake(){
		PlayerPrefs.DeleteAll(); ///ELIMINARE PER LA BUILD FINALE!!
		levelReached.text = (PlayerPrefs.GetInt("completedLevels", 0)).ToString() + " / " + maxLevel.ToString() + " km";
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}

	public void ToLevelSelection(){
		Application.LoadLevel("LevelSelection");
	}

	public void Play(){
		PlayerPrefs.SetInt("levelToLoad", PlayerPrefs.GetInt("completedLevels", 0));
		Application.LoadLevel("Level");
	}
}
