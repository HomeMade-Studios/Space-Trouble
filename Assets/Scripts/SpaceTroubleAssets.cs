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
			return new VirtualCurrencyPack[] {ONESHIELD_PACK, FIVESHIELD_PACK, TENSHIELD_PACK, FIFTEENSHIELD_PACK};
		}

		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{};
		}
		
		/** Static Final Members **/

		public const string SHIELD_CURRENCY_ITEM_ID = "shield_currency";

		public const string ONESHIELD_PACK_PRODUCT_ID = "shield_1";

		public const string FIVESHIELD_PACK_PRODUCT_ID = "shield_5";

		public const string TENSHIELD_PACK_PRODUCT_ID = "shield_10";

		public const string FIFTEENSHIELD_PACK_PRODUCT_ID = "shield_15";

		public const string NO_ADS_LIFETIME_PRODUCT_ID = "no_ads";	
		
		/** Virtual Currencies **/

		public static VirtualCurrency SHIELD_CURRENCY = new VirtualCurrency(
			"Shield",										// name
			"Prevent to be destroyed",						// description
			SHIELD_CURRENCY_ITEM_ID							// item id
			);

		/** Virtual Currency Packs **/

		public static VirtualCurrencyPack ONESHIELD_PACK = new VirtualCurrencyPack(
			"1 Shield",										// name
			"Add 1 shield",                       			// description
			"shield_1",										// item id
			1,												// number of currencies in the pack
			SHIELD_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(ONESHIELD_PACK_PRODUCT_ID, 0.50)
			);

		public static VirtualCurrencyPack FIVESHIELD_PACK = new VirtualCurrencyPack(
			"5 Shield",										// name
			"Add 5 shield",                       			// description
			"shield_5",										// item id
			5,												// number of currencies in the pack
			SHIELD_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(FIVESHIELD_PACK_PRODUCT_ID, 2.37)
			);

		public static VirtualCurrencyPack TENSHIELD_PACK = new VirtualCurrencyPack(
			"10 Shield",									// name
			"Add 10 shield",                       			// description
			"shield_10",									// item id
			10,												// number of currencies in the pack
			SHIELD_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(TENSHIELD_PACK_PRODUCT_ID, 4.50)
			);

		public static VirtualCurrencyPack FIFTEENSHIELD_PACK = new VirtualCurrencyPack(
			"15 Shield",									// name
			"Add 15 shield",                       			// description
			"shield_15",									// item id
			15,												// number of currencies in the pack
			SHIELD_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(FIFTEENSHIELD_PACK_PRODUCT_ID, 6.00)
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