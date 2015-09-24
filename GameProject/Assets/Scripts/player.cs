using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public int mSpeed = 20;
	public bool hover;
	public bool jump;
	public bool isHover;
	public Vector3 eulerAngleVelocity = new Vector3 (0,100,0);
	public Vector3 eulerAngleMinusVelocity = new Vector3(0,-100,0);
	public float AngularDrag;

	GameObject fpsCam;
	 RaycastHit hit;
	Ray ray;
	
//	private float x = 0.0f;
//	private float y = 0.0f;
//	float distanceToGround = 0.0f;
	
	public float smoothTime = 0.3f;
	
//	private float xSmooth = 0.0f;
//	private float ySmooth = 0.0f; 
//	private float xVelocity = 0.0f;
//	private float yVelocity = 0.0f;


	public float xSpeed = 2.0f;
	public float ySpeed = 1.0f;
	// Use this for initialization
	void Start () {
		isHover = true;

		fpsCam = GameObject.FindGameObjectWithTag ("MAINCAM");

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);


	}
	
	// Update is called once per frame
	void FixedUpdate () {
				Quaternion deltaRotation = Quaternion.Euler (eulerAngleVelocity * Time.deltaTime);
				Quaternion deltaMinusRotation = Quaternion.Euler (eulerAngleMinusVelocity * Time.deltaTime);

		GetComponent<Rigidbody> ().AddRelativeForce (0, -30, 0);

		//float xfps;
		//xfps = fpsCam.transform.rotation.y;

		//transform.Rotate (0, xfps, 0);



		if (Physics.Raycast (transform.position, -Vector3.up, 20f) && isHover == true) {
			hover = true;
		} else {
			hover = false;
		}

			if (Input.GetKey (KeyCode.Q)) {
				GetComponent<Rigidbody>().AddRelativeForce (-mSpeed, 0, 0);
				
			}
			if (Input.GetKey (KeyCode.A)) {
				GetComponent<Rigidbody>().MoveRotation (GetComponent<Rigidbody>().rotation * deltaMinusRotation);
			}
			if (Input.GetKey (KeyCode.D)) {
				GetComponent<Rigidbody>().MoveRotation (GetComponent<Rigidbody>().rotation * deltaRotation);	
			}
			if (Input.GetKey (KeyCode.E)) {
				GetComponent<Rigidbody>().AddRelativeForce (mSpeed, 0, 0);
			}
			if (Input.GetKey (KeyCode.W)) {
				GetComponent<Rigidbody>().AddRelativeForce (0, 0, mSpeed);
			}
			if (Input.GetKey (KeyCode.S)) {
				GetComponent<Rigidbody>().AddRelativeForce (0, 0, -mSpeed);
			}
			if (hover == true) {
				GetComponent<Rigidbody>().AddRelativeForce (0, 60, 0);
			}
			if (Input.GetKeyDown (KeyCode.H)) {
				isHover = !isHover;
			}


		if (Physics.Raycast (transform.position, -Vector3.up, 0.55f) && jump == true) {
			GetComponent<Rigidbody>().AddRelativeForce(0,250,0);
		}

//		if (Physics.Raycast (transform.position, -Vector3.up, 0.275f)) {
//			GetComponent<Rigidbody>().AddRelativeForce(0,20,0);
//		}

		if (Input.GetKey(KeyCode.Space) && isHover == false) {
			jump = true;
		} else {
			jump = false;
		}


		}

//	void OnCollisionEnter(Collision other) {
//		if (other.collider.enabled == true) {
//			jumping = false;
//		}
////		if (other.gameObject.tag == "Terrain") {
////				
////				}
//	}
//	void OnCollisionExit(Collision other) {
//		jumping = true;
//	}

}

