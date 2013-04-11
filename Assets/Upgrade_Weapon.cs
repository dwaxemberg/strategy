using UnityEngine;
using System.Collections;

public class Upgrade_Weapon : AddOns {
	
	public int baseCost = 500;
	public double costPerLevelMultiplier = 2.5;
	public double damageIncreasePerLevel = 1.5;
	private int upgradeLevel = 0;
	private double cost;
	
	// Use this for initialization
	void Start () {
		calculateCost();
	}
	
	// Update is called once per frame
	void Update () {
		// increase the damage of this ship by an amount proportional to the upgrade level
		//this.damage += upgradeLevel * damageIncreasePerLevel;
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
	
	// calculate the cost of this upgrade
	double calculateCost()
	{
		return this.cost = baseCost + upgradeLevel * costPerLevelMultiplier;
	}
}
