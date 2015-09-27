using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using Soomla.Store;

public class EnergyController : MonoBehaviour {

	public Text energyText, lastTimeText;
	public static int currentEnergy, maxEnergy;
	public static bool endlessEnergy;
	static DateTime referDate;
	static int lastEnergyRecharge;							//Second from referDate to last automated recharge
	static int autoRechargeDeltaTime;						//Time in second before fuel is increased by 1
	static int currentTime;								//Second since referDate (1/1/2000)


	void Awake() {
		maxEnergy = 30;
		currentEnergy = PlayerPrefs.GetInt("energy");
		autoRechargeDeltaTime = 300;

		referDate = new DateTime(2000, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		lastEnergyRecharge = PlayerPrefs.GetInt("lastEnergyRecharge", 0);
		
		if(lastEnergyRecharge == 0){
			lastEnergyRecharge = (int)(DateTime.UtcNow - referDate).TotalSeconds;
			PlayerPrefs.SetInt("lastEnergyRecharge", lastEnergyRecharge);
		}
	}

	void Start() {
//		StoreEvents.OnMarketPurchase += onMarketPurchase;
		InvokeRepeating("CheckEnergyUpgrade", 0f, 1f);
	}

	void Update () {
		if(!endlessEnergy){
			CheckRechargeTime();
		}
		if(currentEnergy < maxEnergy && !endlessEnergy){
			lastTimeText.text = timeToNextRecharge();
		}
		else{
			lastTimeText.text = "";
		}
		WriteEnergyText();
	}

//	void onMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string, string> extra) {
//		if(pvi.ItemId == "fill_energy"){
//			RechargeEnergy(maxEnergy);
//		}
//	}

	public static void RechargeEnergy(int rechargeValue){    //Recharge energy by value
		if(!endlessEnergy){
			currentEnergy += rechargeValue;
			if(currentEnergy > maxEnergy)
				currentEnergy = maxEnergy;
			PlayerPrefs.SetInt("energy", currentEnergy);
			PlayerPrefs.SetInt("lastEnergyRecharge", lastEnergyRecharge);
		}
	}

	void CheckEnergyUpgrade(){								//Check if player bought some Upgrade and apply it
		if(StoreInventory.GetItemBalance("endless_energy") > 0){
			endlessEnergy = true;
		}
		else{
			endlessEnergy = false;
		}
		if(StoreInventory.GetItemBalance("refill_energy") > 0){
			RechargeEnergy(maxEnergy);
			StoreInventory.TakeItem("refill_energy", 1);
		}
	}

	void CheckRechargeTime(){								//Check if recharging time is passed, if true recharge by 1
		currentTime = (int)(DateTime.UtcNow - referDate).TotalSeconds;
		if(currentEnergy < maxEnergy){
			if(currentTime - lastEnergyRecharge >= autoRechargeDeltaTime){
				RechargeEnergy(1);
				lastEnergyRecharge += autoRechargeDeltaTime;
		
				PlayerPrefs.SetInt("lastEnergyRecharge", lastEnergyRecharge);
			}
		}
		else{
			lastEnergyRecharge = currentTime;
		}
	}

	void WriteEnergyText(){
		if(!endlessEnergy)
			energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
		else
			energyText.text = "Infinite";
	}

	string timeToNextRecharge(){				//Return a string representing time to next recharge (mm:ss)
		int seconds = autoRechargeDeltaTime - (currentTime - lastEnergyRecharge);
		int minutes = seconds / 60;
		seconds -= minutes * 60;

		string timeString = minutes.ToString() + ":" + seconds.ToString("D2");

		return timeString;
	}					
}
