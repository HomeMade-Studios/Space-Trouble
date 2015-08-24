using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Text levelReached;
	public GameObject welcomeMessagePanel, creditsPanel;
	public Toggle audioToggle;
	public static int maxLevel = 30;

	void Awake(){
		if(PlayerPrefs.GetInt ("firstTime", 1) == 1){
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("firstTime", 0);
			OpenWelcomeMessagePanel();
		}
		audioToggle.isOn = PlayerPrefs.GetInt("AudioVolume", 1) == 1 ? true : false;
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
		levelReached.text = (PlayerPrefs.GetInt("completedLevels", 0)).ToString() + " / " + maxLevel.ToString() + " AU";
		if(PlayerPrefs.GetInt("completedLevels", 0) == maxLevel){
			GameObject.Find("PlayButton").GetComponent<Button>().interactable = false;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!welcomeMessagePanel.activeSelf && !creditsPanel.activeSelf)
				Application.Quit();
			else{
				welcomeMessagePanel.SetActive(false);
				creditsPanel.SetActive(false);
			}
		}
	}

	public void InvertAudio(){
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
		PlayerPrefs.SetInt("AudioVolume", (int)AudioListener.volume);
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

	public void OpenGamePlayStore(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.homemadestudios.spacetrouble");
	}

	public void OpenHomeMadeStudiosPlayStore(){
		Application.OpenURL("https://play.google.com/store/apps/dev?id=8610543020411511969");
	}

	public void OpenAlexandrZhelanovSoundCloud(){
		Application.OpenURL("https://soundcloud.com/alexandr-zhelanov");
	}

	public void ToLevelSelection(){
		Application.LoadLevel("LevelSelection");
	}

	public void Play(){
		PlayerPrefs.SetInt("levelToLoad", PlayerPrefs.GetInt("completedLevels", 0));
		Application.LoadLevel("Level");
	}
}
