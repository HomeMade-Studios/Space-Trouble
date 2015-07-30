using UnityEngine;
using System.Collections;

public class BackgroundRandomizer : MonoBehaviour {

	void Awake () {
		this.transform.rotation = Quaternion.Euler (new Vector3 (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f)));
	}

}
