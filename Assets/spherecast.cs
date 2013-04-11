using UnityEngine;
using System.Collections;

public class spherecast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.LookAt(new Vector3(15,10,35));
		Vector3 objectPosition = this.transform.position;
		RaycastHit[] raycasts = Physics.SphereCastAll(this.transform.position, 10, Vector3.forward);
		print (raycasts.Length);
		for (int i = 0; i < raycasts.Length; i++)
			{
				if (raycasts[i].collider.gameObject.tag == "Fog") {
					raycasts[i].collider.gameObject.renderer.enabled = false;
				}
			}
	}
}
