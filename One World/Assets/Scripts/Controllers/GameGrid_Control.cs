using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid_Control : MonoBehaviour {

	private void Start() {
		new GameGrid();
		GenerateGrid(10, 10);
	}
	public void GenerateGrid(int width, int height){
		GameGrid.GenerateGrid(width, height);
	}
}
