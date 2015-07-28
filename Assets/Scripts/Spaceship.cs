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
			if(CheckJumpInput()){
				Jump ();
			}
		}
	}

	bool CheckJumpInput(){
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
		for(int i = 0; i < 10; i++){
			Instantiate(shipFragments[Random.Range(0,2)], transform.position, Quaternion.identity);
		}
		Time.timeScale = 5f;
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Obstacle")
			Destroy();
		if(other.gameObject.tag == "DangerZone")
			Time.timeScale = 1f;
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "DangerZone")
			Time.timeScale = 5f;
	}
}
