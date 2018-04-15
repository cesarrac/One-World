using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable_Control : MonoBehaviour {

	public Buildable thisBuildable {get; protected set;}

	public void Initialize(Buildable _buildable){
		thisBuildable = _buildable;
	}
	private void OnDisable() {
		thisBuildable = null;
	}
}
