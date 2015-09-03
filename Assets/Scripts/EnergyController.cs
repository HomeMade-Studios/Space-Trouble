using UnityEngine;
using System.Collections;
using System;

public class EnergyController : MonoBehaviour {
	
	public static int currentEnergy, maxEnergy;
	DateTime referDate;
	int lastEnergyRecharge;							//Second from referDate to last automated recharge
	int autoRechargeDeltaTime;						//Time in second before fuel is increased by 1
	int currentTime;								//Second since referDate (1/1/2000)

	void Awake() {
		maxEnergy = 30;
		autoRechargeDeltaTime = 300;

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
	}

	public static void RechargeEnergy(int refillValue){
		currentEnergy += refillValue;
		if(currentEnergy > maxEnergy)
			currentEnergy = maxEnergy;
	}

	void CheckEnergyUpgrade(){

	}

	void CheckRechargeTime(){
		currentTime = (int)(DateTime.UtcNow - referDate).TotalSeconds;
		if(currentTime - lastEnergyRecharge >= autoRechargeDeltaTime){
			RechargeEnergy(1);
			lastEnergyRecharge = currentTime;
			PlayerPrefs.SetInt("lastEnergyRecharge", lastEnergyRecharge);
		}
	}

	public string timeToNextRecharge(){
		int seconds = currentTime - lastEnergyRecharge;
		int minutes = seconds / 60;
		seconds -= minutes * 60;

		string timeString = minutes.ToString() + ":" + seconds.ToString();

		return timeString;
	}
}
