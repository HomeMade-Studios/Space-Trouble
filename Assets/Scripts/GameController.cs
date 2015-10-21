using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public MainMenu mainMenu;
	public Toggle audioToggle;
	public static int maxLevel = 30;

	void Start () {
		PlayerPrefs.DeleteAll();			//Togliere
		if(PlayerPrefs.GetInt ("firstTime", 1) == 1){
			FirstTime();
		}
		SoomlaStore.RefreshMarketItemsDetails();
		SoomlaStore.RefreshInventory();
		audioToggle.isOn = PlayerPrefs.GetInt("AudioVolume", 1) == 1 ? true : false;
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
	}

	void Update () {
	
	}

	void FirstTime(){
		PlayerPrefs.DeleteAll();
		EnergyController.RechargeEnergy(EnergyController.maxEnergy);
		StoreInventory.GiveItem("shield_currency", 3);
		Popup.ShowHelpPopup();
		PlayerPrefs.SetInt("firstTime", 0);
	}

	public void InvertAudio(){
		AudioListener.volume = 1 * audioToggle.isOn.GetHashCode();
		PlayerPrefs.SetInt("AudioVolume", (int)AudioListener.volume);
	}
}
