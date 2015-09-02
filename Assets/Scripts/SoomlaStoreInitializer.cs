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

		void Update () {
			
		}

		public void PurchaseTest(){
			try{
				Debug.Log("Attempt to purchase");
				StoreInventory.BuyItem("shield_pack_5", "0.70");
			}
			catch(Exception e){
				Debug.Log("SOOMLA/UNITY" + e.Message);
			}
		}
	}
}
