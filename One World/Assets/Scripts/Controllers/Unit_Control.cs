using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Control : MonoBehaviour {

	public Unit thisUnit;	
	SpriteRenderer spriteRenderer;
	public virtual void Initialize(Unit unit, SpriteRenderer sRenderer){
		thisUnit = unit;
		spriteRenderer = sRenderer;
		
		// Set Sprite
		spriteRenderer.sprite = Sprite_Manager.instance.GetUnitSprite(thisUnit.unitName);
	}
	public virtual void Grow(){
		thisUnit.Grow();
	}
}
