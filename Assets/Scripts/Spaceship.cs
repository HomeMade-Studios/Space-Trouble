using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float jumpSpeed;
	public GameObject[] shipFragments;
	string currentState;
	Rigidbody2D thisRigidbody;
	bool justSpawned;

	void Awake() {
		justSpawned = true;
	}

	void Start () {
		thisRigidbody = GetComponent<Rigidbody2D>();
		currentState = "positioning";
	}

	void Update () {
		switch(currentState){

		case "positioning":
			if(justSpawned)
				transform.position = new Vector3(0, -150, 0);
			justSpawned = false;
			transform.position = Vector3.Lerp(transform.position, new Vector3(0, -70f, 0), 1.5f * Time.deltaTime);
			if(transform.position.y >= -75)
				currentState = "idle";
			break;

		case "idle":
			if(LevelController.CheckInput()){
				Jump();
				currentState = "jumping";
			}
			break;

		case "jumping":

			break;

		}
	}

	void Jump(){
		thisRigidbody.AddRelativeForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
		thisRigidbody.velocity = new Vector2(0, jumpSpeed);
	}

	void Destroy(){
		LevelController.StopSlowMotion();
		Camera.main.GetComponent<AudioSource>().Play();
		for(int i = 0; i < Random.Range(5,16); i++){
			Instantiate(shipFragments[Random.Range(0,2)], transform.position, Quaternion.identity);
		}
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(currentState == "jumping"){
			if(other.gameObject.tag == "DangerZone"){
				LevelController.StartSlowMotion();
			}

			if(other.gameObject.tag == "Obstacle"){
				Destroy();
			}

			if(other.gameObject.tag == "Finish"){
				LevelController.NextLevel();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "DangerZone"){
			LevelController.StopSlowMotion();
		}
	}
}
