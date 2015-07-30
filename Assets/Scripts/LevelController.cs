using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public static bool playerIsDead;

	void Awake () {
		playerIsDead = false;
		int levelToLoad = PlayerPrefs.GetInt("levelToLoad", 0);
		if(levelToLoad != 0)
			Instantiate(Resources.Load("DangerZone" + levelToLoad.ToString()), new Vector3(0,0,0), Quaternion.identity);
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("LevelSelection");
		}
		if(playerIsDead){
			Invoke("Retry", 25f);
			if(CheckInput()){
				Retry();
			}
		}
	}

	void Retry(){
		Application.LoadLevel(Application.loadedLevel);
	}

	bool CheckInput(){
		if(Input.GetKeyDown(KeyCode.Space)){
			return true;
		}
		if(Input.touchCount > 0){
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				return true;
			}
		}
		return false;
	}
}
