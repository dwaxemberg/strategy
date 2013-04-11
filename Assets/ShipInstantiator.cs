/*
*Shelley Murphy
*4/4/2013
*EECS 290 Strategy Game
*
*/
using UnityEngine;
using System;


//This class creates the ships from the GUI
public class ShipInstantiator : MonoBehaviour
{
		
	private int laserCountS;
	private int thrusterCountS;
	private int smallGuns;
	
	private int medGuns;
	private int thrusterCountM;
	private int laserCountM;
	
	private int largeGuns;
	private int thrusterCountL;
	private int laserCountL;
	
	private int smallCount;
	private int mediumCount;
	private int largeCount;
	
	void Start(){
		this.laserCountS= ShipCreator.laserCountS;
		this.thrusterCountS = ShipCreator.thrusterCountS;
		this.smallGuns = ShipCreator.smallGuns;
	
		this.medGuns = ShipCreator.medGuns;
		this.thrusterCountM = ShipCreator.thrusterCountM;
		this.laserCountM= ShipCreator.laserCountM;
	
		this.largeGuns = ShipCreator.largeGuns;
		this.thrusterCountL = ShipCreator.thrusterCountL;
		this.laserCountL = ShipCreator.laserCountL;
	
		this.smallCount = ShipCreator.smallCount;
		this.mediumCount = ShipCreator.mediumCount;
		this.largeCount = ShipCreator.largeCount;
		
		GameObject smallShipLoad = (GameObject) Resources.Load("Prefabs/Small_Ship");
		GameObject mediumShipLoad = (GameObject) Resources.Load("Prefabs/Medium_Ship");
		GameObject largeShipLoad = (GameObject) Resources.Load("Prefabs/Large_Ship");
		
		for (int i = 0; i < smallCount; i++) {
			GameObject small = (GameObject)Instantiate(smallShipLoad, new Vector3(-(smallCount * 30) + i * 60, 0, -600), Quaternion.identity);
			int index = 0;
			for (int j = 0; j < laserCountS; j++) {
				small.GetComponent<Ships>().addWeapon();
				index++;
			}
			for (int j = 0; j < thrusterCountS; j++) {
				small.GetComponent<Ships>().addThruster();
				index++;
			}
		}
		for (int i = 0; i < mediumCount; i++) {
			GameObject medium = (GameObject)Instantiate(mediumShipLoad, new Vector3(-(mediumCount * 30) + i * 60, 0, -700), Quaternion.identity);
			int index = 0;
			for (int j = 0; j < laserCountM; j++) {
				medium.GetComponent<Ships>().addWeapon();
				index++;
			}
			for (int j = 0; j < thrusterCountM; j++) {
				medium.GetComponent<Ships>().addThruster();
				index++;
			}
		}
		for (int i = 0; i < largeCount; i++) {
			GameObject large = (GameObject)Instantiate(largeShipLoad, new Vector3(-(largeCount * 30) + i * 60, 0, -800), Quaternion.identity);
			int index = 0;
			for (int j = 0; j < laserCountL; j++) {
				
				large.GetComponent<Ships>().addWeapon();
				index++;
			}
			for (int j = 0; j < thrusterCountL; j++) {
				large.GetComponent<Ships>().addThruster();
				index++;
			}
		}
			
	}
}


