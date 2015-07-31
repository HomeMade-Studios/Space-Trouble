using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float jumpSpeed;
	public bool isJumping;
	public GameObject[] shipFragments;

	void Start () {
		isJumping = false;
		Time.timeScale = 5f;
	}

	void Update () {
		if(!isJumping){
			if(CheckInput()){
				if(!GetComponent<Animator>().isActiveAndEnabled)
					Jump ();
			}
		}
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
	
	void Jump(){
		isJumping = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, jumpSpeed);
	}

	void Destroy(){
		Camera.main.GetComponent<AudioSource>().Play();
		for(int i = 0; i < Random.Range(5,16); i++){
			Instantiate(shipFragments[Random.Range(0,2)], transform.position, Quaternion.identity);
		}
		Time.timeScale = 5f;
		Destroy(this.gameObject);
	}

	public void DisableAnimator(){
		GetComponent<Animator>().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Obstacle")
			Destroy();

		if(other.gameObject.tag == "DangerZone")
			Time.timeScale = 1f;

		if(other.gameObject.tag == "Finish"){
			int completedLevels = PlayerPrefs.GetInt("completedLevels", 0);
			int currentLevel = PlayerPrefs.GetInt("levelToLoad", 0);
			if(currentLevel == completedLevels){
				PlayerPrefs.SetInt("completedLevels", completedLevels + 1);
			}
			if(currentLevel < MainMenu.maxLevel - 1){
				PlayerPrefs.SetInt("levelToLoad", currentLevel + 1);
				Application.LoadLevel(Application.loadedLevel);
			}else
				Application.LoadLevel("LevelSelection");
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "DangerZone")
			Time.timeScale = 5f;
	}
}
