using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Translate : MonoBehaviour {

    public string stringName;
    Text toTranslate;
    Lang lang;

	void Start () {
        lang = GameObject.Find("GameController").GetComponent<Lang>();
        toTranslate = gameObject.GetComponent<Text>();
        if (toTranslate != null && lang !=null)
        {
            toTranslate.text=lang.getString(stringName);
        }
	}
}
