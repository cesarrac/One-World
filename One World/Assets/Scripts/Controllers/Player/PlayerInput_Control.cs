using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_Control : MonoBehaviour {

	public delegate void OnMouse();
	public event OnMouse onRightClick;
	private void Update() {
		ListenMouse();
	}
	void ListenMouse(){
		if (Input.GetMouseButtonDown(1)){
			if (onRightClick != null){
				onRightClick();
			}
		}
	}
}
