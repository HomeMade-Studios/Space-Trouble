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
	}
}
