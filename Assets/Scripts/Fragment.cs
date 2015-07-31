using UnityEngine;
using System.Collections;

public class Fragment : MonoBehaviour {

	float rebuildSpeed = 12f;
	float rotationSpeed;
	Vector2 movementSpeed;
	bool isRebuilding;
	Rigidbody2D thisRigidbody;

	void Awake () {
		Invoke("Rebuild", 5f);
		isRebuilding = false;
		thisRigidbody = GetComponent<Rigidbody2D>();

		//SET A MOVEMENT SPEED WITH A MAGNITUDE HIGHER THAN 1
		do{
			movementSpeed.x = Random.Range(-4f,4f);
			movementSpeed.y = Random.Range(-4f,4f);
		}while(movementSpeed.magnitude < 1f);

		//SET A ROTATION SPEED WITH A MAGNITUDE HIGHER THAN 0.2
		do{
			rotationSpeed = Random.Range(-1f,1f);
		}while(Mathf.Abs(rotationSpeed) < 0.2);

		//ADD MOVEMENT AND ROTATION SPEED
		thisRigidbody.AddTorque(rotationSpeed, ForceMode2D.Impulse);
		thisRigidbody.AddForce(movementSpeed, ForceMode2D.Impulse);
	}

	void Update() {
		if(isRebuilding){
			Vector3 vectorToTarget = new Vector3(0, -120, 0) - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
			Quaternion finalRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, Time.deltaTime * 1.5f);

			thisRigidbody.AddRelativeForce(new Vector2(0, rebuildSpeed), ForceMode2D.Force);
			if(transform.position.y < -105)
				Destroy(this.gameObject);
		}
	}

	public void Rebuild() {
		isRebuilding = true;
	}
}
