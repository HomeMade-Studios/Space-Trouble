using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject spaceship, spaceshipPrefab;
	static int completedLevels, currentLevel;
	public Text text1;

	void Awake () {
		InstantiateDangerZone();
		spaceship = null;
		completedLevels = PlayerPrefs.GetInt("completedLevels", 0);
		currentLevel = PlayerPrefs.GetInt("levelToLoad", 0);
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Escape)){
			ToLevelSelection();
		}
		if(spaceship.gameObject == null){
			text1.text = "b";
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
		spaceship = Instantiate(spaceshipPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
	}

	void ToLevelSelection() {
		Application.LoadLevel("LevelSelection");
	}

	public static void NextLevel(){
		if(currentLevel < MainMenu.maxLevel - 1){
			PlayerPrefs.SetInt("levelToLoad", currentLevel + 1);
			Application.LoadLevel(Application.loadedLevel);
		}else
			Application.LoadLevel("LevelSelection");
		if(currentLevel == completedLevels){
			PlayerPrefs.SetInt("completedLevels", completedLevels + 1);
		}
	}

	public static void StartSlowMotion() {
		Time.timeScale = 0.2f;
		Time.fixedDeltaTime = 0.2f * 0.02f;
	}
	
	public static void StopSlowMotion() {
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f;
	}

	public static bool CheckInput(){
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
