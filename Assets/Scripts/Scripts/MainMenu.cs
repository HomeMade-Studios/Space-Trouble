using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text levelReached;

	void Start(){
		levelReached.text = (PlayerPrefs.GetInt("completedLevels", 0)).ToString() + " / " + GameController.maxLevel.ToString() + " Area";
		if(PlayerPrefs.GetInt("completedLevels", 0) >= GameController.maxLevel){
			GameObject.Find("PlayButton").GetComponent<Button>().interactable = false;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}

	public void OpenCreditsPopup() {
		Popup.ShowCreditsPopup();
	}

	public void OpenHelpPopup(){
		Popup.ShowHelpPopup();
	}

	public void OpenStorePopup(){
		Popup.ShowStorePopup();
	}

	public void OpenHomeMadeStudiosPlayStore(){
		Application.OpenURL("https://play.google.com/store/apps/dev?id=8610543020411511969");
	}

	public void ToLevelSelection(){
		SceneManager.LoadScene("LevelSelection");
	}

	public void Play(){
		PlayerPrefs.SetInt("levelToLoad", PlayerPrefs.GetInt("completedLevels", 0));
		SceneManager.LoadScene("Level");
	}
}
