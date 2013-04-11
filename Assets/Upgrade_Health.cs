using UnityEngine;
using System.Collections;

public class Upgrade_Health : AddOns {
	
	public int baseCost = 1000;
	public double costPerLevelMultiplier = 2.5;
	public double healthIncreasePerLevel = 100;
	private int upgradeLevel = 0;
	private double cost;
	
	// Use this for initialization
	void Start () {
		calculateCost();
	}
	
	// Update is called once per frame
	void Update () {
		// increase the health of this ship by a percentage proportional to the upgrade level
		//this.health *= 1 + (upgradeLevel * healthIncreasePerLevel) / 100 
	}
	
	// try to purchase this upgrade
	bool purchase()
	{
		/*if (hasEnoughMoney) {
		 * 	player.money -= cost
		 *  upgradeLevel++;
		 * 	calculateCost();
		 * 	return true;
		 * }
		 * else {
		 * 	return false;
		 * } 						*/
		return true;
	}
	
	double calculateCost()
	{
		return this.cost = baseCost + upgradeLevel * costPerLevelMultiplier;
	}
}
