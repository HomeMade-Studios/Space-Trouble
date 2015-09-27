using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

public class MainMenu : MonoBehaviour {

	public Text levelReached;
	public GameObject helpPanel, creditsPanel, storePanel;

	void Start(){
		levelReached.text = (PlayerPrefs.GetInt("completedLevels", 0)).ToString() + " / " + GameController.maxLevel.ToString() + " Area";
		if(PlayerPrefs.GetInt("completedLevels", 0) >= GameController.maxLevel){
			GameObject.Find("PlayButton").GetComponent<Button>().interactable = false;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!helpPanel.activeSelf && !creditsPanel.activeSelf && !storePanel.activeSelf)
				Application.Quit();
			else{
				CloseHelpPanel();
				CloseCreditsPanel();
				CloseStorePanel();
			}
		}
	}

	public void OpenCreditsPanel() {
		creditsPanel.SetActive(true);
	}

	public void CloseCreditsPanel() {
		creditsPanel.SetActive(false);
	}

	public void OpenHelpPanel(){
		helpPanel.SetActive(true);
	}

	public void CloseHelpPanel(){
		helpPanel.SetActive(false);
	}

	public void OpenStorePanel(){
		storePanel.SetActive(true);
	}
	
	public void CloseStorePanel(){
		storePanel.SetActive(false);
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
