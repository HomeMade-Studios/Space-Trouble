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
			if(PlayerPrefs.GetInt("endlessEnergy", 0) == 1){
				endlessEnergy.interactable = false;
			}
		}
	}
}
