using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : TileObject {

	public string baseName {get; protected set;}
	public Buildable(string _name) : base(TileObjType.Buildable){
		baseName = _name;
	}
	protected Buildable(Buildable b) : base(TileObjType.Buildable){
		this.baseName = b.baseName;
	}
	public static Buildable BuildInstance(Buildable prototype, GameTile tile){
		if (prototype == null || tile == null)
			return null;
		
		Buildable newBuildable = new Buildable(prototype);
		tile.AddBuildable(newBuildable);
		return newBuildable;
	}
	
}
