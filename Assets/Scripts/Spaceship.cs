using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float jumpSpeed;
	public bool isJumping;
	public GameObject[] shipFragments;

	void Awake () {
		isJumping = false;
		Time.timeScale = 5f;
		Debug.Log ("Spawn" + transform.position);
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
		Time.timeScale = 5f;
		Camera.main.GetComponent<AudioSource>().Play();
		for(int i = 0; i < Random.Range(5,16); i++){
			Instantiate(shipFragments[Random.Range(0,2)], transform.position, Quaternion.identity);
		}
		Destroy(this.gameObject);
	}

	public void DisableAnimator(){
		GetComponent<Animator>().enabled = false;
		transform.position = new Vector3(0,75,0);
	}

	void OnTriggerStay2D(Collider2D other){
		Debug.DrawLine(transform.position, other.transform.position);
		if(other.gameObject.tag == "Obstacle"){
			Debug.Log ("obstacle: " + transform.position);
				Destroy();
		}

		else if(other.gameObject.tag == "DangerZone"){
			Time.timeScale = 1f;
		}

		else if(other.gameObject.tag == "Finish"){
			Debug.Log ("finish: " + transform.position);
			int completedLevels = PlayerPrefs.GetInt("completedLevels", 0);
			int currentLevel = PlayerPrefs.GetInt("levelToLoad", 0);
			if(currentLevel == completedLevels){
				PlayerPrefs.SetInt("completedLevels", completedLevels + 1);
			}
			if(currentLevel < MainMenu.maxLevel - 1){
				PlayerPrefs.SetInt("levelToLoad", currentLevel + 1);
				Application.LoadLevel(Application.loadedLevel);
			}else
				Invoke("NextLevel", 2f);

		}
	}

	void NextLevel(){
		Application.LoadLevel("LevelSelection");
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "DangerZone"){
			Time.timeScale = 5f;
		}
	}
}
