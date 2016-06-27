using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup : MonoBehaviour {

	static GameObject noEnergy = Resources.Load("UI/NoEnergyPopup") as GameObject;
	static GameObject store = Resources.Load("UI/StorePopup") as GameObject;
	static GameObject credits = Resources.Load("UI/CreditsPopup") as GameObject;
	static GameObject help = Resources.Load("UI/HelpPopup") as GameObject;

	public static void ShowNoEnergyPopup() {
		ShowPopup(noEnergy);
    }

	public static void ShowStorePopup() {
		ShowPopup(store);
    }

	public static void ShowCreditsPopup() {
		ShowPopup(credits);
    }

	public static void ShowHelpPopup() {
		ShowPopup(help);
    }

	static void ShowPopup(GameObject popup) {

		GameObject openedMessage;
		openedMessage = Instantiate(popup, Vector3.zero, Quaternion.identity) as GameObject;
		openedMessage.transform.SetParent(GameObject.Find("Canvas").transform);
		openedMessage.transform.localScale = new Vector3(1, 1, 1);
		openedMessage.transform.position = new Vector3(0, 0, 0);
	}

	public void ClosePopup() {
		Destroy(this.gameObject);
	}

	public void ToSpaceStation() {
		ClosePopup();
		ShowStorePopup();
	}

	public void OpenPlayStorePage() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.homemadestudios.spacetrouble");
	}

	public void OpenAlexandrZhelanovSoundCloud() {
		Application.OpenURL("https://soundcloud.com/alexandr-zhelanov");
	}
}