using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {Population, Farms}
public class Unit  {
	public UnitType unitType {get; protected set;}
	public string unitName {get; protected set;}
	public float growthRate{get; protected set;}
	public float curGrowth{get; protected set;}

	public Unit(UnitType _unitType, float growRate, string name = "Default", float startRate = 0){
		unitType = _unitType;
		growthRate = growRate;
		curGrowth = startRate;
		unitName = name == "Default" ? name + "_" + unitType.ToString() : name;
	}
	protected Unit (Unit b){
		unitType = b.unitType;
		growthRate = b.growthRate;
		unitName = b.unitName;
		curGrowth = b.curGrowth;
	}
	public static Unit CreateInstance(Unit prototype){
		if (prototype == null)
			return null;
		return new Unit(prototype);
	}

	public void Grow(){
		curGrowth ++;
	}
}
