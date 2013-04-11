using UnityEngine;
using System.Collections;

public class Upgrade_Speed : AddOns {
	/// <summary>
	/// The base cost.
	/// </summary>
	public int baseCost = 750;
	/// <summary>
	/// The cost per level multiplier.
	/// </summary>
	public double costPerLevelMultiplier = 2.5;
	/// <summary>
	/// The speed increase per level.
	/// </summary>
	public double speedIncreasePerLevel = 1.5;
	/// <summary>
	/// The upgrade level.
	/// </summary>
	private int upgradeLevel = 0;
	/// <summary>
	/// The cost.
	/// </summary>
	private double cost;
	
	// Use this for initialization
	void Start () {
		calculateCost();
	}
	
	// Update is called once per frame
	void Update () {
		// increase the speed of this ship by an amount proportional to the upgrade level
		//this.speed += upgradeLevel * speedIncreasePerLevel;
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
	
	/// <summary>
	/// Calculates the cost.
	/// </summary>
	/// <returns>
	/// The cost.
	/// </returns>
	double calculateCost()
	{
		return this.cost = baseCost + upgradeLevel * costPerLevelMultiplier;
	}
}
