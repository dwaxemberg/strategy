using UnityEngine;
using System.Collections;

public class Fog : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.contacts[0].otherCollider.tag == "Fog") {
			Physics.IgnoreCollision(this.collider, col.contacts[0].otherCollider);
		}
	}
}
