using UnityEngine;
using System.Collections;

public class BackgroundRandomizer : MonoBehaviour {

	public bool skyboxMovement;
	public float skyboxMovementSpeed;

	void Awake () {
		this.transform.rotation = Quaternion.Euler (new Vector3 (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f)));
	}

	void Update() {
		if(skyboxMovement){
			this.transform.rotation *= Quaternion.Euler (new Vector3 (-skyboxMovementSpeed, 0, 0) * Time.deltaTime);
		}
	}

}
