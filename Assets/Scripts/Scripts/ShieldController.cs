using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

public class ShieldController : MonoBehaviour {

	public Text shieldText;
	static Button shieldButton;
	static GameObject spaceship;

	void Start () {
		shieldButton = GameObject.Find ("ShieldButton").GetComponent<Button>();
		InvokeRepeating("RefreshShieldQuantity", 0f, 1f);
	}

	public void RefreshShieldQuantity(){
		int shieldQuantity = PlayerPrefs.GetInt("shield", 0);

		shieldText.text = shieldQuantity.ToString();
		if(shieldQuantity <= 0){
			LockShieldButton();
		}
	}

	public void UseShield(){
		spaceship = GameObject.FindGameObjectWithTag("Player");
		if(spaceship != null){
			if (PlayerPrefs.GetInt("shield", 0) > 0) {
				PlayerPrefs.SetInt("shield", PlayerPrefs.GetInt("shield", 0) - 1);
				RefreshShieldQuantity();
				ActivateShield();
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
			spaceship.transform.FindChild("Shield").gameObject.SetActive(false);
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
