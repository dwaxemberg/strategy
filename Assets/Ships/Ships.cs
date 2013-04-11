using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***
 * TODO:
 * -> Reformat the list of AddOns with whatever ship addons are actually called
 * -> Update check for getWeapons accordingly.
 ***/


public class Ships : MonoBehaviour {
	
	public const int small = 1;
	public const int medium = 2;
	public const int large = 3;
	
	//global variables
	public int ShipSize;
	public int maxHealth;
	public int currentHealth;
	public int numberOfSlots;
	public int numberOfUsedSlots;
	public int maxSpeed;
	
	public int numberOfThrusters;
	public int numberOfWeapons;
	public int numberOfShields;
	
	GameObject fogbust;
		
	//bool shipIsHit;
	public bool flagShip;
	
	//store what's in which slot
	public AddOns[] shipUpgrades = new AddOns[10];
	public List<AddOns> weapons = new List<AddOns>();
	
	// Use this for initialization
	void Start () {
		//the idea with maxHealth and thrusters is that big ships are slow but durable, and small ships are quick but easy to destroy.
		maxHealth = 200 * ShipSize;
		currentHealth = maxHealth;
		numberOfSlots = 3 * ShipSize;
		numberOfUsedSlots = 0;
		
		//shipUpgrades = new AddOns[ShipSize * 3];
		//give this ship a FogBuster object
		/*fogbust = GameObject.CreatePrimitive (PrimitiveType.Cube);
		fogbust.transform.parent = this.transform;
		fogbust.transform.position = this.transform.position;
		fogbust.AddComponent ("Fogremover");
		fogbust.AddComponent ("SphereCollider");
		fogbust.gameObject.tag = "Fog";*/
		
		/*BoxCollider box = fogbust.GetComponent<BoxCollider> ();
		Destroy (box);
		
		SphereCollider sphere = fogbust.GetComponent<SphereCollider>();
		sphere.radius = 150;
		sphere.isTrigger = true;*/
		
	}
	
	// Update is called once per frame
	void Update () {
		/*foreach (AddOns addon in shipUpgrades) {
			if (addon != null && addon.GetType() == typeof(Upgrade_Speed)) {
				numberOfThrusters++;
			}
			else if (addon != null && addon.GetType() == typeof(Upgrade_Weapon)) {
				numberOfWeapons++;
			}
		}*/
		maxSpeed = (15 * numberOfThrusters) - (ShipSize * 5) + 30;
		//get a key press
		if(Input.GetKeyDown ("1"))
			getUpgrade (0);
		if(Input.GetKeyDown ("2"))
			getUpgrade (1);
		if(Input.GetKeyDown ("3"))
			getUpgrade (2);
		if(Input.GetKeyDown ("4"))
			getUpgrade (3);
		if(Input.GetKeyDown ("5"))
			getUpgrade (4);
		if(Input.GetKeyDown ("6"))
			getUpgrade (5);
		if(Input.GetKeyDown ("7"))
			getUpgrade (6);
		if(Input.GetKeyDown ("8"))
			getUpgrade (7);
		if(Input.GetKeyDown ("9"))
			getUpgrade (8);
	}
	
	public void getUpgrade(int i)
	{
		AddOns addon = new AddOns();
		if(i > 96 && i < 106)
			addon = shipUpgrades[i];
		//if weapon, select
		//if warp drive, warp
	}
	
	//get all the weapons on the ship
    public void getWeapons()
    {
        if (weapons.Count == 0)
        {
            foreach (AddOns addon in shipUpgrades)
            {
                if (addon.GetType() == typeof(Upgrade_Weapon))
                    weapons.Add(addon);
            }
        }
        //once it's gotten all the weapons on a ship, or if it already has them, have them each fire in succession
    }
	
	/*public void setUpgrade(AddOns addon, int i)
	{
		shipUpgrades[i] = addon;
	}*/
	
	public void addThruster() {
		this.numberOfThrusters++;
	}
	
	public void addWeapon() {
		this.numberOfWeapons++;
	}
	
	public int takeDamage (int damage){
		currentHealth -= damage;
		if (currentHealth <= 0)
			DestroyShip();
		return currentHealth;
	}
	
	void warp()
		//move the ship to a random point on the map
	{
		Vector3 newPosition = new Vector3(Random.Range(0, 199), 0, Random.Range(0, 199));
		this.transform.position = newPosition;
	}
	
	private void DestroyShip() {
		//remove the ship from the field in spectacular fashion
		//Instantiate (detonation, transform.position, detonation.transform);
		string destructionName = "";
		int currentSize = (int)ShipSize;
		switch (currentSize) {
		case 0:
			destructionName = "Small_Ship_Detonator";
			break;
		case 1:
			destructionName = "Medium_Ship_Detonator";
			break;
		case 2:
			destructionName = "Large_Ship_Detonator";
			break;
		default:
			destructionName = "Small_Ship_Detonator";
			break;
		}
		if (flagShip)
			destructionName = "Flag_Ship_Detonator";
		GameObject d = (GameObject)Instantiate(Resources.Load(destructionName), this.transform.position, new Quaternion(0,0,0,0));
		AudioSource sound = d.GetComponent<AudioSource>();
		sound.Play();
		this.GetComponent<Main_Controller>().removeTarget();
		Destroy (this.gameObject);
	}
}
