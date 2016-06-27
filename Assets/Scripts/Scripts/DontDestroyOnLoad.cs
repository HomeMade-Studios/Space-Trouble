using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
	
	void Awake () {

		DontDestroyOnLoad(this);

		if (GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length > 1)
		{
			Destroy(gameObject);
		}
	}
}
