using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {
	
	public float jumpSpeed;
	public GameObject[] shipFragments;
	public GameObject shield;
	string currentState;
	Rigidbody2D thisRigidbody;

	void Start () {
		thisRigidbody = GetComponent<Rigidbody2D>();
		currentState = "positioning";
	}

	void Update () {
		switch(currentState){

		case "positioning":
			transform.position = Vector3.Lerp(transform.position, new Vector3(0, -65f, 0), 2f * Time.deltaTime);
			if(transform.position.y >= -70)
				currentState = "idle";
			if(LevelController.CheckInput()){
				if(EnergyController.currentEnergy > 0 || EnergyController.endlessEnergy){
					EnergyController.RechargeEnergy(-1);
					Jump();
					currentState = "jumping";
				}
			}
			break;

		case "idle":
			if(LevelController.CheckInput()){
				if(EnergyController.currentEnergy > 0 || EnergyController.endlessEnergy){
					EnergyController.RechargeEnergy(-1);
					Jump();
					currentState = "jumping";
				}
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
		if(other.gameObject.tag == "DangerZone"){
			LevelController.StartSlowMotion();
		}
		
		if(other.gameObject.tag == "Obstacle"){
			if(!shield.activeSelf){
				Destroy();
			}
		}
		
		if(other.gameObject.tag == "Finish"){
			LevelController.NextLevel();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "DangerZone"){
			LevelController.StopSlowMotion();
		}
	}
}
