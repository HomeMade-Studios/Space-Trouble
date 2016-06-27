using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	static EventSystem eventsystem = EventSystem.current;
	static int completedLevels, currentLevel;
	GameObject spaceship;

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
		if(spaceship == null){
			if(GameObject.FindGameObjectsWithTag("Fragment").Length == 0){
				Spawn();
			}
		}
	}

	void InstantiateDangerZone(){
		int levelToLoad = PlayerPrefs.GetInt("levelToLoad", 0);
		if (levelToLoad != 0)
			Instantiate(Resources.Load("DangerZone" + levelToLoad.ToString()), new Vector3(0, 0, 0), Quaternion.identity);
	}

	void Spawn(){
		Instantiate(Resources.Load<GameObject>("spaceship"), new Vector3(0,-110,0), Quaternion.identity);
		spaceship = GameObject.FindGameObjectWithTag("Player");
	}

	void ToLevelSelection() {
		SceneManager.LoadScene("LevelSelection");
	}

	public static void NextLevel(){
		if(currentLevel == completedLevels){
			PlayerPrefs.SetInt("completedLevels", completedLevels + 1);
		}
		if(currentLevel < GameController.maxLevel - 1){
			PlayerPrefs.SetInt("levelToLoad", currentLevel + 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}else
			SceneManager.LoadScene("LevelSelection");

	}

	public static void StartSlowMotion() {
		Time.timeScale = 0.2f;
		Time.fixedDeltaTime = 0.2f * 0.02f;
	}
	
	public static void StopSlowMotion() {
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f;
	}

	public static bool CheckInput() {
		if (GameObject.FindGameObjectsWithTag("Popup").Length == 0) {

			if (Input.GetKeyDown(KeyCode.Space)) {
				return true;
			}
			if (Input.touchCount > 0) {
				if (Input.GetTouch(0).phase == TouchPhase.Began) {
					if (!eventsystem.IsPointerOverGameObject())
						return true;
				}
			}
			
		}
		return false;
	}
}
