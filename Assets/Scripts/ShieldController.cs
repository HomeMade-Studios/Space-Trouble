using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

public class ShieldController : MonoBehaviour {

	public Text shieldText;
	static Button shieldButton;
	static GameObject spaceship;

	void Awake(){
		shieldButton = gameObject.GetComponent<Button>();
	}

	void Start () {
		RefreshShieldQuantity();
	}

	void RefreshShieldQuantity(){
		SoomlaStore.RefreshInventory();
		int shieldQuantity = StoreInventory.GetItemBalance("shield_currency");
		shieldText.text = shieldQuantity.ToString();
		if(shieldQuantity <= 0){
			LockShieldButton();
		}
		else{
			UnlockShieldButton();
		}
	}

	public void UseShield(){
		print ("try");
		spaceship = GameObject.FindGameObjectWithTag("Player");
		if(spaceship != null){
			print ("ok");
			ActivateShield();
			if(StoreInventory.GetItemBalance("shield_currency") > 0){
				StoreInventory.TakeItem("shield_currency", 1);
				RefreshShieldQuantity();
			}
		}
	}

	public static void ActivateShield() {
		spaceship = GameObject.FindGameObjectWithTag("Player");
		if(spaceship != null){
			spaceship.transform.FindChild("Shield").gameObject.SetActive(true);
			LockShieldButton();
		}
	}

	public static void DisableShield() {
		spaceship = GameObject.FindGameObjectWithTag("Player");
		if(spaceship != null){
			spaceship.transform.FindChild("Shield").gameObject.SetActive(true);
			UnlockShieldButton();
		}
	}

	public static void LockShieldButton() {
		shieldButton.interactable = false;
	}

	public static void UnlockShieldButton() {
		shieldButton.interactable = true;
	}
}
