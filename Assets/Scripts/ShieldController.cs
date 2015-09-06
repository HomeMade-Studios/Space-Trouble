using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

public class ShieldController : MonoBehaviour {

	public Text shieldText;

	void Start () {
		UpdateShieldText();
	}

	void UpdateShieldText(){
		SoomlaStore.RefreshInventory();
		shieldText.text = StoreInventory.GetItemBalance("shield_currency").ToString();
	}

	public void UseShield(){
		print ("c");
		GameObject spaceShip = GameObject.FindGameObjectWithTag("Player");
		if(spaceShip != null){
			//spaceShip.GetComponent<Spaceship>().ActivateShield();
			if(StoreInventory.GetItemBalance("shield_currency") > 0){
				StoreInventory.TakeItem("shield_currency", 1);
				UpdateShieldText();
			}
		}
	}
}
