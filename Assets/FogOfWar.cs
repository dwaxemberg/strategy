using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void removeFog(){
		renderer.enabled = false;
	}
}