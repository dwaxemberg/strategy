using UnityEngine;
using System.Collections;

public class AIAttack : MonoBehaviour {
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
	void Update () {
		LineRenderer laser = GetComponent<LineRenderer>();
		laser.renderer.enabled = false;
	}
	
	public void Attack(GameObject target) {
		this.transform.LookAt(target.transform.position);
		//create a laser from this object to the target
		LineRenderer laser = GetComponent<LineRenderer>();
		laser.SetPosition(0, this.transform.position);
		laser.SetPosition(1, target.transform.position);
		laser.renderer.enabled = true;	
		//inflict damage on the target
		Ships ship = target.GetComponent<Ships>();
		ship.takeDamage(ship.numberOfWeapons * 10);
		Instantiate(Resources.Load("Laser_Hit"), target.transform.position + new Vector3(0,10,0), new Quaternion(0,0,0,0));
	}
}
