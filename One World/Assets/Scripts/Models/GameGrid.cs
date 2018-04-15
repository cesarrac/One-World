using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid  {
	public static GameGrid instance {get; protected set;}
	public int Width {get; protected set;}
	public int Height {get; protected set;} 
	public GameTile[,] tiles {get; protected set;}
	public GameGrid(){
		instance = this;
	}

	public static void GenerateGrid(int width, int height){
		if (GameGrid.instance == null)
			return;
		GameGrid.instance.Width = width;
		GameGrid.instance.Height = height;
		GameGrid.instance.SetTiles();
	}
	void SetTiles(){
		tiles = new GameTile[Width, Height];
		for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				tiles[x, y] = new GameTile(x, y);
				GameTile_Manager.instance.NewTile(tiles[x, y]);
			}
		}
		Debug.Log("Tiles Generated!");
	}
	public GameTile GetTileAt(Vector2 pos){
		int x = Mathf.FloorToInt(pos.x);
		int y = Mathf.FloorToInt(pos.y);
		if (IsInGrid(x, y)){
			return tiles[x, y];
		}
		return null;
	}
	bool IsInGrid(int x, int y){
		if (x >= 0 && x < Width && y >= 0 && y < Height){
			return true;
		}
		return false;
	}
}
