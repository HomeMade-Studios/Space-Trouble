using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla;
using System;

namespace Soomla.Store.SpaceTrouble {

	public class StorePanel : MonoBehaviour {

		public Button endlessEnergy, refillEnergy;

		void OnEnable(){

		}

		public void PurchaseItem(string itemId){
			try{
				Debug.Log("Attempt to purchase");
				StoreInventory.BuyItem(itemId);
			}
			catch(Exception e){
				Debug.LogWarning("SOOMLA/UNITY" + e.Message);
			}
		}
	}

}
