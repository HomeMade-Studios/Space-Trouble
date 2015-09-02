using UnityEngine;
using System.Collections;
using System;

public class FuelController : MonoBehaviour {
	
	public static int currentFuel, maxFuel = 30;
	DateTime referDate;
	int lastFuelRecharge;
	int currentTime;

	void Start () {
		referDate = new DateTime(2000, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		lastFuelRecharge = PlayerPrefs.GetInt("lastFuelRecharge", 0);

		if(lastFuelRecharge == 0){
			lastFuelRecharge = (int)(DateTime.UtcNow - referDate).TotalSeconds;
			PlayerPrefs.SetInt("lastFuelRecharge", lastFuelRecharge);
		}
	}

	void Update () {
		currentTime = (int)(DateTime.UtcNow - referDate).TotalSeconds;
		if(currentTime - lastFuelRecharge >= 300){
			RefillFuel(1);
			lastFuelRecharge = currentTime;
			PlayerPrefs.SetInt("lastFuelRecharge", lastFuelRecharge);
		}
	}

	public static void RefillFuel(int refillValue){
		currentFuel += refillValue;
		if(currentFuel > maxFuel)
			currentFuel = maxFuel;
	}
}
