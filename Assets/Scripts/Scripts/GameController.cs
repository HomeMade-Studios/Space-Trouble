using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public MainMenu mainMenu;
	public Toggle audioToggle;
	public static int maxLevel = 40;

	void Start () {

		if (Application.systemLanguage == SystemLanguage.Italian)
			Language.Initialize("italian");
		else
			Language.Initialize("english");

		if (PlayerPrefs.GetInt("firstTime", 1) == 1) {
			FirstTime();
		}
		audioToggle.isOn = PlayerPrefs.GetInt("audioVolume", 1) == 1 ? true : false;
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
	}

	void FirstTime(){
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("energy", EnergyController.maxEnergy);
		PlayerPrefs.SetInt("shield", 3);
		Popup.ShowHelpPopup();
		Debug.Log(EnergyController.maxEnergy);
		PlayerPrefs.SetInt("firstTime", 0);
	}

	public void InvertAudio(){
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
		PlayerPrefs.SetInt("audioVolume", (int)AudioListener.volume);
	}
}
