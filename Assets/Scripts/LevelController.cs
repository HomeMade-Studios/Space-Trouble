using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	
	void Awake () {
		int levelToLoad = PlayerPrefs.GetInt("levelToLoad", 0);
		Instantiate(Resources.Load("DangerZone" + levelToLoad.ToString()), new Vector3(0,0,0), Quaternion.identity);
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MainMenu");
		}
	}
}
