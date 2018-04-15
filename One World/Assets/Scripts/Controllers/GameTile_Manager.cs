using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile_Manager : MonoBehaviour {

	public static GameTile_Manager instance {get; protected set;}

	Dictionary<GameTile, GameObject> gameTileGobjs;
	Dictionary<Buildable, GameObject> buildGObjs;
	ObjectPool pool;
	GameObject tileHolder;
	private void Awake() {
		instance = this;
		buildGObjs = new Dictionary<Buildable, GameObject>();
		gameTileGobjs = new Dictionary<GameTile, GameObject>();
	}
	public void NewTile(GameTile newTile){
		if (pool == null)
			pool = ObjectPool.instance;
		if (tileHolder == null){
			tileHolder = new GameObject();
			tileHolder.name = "TILES";
		}
		
		if (gameTileGobjs.ContainsKey(newTile) == true)
			return;

		GameObject tileGobj = pool.GetObjectForType("Tile", true, newTile.worldPos);
		if (tileGobj == null){
			Debug.LogError("Pool is out of Tile Game Objects!");
			return;
		}
		tileGobj.name = "Tile_" + newTile.X + "_" + newTile.Y;
		tileGobj.transform.SetParent(tileHolder.transform);
		gameTileGobjs.Add(newTile, tileGobj);
	}
	public void NewBuild(Buildable buildablePrototype, GameTile tile){
		if (gameTileGobjs.ContainsKey(tile) == false)
			return;
		Buildable newBuild = Buildable.BuildInstance(buildablePrototype, tile);
		if (newBuild == null)
			return;
		if (buildGObjs.ContainsKey(newBuild) == true)
			return;

		GameObject buildableGobj = ObjectPool.instance.GetObjectForType("Buildable", true, tile.worldPos);
		if (buildableGobj == null){
			Debug.LogError("Pool is out of Buildable Game Objects!");
			return;
		}

		buildableGobj.transform.SetParent(gameTileGobjs[tile].transform);
		buildableGobj.GetComponent<Buildable_Control>().Initialize(newBuild);

		GameObject unitControl = new GameObject();
		unitControl.name = "Unit";
		unitControl.transform.SetParent(buildableGobj.transform);
		Population_Control popController = unitControl.AddComponent<Population_Control>();
		Unit newUnit = Unit.CreateInstance(new Unit(UnitType.Population, 2));
		popController.Initialize(newUnit, buildableGobj.GetComponentInChildren<SpriteRenderer>());

		buildGObjs.Add(newBuild, buildableGobj);

		
	}
}
