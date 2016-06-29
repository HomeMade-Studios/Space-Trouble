using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class Translate : MonoBehaviour {

    public string stringName;

	void Start () {

		if (stringName != string.Empty) {
			GetComponent<Text>().text = Language.getString(stringName).Replace("\\n", "\n").Replace("	", "");
		}

	}
}
