using UnityEngine;
using System.Collections;

public class Main_Controller : MonoBehaviour {
	private bool selected = false;
	private bool move = false;
	private bool clicked = false;
	public float speed = 2.0F;
	private Vector3 targetPosition;
	GameObject target;
	private bool attacking = false;
	
	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		speed = this.GetComponent<Ships>().maxSpeed;
		if (clicked) {
			selected = true;
			clicked = false;
		}
		else {
			
			if (selected && !attacking && Input.GetMouseButtonDown(0))
			{
				Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(clickRay, out hit)) {
					move = true;
					targetPosition = hit.point;
					targetPosition.y = 0F;
					GameObject.Destroy(target);
					target = UnityEngine.Renderer.Instantiate(Resources.Load("Click Location", typeof(GameObject)), targetPosition, new Quaternion(0,0,0,0)) as GameObject;
				}
				else {
					move = false;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				selected = false;
			}
			if (move) {
				if (Vector3.Distance(transform.position, targetPosition) < 0.1) {
					transform.position = targetPosition;
					GameObject.Destroy(target);
					move = false;
				}
				else {
					transform.LookAt(targetPosition);
					transform.Translate(Vector3.forward * Time.deltaTime * speed);
				}
			}
		}
	}
	
	void OnMouseDown() {
		GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
		for (int i = 0; i < ships.Length; i++) {
			Main_Controller shipController = (Main_Controller)ships[i].GetComponent("Main_Controller");
			shipController.deselect();
		}
		clicked = true;
	}
		
	public void deselect() {
		selected = false;
	}
	
	public bool isSelected() {
		return selected;
	}
	
	public void Select() {
		selected = true;
	}
	
	public void Attack() {
		targetPosition = this.transform.position;
		attacking = true;
	}
	
	public void removeTarget() {
		Destroy(target);
	}
	
	public void StopAttacking() {
		attacking = false;
	}
}
