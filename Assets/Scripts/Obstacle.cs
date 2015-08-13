using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float rotationSpeed, movementSpeed;
	public Vector3 movementPoint1, movementPoint2;
	bool isMovingToSecondPoint;

	void Start () {
		isMovingToSecondPoint = true;
	}

	void Update () {
		if(rotationSpeed != 0){
			transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
		}
		if(movementSpeed != 0){
			if(isMovingToSecondPoint){
				transform.position = Vector3.MoveTowards(transform.position, movementPoint2, movementSpeed * Time.deltaTime);
				if(transform.position == movementPoint2){
					isMovingToSecondPoint = false;
				}
			}
			else{
				transform.position = Vector3.MoveTowards(transform.position, movementPoint1, movementSpeed * Time.deltaTime);
				if(transform.position == movementPoint1){
					isMovingToSecondPoint = true;
				}
			}
		}
	}
}
