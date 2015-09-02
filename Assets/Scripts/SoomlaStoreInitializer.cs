using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Soomla;

namespace Soomla.Store.SpaceTrouble {

	public class SoomlaStoreInitializer : MonoBehaviour {

		VirtualGood fiveShield;

		void Start(){
			StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
			SoomlaStore.Initialize(new SpaceTroubleAssets());
		}

		public void onSoomlaStoreInitialized()
		{
			fiveShield = (VirtualGood) StoreInfo.GetItemByItemId("shield_pack_5");

		}

		public void PurchaseTest(){
			try{
				Debug.Log("Attempt to purchase");
				StoreInventory.BuyItem(fiveShield.ItemId );
			}
			catch(Exception e){
				Debug.Log("SOOMLA/UNITY" + e.Message);
			}
		}
	}
}
