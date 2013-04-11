using UnityEngine;
using System.Collections;

/*********
 * 
 * This is what happens: each ship has a child object called FogBuster that should move with it.
 * This FogBuster has a sphere collider with an appropriately large radius.
 * As the ship moves and this sphere collider collides with fog objects, those fog objects have their renderers disabled.
 * Once the ship leaves, the renderers are re-enabled.
 * 
 *********/

public class Fogremover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit[] raycasts = Physics.SphereCastAll(transform.position, 1, new Vector3(0,1,0));
		for (int i = 0; i < raycasts.Length; i++)
			{
				//print(raycasts[i].collider.gameObject.name);
				if (raycasts[i].collider.gameObject.tag == "Fog") {
					//print("fogremover");
					raycasts[i].collider.gameObject.renderer.enabled = false;
				}
			}
	}
}
