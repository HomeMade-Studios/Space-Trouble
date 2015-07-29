using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelsList : MonoBehaviour {

	public Slider spaceshipBar;
	Button[] levelButtons;
	int completedLevels;

	void Awake () {
		completedLevels = PlayerPrefs.GetInt("completedLevels", 0);

		//SET UNLOCKED LEVEL
		levelButtons = GetComponentsInChildren<Button>();
		for(int i = 0; i < levelButtons.Length; i++){
			if(i <= completedLevels){
				levelButtons[i].interactable = true;

			}
			else{
				levelButtons[i].interactable = false;
			}
			levelButtons[i].transform.GetComponentInChildren<Text>().text = (i).ToString() + " km";
		}
		spaceshipBar.maxValue = MainMenu.maxLevel;
		spaceshipBar.value = completedLevels;
	}

	public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MainMenu");
		}
	}

	public void selectLevel(int level){
		PlayerPrefs.SetInt("levelToLoad", level);
		Application.LoadLevel("Level");
	}
}
