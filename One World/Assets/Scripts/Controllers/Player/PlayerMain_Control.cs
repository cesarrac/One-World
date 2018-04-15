using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain_Control : MonoBehaviour {

	PlayerInput_Control input_Control;
	Build_Control build_Control;
	Buildable selectedBuild;
	private void Awake() {
		input_Control = GetComponent<PlayerInput_Control>();
		input_Control.onRightClick += TryBuild;
		build_Control = GetComponent<Build_Control>();
	}
	private void Start() {
		// TEST
		SelectBuildable(new Buildable("buildable"));
	}
	public void SelectBuildable(Buildable buildable){
		selectedBuild = buildable;
	}
	void TryBuild(){
		if (selectedBuild == null)
			return;
		if (build_Control.Build(selectedBuild, Camera.main.ScreenToWorldPoint(Input.mousePosition)) == true){
			Debug.Log(selectedBuild.baseName + " has been built.");
		}
	}
}
