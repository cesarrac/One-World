using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Manager : MonoBehaviour {

	//// 	This will later on read Sprites from Resources folder ////
	public static Sprite_Manager instance {get; protected set;}
	public Sprite[] buildableSprites;
	private void Awake() {
		instance = this;
	}
	public Sprite GetUnitSprite(string buildableName){
		foreach (Sprite sprite in buildableSprites)
		{
			if (sprite.name == buildableName)
				return sprite;
		}
		return null;
	}
}
