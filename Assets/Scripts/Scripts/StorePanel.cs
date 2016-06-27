using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla;
using System;

namespace Soomla.Store.SpaceTrouble {

	public class StorePanel : MonoBehaviour {

		public Button endlessEnergy;

		void Start(){
			CheckBlockedItem();
		}

		public void CheckBlockedItem(){
			//if(StoreInventory.GetItemBalance("endless_energy") > 0){
			//	endlessEnergy.interactable = false;
			//}
		}

		public void PurchaseItem(string itemId){
			try{
				Debug.Log("Attempt to purchase");
				//StoreInventory.BuyItem(itemId);
			}
			catch(Exception e){
				Debug.LogWarning("SOOMLA/UNITY" + e.Message);
			}
			CheckBlockedItem();
        }
	}

}
