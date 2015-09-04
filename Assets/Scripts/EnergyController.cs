using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class EnergyController : MonoBehaviour {
	
	public static int currentEnergy, maxEnergy;
	public Text energyText;
	DateTime referDate;
	int lastEnergyRecharge;							//Second from referDate to last automated recharge
	int autoRechargeDeltaTime;						//Time in second before fuel is increased by 1
	int currentTime;								//Second since referDate (1/1/2000)

	void Awake() {
		maxEnergy = 30;
		currentEnergy = PlayerPrefs.GetInt("Energy");
		autoRechargeDeltaTime = 10;

		referDate = new DateTime(2000, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		lastEnergyRecharge = PlayerPrefs.GetInt("lastEnergyRecharge", 0);
		
		if(lastEnergyRecharge == 0){
			lastEnergyRecharge = (int)(DateTime.UtcNow - referDate).TotalSeconds;
			PlayerPrefs.SetInt("lastEnergyRecharge", lastEnergyRecharge);
		}
	}

	void Start () {
		CheckEnergyUpgrade();
	}

	void Update () {
		CheckRechargeTime();
		WriteEnergyText();
	}

	public static void RechargeEnergy(int rechargeValue){    //Recharge energy by value
		currentEnergy += rechargeValue;
		if(currentEnergy > maxEnergy)
			currentEnergy = maxEnergy;
		PlayerPrefs.SetInt("Energy", currentEnergy);
	}

	void CheckEnergyUpgrade(){								//Check if player bought some Upgrade and apply it

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
		energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
	}

	public string timeToNextRecharge(){				//Return a string representing time to next recharge (mm:ss)
		int seconds = currentTime - lastEnergyRecharge;
		int minutes = seconds / 60;
		seconds -= minutes * 60;

		string timeString = minutes.ToString("D2") + ":" + seconds.ToString("D2");

		return timeString;
	}					
}
