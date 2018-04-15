using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileObjType {Obstacle, Buildable}
public class TileObject  {

	public GameTile baseTile {get; protected set;}
	public TileObjType tileObjType{get; protected set;}
	public TileObject(TileObjType objType){
		tileObjType = objType;
	}
	
}
