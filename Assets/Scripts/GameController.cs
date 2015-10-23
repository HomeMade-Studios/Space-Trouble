using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public MainMenu mainMenu;
	public Toggle audioToggle;
	public static int maxLevel = 41;

	void Awake() {
		if (PlayerPrefs.GetInt("firstTime", 1) == 1) {
			FirstTime();
		}
	}

	void Start () {
		SoomlaStore.RefreshMarketItemsDetails();
		SoomlaStore.RefreshInventory();
		audioToggle.isOn = PlayerPrefs.GetInt("AudioVolume", 1) == 1 ? true : false;
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
	}

	void Update () {
	
	}

	void FirstTime(){
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("energy", EnergyController.maxEnergy);
		StoreInventory.GiveItem("shield_currency", 3);
		Popup.ShowHelpPopup();
		PlayerPrefs.SetInt("firstTime", 0);
	}

	public void InvertAudio(){
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
		PlayerPrefs.SetInt("AudioVolume", (int)AudioListener.volume);
	}
}
