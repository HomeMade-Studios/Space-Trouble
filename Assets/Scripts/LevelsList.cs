using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelsList : MonoBehaviour {

	public Slider spaceshipBar;
	public GameObject levelButtonPrefab;
	Button[] levelButtons;
	int completedLevels, maxLevel;

	void Awake () {
		maxLevel = MainMenu.maxLevel;
		completedLevels = PlayerPrefs.GetInt("completedLevels", 0);
		CreateLevelsButtons();
		SetLevelsButtons();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MainMenu");
		}
	}

	void CreateLevelsButtons(){		//CREATE THE LEVELS BUTTONS
		for(int i=0; i < maxLevel; i++){
			int currentButtonLevel = i;
			GameObject spawnedButton;
			spawnedButton = Instantiate(levelButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			spawnedButton.transform.SetParent(this.transform);
			spawnedButton.transform.localScale = new Vector3(1,1,1);
			spawnedButton.GetComponent<Button> ().onClick.AddListener (delegate {SelectLevel (currentButtonLevel);}); //imposta la funzione sull'OnClick del bottone
		}
	}

	void SetLevelsButtons(){	//SET UNLOCKED LEVELS BUTTONS
		levelButtons = GetComponentsInChildren<Button>();
		for(int i = 0; i < levelButtons.Length; i++){
			if(i <= completedLevels){
				levelButtons[i].interactable = true;
				
			}
			else{
				levelButtons[i].interactable = false;
			}
			levelButtons[i].transform.GetComponentInChildren<Text>().text = (i).ToString() + " AU";
		}
		spaceshipBar.maxValue = MainMenu.maxLevel;
		spaceshipBar.value = completedLevels;
	}

	public void SelectLevel(int level){
		PlayerPrefs.SetInt("levelToLoad", level);
		Application.LoadLevel("Level");
	}
}
