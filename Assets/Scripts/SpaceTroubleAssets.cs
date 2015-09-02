using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store.SpaceTrouble {

	/// This class defines our game's economy, which includes virtual goods, virtual currencies
	/// and currency packs, virtual categories
	public class SpaceTroubleAssets : IStoreAssets{

		public int GetVersion() {
			return 0;
		}

		public VirtualCurrency[] GetCurrencies() {
			return new VirtualCurrency[]{SHIELD_CURRENCY};
		}

		public VirtualGood[] GetGoods() {
			return new VirtualGood[] {NO_ADS_LTVG};
		}

		public VirtualCurrencyPack[] GetCurrencyPacks() {
			return new VirtualCurrencyPack[] {FIVESHIELD_PACK};
		}

		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{};
		}
		
		/** Static Final Members **/

		public const string SHIELD_CURRENCY_ITEM_ID = "shield";

		public const string FIVESHIELD_PACK_PRODUCT_ID = "android.test.purchased";
		
		public const string NO_ADS_LIFETIME_PRODUCT_ID = "no_ads";	
		
		/** Virtual Currencies **/

		public static VirtualCurrency SHIELD_CURRENCY = new VirtualCurrency(
			"Shield",										// name
			"Prevent to be destroyed",						// description
			SHIELD_CURRENCY_ITEM_ID							// item id
			);

		/** Virtual Currency Packs **/
		
		public static VirtualCurrencyPack FIVESHIELD_PACK = new VirtualCurrencyPack(
			"5 Shield",										// name
			"Add 5 shield",                       			// description
			"shield_pack_5",								// item id
			5,												// number of currencies in the pack
			SHIELD_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(FIVESHIELD_PACK_PRODUCT_ID, 0.99)
			);
		
		/** Virtual Goods **/
		
		/** Virtual Categories **/

		/** LifeTimeVGs **/
		// Note: create non-consumable items using LifeTimeVG with PuchaseType of PurchaseWithMarket
		public static VirtualGood NO_ADS_LTVG = new LifetimeVG(
			"No Ads", 														// name
			"No More Ads!",				 									// description
			"no_ads",														// item id
			new PurchaseWithMarket(NO_ADS_LIFETIME_PRODUCT_ID, 4.99));	// the way this virtual good is purchased
	}
	
}