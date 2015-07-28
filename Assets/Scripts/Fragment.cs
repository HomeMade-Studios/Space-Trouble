using UnityEngine;
using System.Collections;

public class Fragment : MonoBehaviour {

	public float rotationSpeed;
	public Vector2 movementSpeed;

	void Start () {
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

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
		rigidbody.AddTorque(rotationSpeed, ForceMode2D.Impulse);
		rigidbody.AddForce(movementSpeed, ForceMode2D.Impulse);
	}
}
