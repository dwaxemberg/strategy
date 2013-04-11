using UnityEngine;
using System.Collections;

public class FogCreator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject bkgnd = GameObject.Find("Background");
		GameObject fog = (GameObject)Resources.Load("Fog");
		Vector3 fieldSize = bkgnd.transform.lossyScale;
		Vector3 fieldPosition = bkgnd.transform.position;
		
		for (float i = -1000; i < 1000; i += fog.transform.localScale.x / 2) {
			for (float j = -1000; j < 1000; j += fog.transform.localScale.z / 2) {
				Instantiate(fog, new Vector3(i, 30, j), new Quaternion(0,0,0,0));
			}
		}
		/*for (float i = fieldPosition.x - fieldSize.x / 2; i < fieldPosition.x + fieldSize.x / 2; i += fog.transform.localScale.x) {
			for (float j = fieldPosition.y - fieldSize.y / 2; i < fieldPosition.y + fieldSize.y / 2; j += fog.transform.localScale.y) {
				//Object.Instantiate(fog, new Vector3(i, 0, j), new Quaternion(0,0,0,0));
				print ("Creating Fog Object");
			}
		}		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
