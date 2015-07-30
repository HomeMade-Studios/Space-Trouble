using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Text levelReached;
	public GameObject welcomeMessagePanel, creditsPanel;
	public static int maxLevel = 10;

	void Awake(){
		//PlayerPrefs.DeleteAll();
		if(PlayerPrefs.GetInt ("firstTime", 1) == 1){
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("firstTime", 0);
			OpenWelcomeMessagePanel();
		}
		levelReached.text = (PlayerPrefs.GetInt("completedLevels", 0)).ToString() + " / " + maxLevel.ToString() + " km";
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}

	public void OpenCreditsPanel() {
		creditsPanel.SetActive(true);
	}

	public void CloseCreditsPanel() {
		creditsPanel.SetActive(false);
	}

	public void OpenWelcomeMessagePanel(){
		welcomeMessagePanel.SetActive(true);
	}

	public void CloseWelcomeMessagePanel(){
		welcomeMessagePanel.SetActive(false);
	}

	public void OpenHomeMadeStudiosPlayStore(){
		Application.OpenURL("https://play.google.com/store/apps/dev?id=8610543020411511969");
	}

	public void OpenAlexandrZhelanovSoundCloud(){
		Application.OpenURL("");
	}

	public void ToLevelSelection(){
		Application.LoadLevel("LevelSelection");
	}

	public void Play(){
		PlayerPrefs.SetInt("levelToLoad", PlayerPrefs.GetInt("completedLevels", 0));
		Application.LoadLevel("Level");
	}
}
