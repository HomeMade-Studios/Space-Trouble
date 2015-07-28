using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Levels : MonoBehaviour {

	public Slider spaceshipSlider;
	Button[] levelButtons;
	int completedLevels;

	void Awake () {
		completedLevels = PlayerPrefs.GetInt("completedLevels", 0);

		//SET UNLOCKED LEVEL
		levelButtons = GetComponentsInChildren<Button>();
		for(int i = 0; i < levelButtons.Length; i++){
			if(i <= completedLevels){
				levelButtons[i].interactable = true;
				levelButtons[i].transform.GetComponentInChildren<Text>().text = (i+1).ToString();
			}
			else{
				levelButtons[i].interactable = false;
				levelButtons[i].transform.GetComponentInChildren<Text>().text = "?";
			}
		}

		//SET SPACESHIP SLIDER LEVEL
		spaceshipSlider.value = completedLevels;
	}

	public void selectLevel(int level){
		PlayerPrefs.SetInt("levelToLoad", level);
		Application.LoadLevel("Level");
	}
}
