using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Control : MonoBehaviour {

	public bool Build(Buildable buildable, Vector2 pos){
		GameTile baseTile = GameGrid.instance.GetTileAt(pos);
		if (baseTile == null)
			return false;
		if (baseTile.CanBuild() == false)
			return false;

		// Build
		GameTile_Manager.instance.NewBuild(buildable, baseTile);
		return true;
	}
}
