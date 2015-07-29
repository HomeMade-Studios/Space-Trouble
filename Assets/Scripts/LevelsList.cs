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

		InvokeRepeating("IncreaseSpaceshipBar", 0.25f, 0.01f);
	}

	public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MainMenu");
		}
	}

	void IncreaseSpaceshipBar() {
		if(spaceshipBar.value < completedLevels){
			spaceshipBar.value += 0.1f;
		}
		else{
			CancelInvoke("IncreaseSpaceshipBar");
		}
	}

	public void selectLevel(int level){
		PlayerPrefs.SetInt("levelToLoad", level);
		Application.LoadLevel("Level");
	}
}
