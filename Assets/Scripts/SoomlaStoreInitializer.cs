using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Soomla;

namespace Soomla.Store.SpaceTrouble {

	public class SoomlaStoreInitializer : MonoBehaviour {

		void Start(){
			SoomlaStore.Initialize(new SpaceTroubleAssets());
		}

		public void PurchaseTest(){
			try{
				Debug.Log("Attempt to purchase");
				StoreInventory.BuyItem("shield_5");
			}
			catch(Exception e){
				Debug.Log("SOOMLA/UNITY" + e.Message);
			}
		}
	}
}
