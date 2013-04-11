using UnityEngine;
using System.Collections;

public class BoxSelector : MonoBehaviour {
	private bool dragging = false;
	Vector2 startPos;
	Vector2 currentPos;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if (Event.current.type == EventType.mouseDrag) {
			currentPos = Event.current.mousePosition;
			if (!dragging) {
				dragging = true;
				startPos = currentPos;
			}
		}
		if (Event.current.type == EventType.mouseUp) {
			dragging = false;
			SelectShips();
		}
		
		if (dragging) {
			GUI.Box(new Rect(startPos.x, startPos.y, currentPos.x - startPos.x, currentPos.y - startPos.y), "");
		}
	}
	
	// this is a horrible way to do this, but i don't know how to do it better
	void SelectShips() {
		GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
		Ray startRay = Camera.main.ScreenPointToRay(startPos);
		Ray endRay = Camera.main.ScreenPointToRay(currentPos);
		RaycastHit hit1 = new RaycastHit();
		RaycastHit hit2 = new RaycastHit();
		Physics.Raycast(startRay, out hit1);
		Physics.Raycast(endRay, out hit2);
		var pos1 = hit1.point;
		var pos2 = hit2.point;
		for (int i = 0; i < ships.Length; i++) {
			var pos = ships[i].transform.position;
			if (pos.x >= pos1.x && pos.x <= pos2.x && pos.z >= pos1.z && pos.z <= pos2.z) {
				ships[i].GetComponent<Main_Controller>().Select();
			}
		}
	}
}
