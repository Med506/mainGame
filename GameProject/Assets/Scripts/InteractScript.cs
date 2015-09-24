using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {

	public GameObject cam;
	public Ray r;
	public RaycastHit h;
	public GameObject HTarget;
//	public GameObject spherePref;
//	public GameObject cubePref;
	public GameObject SpawnHOLD;
	public bool isHolding;
	// Use this for initialization
	void Start () {
		r = cam.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		h.distance = 1;
		isHolding = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		if (Physics.Raycast (transform.position, forward , out h)) {
			print ("I am looking at " + h.transform.name);

			if(h.collider.tag == "Pickupable") {
				print ("Press F to pickup " + h.transform.name);
				HTarget = h.transform.gameObject;
			}
		} else {
			print("I am looking at Nothing");
		}

		if (Input.GetKey (KeyCode.F) && h.collider.tag == "Pickupable") {
			isHolding = true;


		} else if (Input.GetKey (KeyCode.Z) && isHolding == true) {
			isHolding = false;
			HTarget.GetComponent<Rigidbody>().freezeRotation = false;
		}

		if (isHolding == true) {
			Debug.DrawLine(transform.position, forward*h.distance,Color.blue);
			HTarget.transform.position = new Vector3 (SpawnHOLD.transform.position.x, SpawnHOLD.transform.position.y, SpawnHOLD.transform.position.z);
			HTarget.GetComponent<Rigidbody>().freezeRotation = true;
		}



//		if (Input.GetKey (KeyCode.F) && h.collider.tag == "Pickupable" && h.collider.name == "Sphere") {
//			HTarget.GetComponent<Pickup>().isSpherePickedUp = true;
//		} 
//
//		if (Input.GetKey (KeyCode.F) && h.collider.tag == "Pickupable" && h.collider.name == "Cube") {
//			HTarget.GetComponent<Pickup>().isCubePickedUp = true;
//		}
//
//		if (Input.GetKeyDown (KeyCode.Z) && GameObject.Find ("Player").GetComponent<GUI> ().sphereCount != 0) {
//			Instantiate(spherePref, new Vector3(SpawnHOLD.transform.position.x, SpawnHOLD.transform.position.y,SpawnHOLD.transform.position.z), Quaternion.identity);
//			GameObject.Find("Player").GetComponent<GUI>().sphereCount--;
//		} 
//		if (Input.GetKeyDown (KeyCode.X) && GameObject.Find ("Player").GetComponent<GUI> ().cubeCount != 0) {
//			Instantiate(cubePref, new Vector3(SpawnHOLD.transform.position.x, SpawnHOLD.transform.position.y,SpawnHOLD.transform.position.z), Quaternion.identity);
//			GameObject.Find("Player").GetComponent<GUI>().cubeCount--;
//		} 
	}
}
