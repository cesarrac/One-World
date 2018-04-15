using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile  {
	public int X {get; protected set;}
	public int Y {get; protected set;}
	public Buildable buildable {get; protected set;}
	public Vector2 worldPos{
		get{
			return new Vector2(X, Y);
		}
	}
	public GameTile(int x, int y){
		X = x;
		Y = y;
	}
	public bool CanBuild(){
		if (buildable != null)
			return false;
		
		return true;
	}
	public void AddBuildable(Buildable newBuild){
		buildable = newBuild;
	}
}
