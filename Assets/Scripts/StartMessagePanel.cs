using UnityEngine;
using System.Collections;

public class StartMessagePanel : MonoBehaviour {

	void Update () {
		if(CheckInput()){
			this.gameObject.SetActive(false);
		}
	}

	public void ToPlayStorePage(){

	}

	bool CheckInput(){
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

}
