using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float jumpSpeed;
	public GameObject[] shipFragments;
	string currentState;
	Rigidbody2D thisRigidbody;


	void Start () {
		thisRigidbody = GetComponent<Rigidbody2D>();
		currentState = "positioning";
	}

	void Update () {
		switch(currentState){

		case "positioning":
			transform.position = Vector3.Lerp(transform.position, new Vector3(0, -75, 0), 0.2f * Time.deltaTime);
			if(transform.position.y > -76)
				currentState = "idle";
			break;

		case "idle":
			if(LevelController.CheckInput()){
				LevelController.StartSlowMotion();
				Jump();
				currentState = "jumping";
			}
			break;

		case "jumping":

			break;

		}
	}

	void Jump(){
		print ("f");
//		thisRigidbody.AddRelativeForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
		thisRigidbody.velocity = new Vector2(0, jumpSpeed);
	}

	void Destroy(){

	}

	public void DisableAnimator(){

	}

	void OnTriggerStay2D(Collider2D other){

	}

	void OnTriggerExit2D(Collider2D other){

	}
}
