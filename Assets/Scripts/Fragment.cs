using UnityEngine;
using System.Collections;

public class Fragment : MonoBehaviour {

	float rebuildSpeed = 50f;
	float rotationSpeed;
	Vector2 movementSpeed;
	bool isRebuilding;
	Rigidbody2D thisRigidbody;

	void Awake () {
		Invoke("Rebuild", 1f);
		isRebuilding = false;
		thisRigidbody = GetComponent<Rigidbody2D>();

		//SET A MOVEMENT SPEED WITH A MAGNITUDE HIGHER THAN 1
		do{
			movementSpeed.x = Random.Range(-20f,20f);
			movementSpeed.y = Random.Range(-20f,20f);
		}while(movementSpeed.magnitude < 5f);

		//SET A ROTATION SPEED WITH A MAGNITUDE HIGHER THAN 0.2
		do{
			rotationSpeed = Random.Range(-5f,5f);
		}while(Mathf.Abs(rotationSpeed) < 1);

		//ADD MOVEMENT AND ROTATION SPEED
		thisRigidbody.AddTorque(rotationSpeed, ForceMode2D.Impulse);
		thisRigidbody.AddForce(movementSpeed, ForceMode2D.Impulse);
	}

	void Update() {
		if(isRebuilding){
			Vector3 vectorToTarget = new Vector3(0, -120, 0) - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
			Quaternion finalRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, 10f * Time.deltaTime);

			thisRigidbody.AddRelativeForce(new Vector2(0, rebuildSpeed), ForceMode2D.Force);
			if(transform.position.y < -105)
				Destroy(this.gameObject);
		}
	}

	public void Rebuild() {
		isRebuilding = true;
	}
}
