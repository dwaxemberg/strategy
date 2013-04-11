using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public float laserWidth1 = 2F;
	public float laserWidth2 = 2F;
	// Use this for initialization
	void Start () {
		LineRenderer laser = gameObject.AddComponent<LineRenderer>();
        laser.material = new Material(Shader.Find("Particles/Additive"));
        laser.SetColors(c1, c2);
        laser.SetWidth(laserWidth1, laserWidth2);
        laser.SetVertexCount(2);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.GetComponent<Main_Controller>().isSelected() && Input.GetMouseButtonDown(0)) {
			Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(clickRay, out hit);
			if (hit.transform.gameObject.tag == "AI") {
				Main_Controller clicker = GetComponent<Main_Controller>();
				clicker.Attack();
				this.transform.LookAt(hit.transform.gameObject.transform.position);
				//create a laser from this object to the target
				LineRenderer laser = GetComponent<LineRenderer>();
				laser.SetPosition(0, this.transform.position);
				laser.SetPosition(1, hit.point + new Vector3(0,10,0));
				laser.renderer.enabled = true;
				//decrease the health of the target
				Ships ship = hit.transform.gameObject.GetComponent<Ships>();
				ship.takeDamage(ship.numberOfWeapons * 10);
				Instantiate(Resources.Load("Laser_Hit"), hit.point + new Vector3(0, 10, 0), new Quaternion(0,0,0,0));
			}
		}
		else {
			LineRenderer laser = GetComponent<LineRenderer>();
			laser.renderer.enabled = false;
			Main_Controller clicker = GetComponent<Main_Controller>();
			clicker.StopAttacking();
		}
	}
				
}