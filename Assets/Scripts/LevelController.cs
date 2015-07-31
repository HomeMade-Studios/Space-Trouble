using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject spaceship, spaceshipPrefab;

	void Awake () {
		InstantiateDangerZone();
	}

	void Start () {
		Spawn();
	}
	
	void Update (){
		if(Input.GetKeyDown(KeyCode.Escape)){
			ToLevelSelection();
		}
		if(spaceship.gameObject == null){
			if(GameObject.FindGameObjectsWithTag("Fragment").Length == 0){
				Spawn();
			}
		}
	}

	void InstantiateDangerZone(){
		int levelToLoad = PlayerPrefs.GetInt("levelToLoad", 0);
		if(levelToLoad != 0)
			Instantiate(Resources.Load("DangerZone" + levelToLoad.ToString()), new Vector3(0,0,0), Quaternion.identity);
	}

	void Spawn(){
		spaceship = Instantiate(spaceshipPrefab, new Vector3(0,-105,0), Quaternion.identity) as GameObject;
	}

	void ToLevelSelection() {
		Application.LoadLevel("LevelSelection");
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
