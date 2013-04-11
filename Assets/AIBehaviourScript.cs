using UnityEngine;
using System.Collections;

public class AIBehaviourScript : MonoBehaviour {

	
	private GameObject []Ships;
	private GameObject []AI;
	private float vision = 175;
	private float fireRange= 100;
	private int cooldown; // the cooldown is based on the update time because if you have a faster computer that means you are a more hardcore gamer. 
	Vector3 RandomDirection=new Vector3(1,0,1);
	private GameObject Target=null; //Selects 1 ship to attack and doesn't stop untill it is dead
	
	
	// Use this for initialization
	void Start () {
		cooldown = 0;
				
	}
	
	// Update is called once per frame
	void Update () {
		// Checks if the AI ship should be dead. 
		int currentHealth = this.GetComponent<Ships>().currentHealth;
		if(currentHealth <0)
		{
			Destroy(this.gameObject);
				
		}	
		
		AI = GameObject.FindGameObjectsWithTag("AI");
		Ships = GameObject.FindGameObjectsWithTag("Ship");
		foreach(GameObject AIShip in AI){			
			if(cooldown==0)
			{				
				RandomDirection=new Vector3(Random.Range(-1000,1000),0,Random.Range(-1000,1000));
			}
			
			foreach(GameObject playerShip in Ships){					
				// If the target ship has died it selects another ship
				if(Target == null)
				{
					Target=playerShip;
				}
				float distance = Vector3.Distance(AIShip.transform.position,Target.transform.position);
				
				if(distance<fireRange&&cooldown==0)
				{
					this.GetComponent<AIAttack>().Attack(Target);					
					cooldown=30;
					
				}
				if(distance>vision){
					transform.LookAt(Target.transform.position);
					transform.Translate(Vector3.forward * Time.deltaTime * GetComponent<Ships>().maxSpeed);	
				}
				else{
					// If there is no enemy in sight the AI just randomly wanders untill it finds one
					transform.LookAt(RandomDirection);
					transform.Translate(Vector3.forward * Time.deltaTime * GetComponent<Ships>().maxSpeed);	
				}
			}		
		}		
		if(cooldown>0)
		{
			cooldown--;
		}
	
	}
}
