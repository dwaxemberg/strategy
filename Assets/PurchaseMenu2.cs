/*
 * Shelley Murphy
 * 4/4/2013
 * EECS 290 Strategy Game
 * 
 * 
 */


using UnityEngine;
using System.Collections;
/// <summary>
/// Purchase menu2.
/// This class Creates the GUI for buying ships and upgrades for those ships. 
/// </summary>
public class PurchaseMenu2 : MonoBehaviour {
	public int laserCountS;
	public int thrusterCountS;
	public int smallGuns;
	
	public int medGuns;
	public int thrusterCountM;
	public int laserCountM;
	
	public int largeGuns;
	public int thrusterCountL;
	public int laserCountL;
	
	public int smallCount;
	public int mediumCount;
	public int largeCount;
	
	public int smallPrice;
	public int mediumPrice;
	public int largePrice;
	public int money;
	
	
	private int spentMoney;

	//find some way to get the starting amount of money
	/// <summary>
	/// This initializes the values of the price for each weapon on a ship and how many weapons and ships there are (currently, zero)
	/// </summary>
	void Start(){
		
		smallGuns = 0;
		medGuns = 0;
		largeGuns = 0;
		smallPrice = 50;
		mediumPrice = 100;
		largePrice = 150;
		money = 5000;
		spentMoney = 0;
		
		
		smallCount = 0;
		mediumCount = 0;
		largeCount = 0;
		
		
	}
	
	/// <summary>
	/// Create the GUI
	/// </summary>
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Purchase Menu");
		
		
		//The left box is specifically for the small ships
		GUI.Box(new Rect(Screen.width / 3 - 200, Screen.height / 2 - 100, 250, 200), "Small Ships");
		
		if(GUI.Button(new Rect(Screen.width/3 - 190, Screen.height/2 - 70, 200, 20), "Number of Small Ships is " + smallCount)){
			smallCount++;
			if(smallCount == 10){
				smallCount = 0;
			}
		}
		
		///Small, medium, and large ships have different numbers of upgrade slots available. Small only have 3, medium have 6, and large have 9
		
		//add firepower to the ship.
		string stringOfLaserCountS = laserCountS.ToString();
		if(GUI.Button(new Rect(Screen.width/3 - 180, Screen.height / 2 - 30, 150, 20), "Lasers x" + stringOfLaserCountS + " = " + laserCountS * smallPrice)){
			if(smallGuns < 3){
				laserCountS++;
				smallGuns++;
			}
			else if(laserCountS != 0){
				laserCountS = 0;
				smallGuns = 0;
			}
		}
		
		//add thrusters to the ship
		string stringOfthrusterCountS = thrusterCountS.ToString();
		if(GUI.Button(new Rect(Screen.width/3 - 180, Screen.height/2 - 50, 150, 20), "Thrusters x" + stringOfthrusterCountS + " = " + thrusterCountS * smallPrice)){
			if(smallGuns < 3){
				thrusterCountS++;
				smallGuns++;
			}
			else if(thrusterCountS != 0){
				smallGuns = smallGuns - thrusterCountS;
				thrusterCountS = 0;
				
			}
		}
		
		GUI.Box(new Rect(Screen.width / 3 + 50, Screen.height / 2 - 100, 250, 200), "Medium Ships");
		
		//add more medium ships
		if(GUI.Button(new Rect(Screen.width/3 + 60, Screen.height/2 - 70, 200, 20), "Number of Medium Ships is " + mediumCount)){
			mediumCount++; 
			if (mediumCount == 10){
				mediumCount = 0;
			}
		}
		//add firepower
		string stringOfLaserCountM = laserCountM.ToString();
		if(GUI.Button(new Rect(Screen.width/3 + 70, Screen.height / 2 - 30, 150, 20), "Lasers x" + stringOfLaserCountM + " = " + laserCountM * mediumPrice)){
			if(medGuns < 6){
				laserCountM++;
				medGuns++;
			}
			else if(laserCountM != 0){
				medGuns = medGuns - laserCountM;
				laserCountM = 0;
				
			}
		}
		
		//add speed
		string stringOfthrusterCountM = thrusterCountM.ToString();
		if(GUI.Button(new Rect(Screen.width/3 + 70, Screen.height/2 - 50, 150, 20), "Thrusters x" + stringOfthrusterCountM + " =" + thrusterCountM * mediumPrice)){
			if(medGuns < 6){
				thrusterCountM++;
				medGuns++;
			}
			else if(thrusterCountM != 0){
				medGuns = medGuns - thrusterCountM;
				thrusterCountM = 0;
				
			}
		}
		
		
		
		string stringOfLaserCountL = laserCountL.ToString();
		GUI.Box(new Rect(Screen.width / 3 + 300, Screen.height / 2 - 100, 250, 200), "Large Ships");
		
		//increase number of large ships
		if(GUI.Button(new Rect(Screen.width/3 + 310, Screen.height/2 - 70, 200, 20), "Number of Large Ships is " + largeCount)){
			largeCount++;
			if(largeCount == 10){	
				largeCount = 0;
			}
		}
		
		//adding more firepower to the ship
		if(GUI.Button(new Rect(Screen.width/3 + 320, Screen.height / 2 - 30, 150, 20), "Lasers x" + stringOfLaserCountL + " = " + laserCountL * largePrice)){
			if(largeGuns < 9){
				laserCountL++;
				largeGuns++;
			}
			else if(laserCountL != 0){
				largeGuns = largeGuns - laserCountL;
				laserCountL = 0;	
			}
		}
		//adding movement speed to the ship
		string stringOfthrusterCountL = thrusterCountL.ToString();
		if(GUI.Button(new Rect(Screen.width/3 + 320, Screen.height/2 - 50, 150, 20), "Thrusters x" + stringOfthrusterCountL + " = " + thrusterCountL * largePrice)){
			if(largeGuns < 9){
				thrusterCountL++;
				largeGuns++;
			}
			else if(thrusterCountL != 0){
				largeGuns = largeGuns - thrusterCountL;
				thrusterCountL = 0;
				
			}
		}
		
		//How much money have we spent so far?
		spentMoney = smallPrice *smallGuns * smallCount + mediumPrice * medGuns * mediumCount + largePrice * largeGuns * largeCount;
		
		int temp = money - spentMoney;
		
		string stringMoney = temp.ToString();
		//display the remaining money
		GUI.Button(new Rect(Screen.width / 2 - 110, Screen.height / 2, 300, 20), "Money Remaining = " + stringMoney);
		
		
		if(GUI.Button(new Rect(Screen.width / 2 - 110, Screen.height / 2 + 50, 300, 20), "Finish")) {
			//do nothing if we're trying to spend more money than we have
			if(money - spentMoney < 0){
			}
			//otherwise instantiate the ship variables
			else{
				ShipCreator.laserCountS = this.laserCountS;
				ShipCreator.thrusterCountS = this.thrusterCountS;
				ShipCreator.smallGuns = this.smallGuns;
	
				ShipCreator.medGuns = this.medGuns;
				ShipCreator.thrusterCountM = this.thrusterCountM;
				ShipCreator.laserCountM = this.laserCountM;
	
				ShipCreator.largeGuns = this.largeGuns;
				ShipCreator.thrusterCountL = this.thrusterCountL;
				ShipCreator.laserCountL = this.laserCountL;
	
				ShipCreator.smallCount = this.smallCount;
				ShipCreator.mediumCount = this.mediumCount;
				ShipCreator.largeCount = this.largeCount;
					
					
				Application.LoadLevel("Main");
			}
		}
	
	}
}
