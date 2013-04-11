using UnityEngine;
using System.Collections;

public class UserCamera : MonoBehaviour {
	public float speed = 5F;
	public float sensitivity = 30F;
	public float xEdge = 400;
	public float yEdge = 680;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var pos = this.transform.position;
		if (Input.mousePosition.x < sensitivity && pos.x > -xEdge) {
			//move camera left
			pos.x -= speed;
		}
		else if (Input.mousePosition.x > Screen.width - sensitivity && pos.x < xEdge) {
			//move camera right
			pos.x += speed;
		}
		if (Input.mousePosition.y < sensitivity && pos.z > -yEdge) {
			// move camera down
			pos.z -= speed;
		}
		else if (Input.mousePosition.y > Screen.height - sensitivity && pos.z < yEdge) {
			// move camera up
			pos.z += speed;
		}
		this.transform.position = pos;
	}
	
	
}
