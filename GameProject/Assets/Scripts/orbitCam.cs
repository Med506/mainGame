using UnityEngine;
using System.Collections;

public class orbitCam : MonoBehaviour {
	public bool camR;
	public bool ToggleOrbit;
	public Transform target;
	public float distance = 10.0f;
	public bool fpstotps;
	public Camera cam1;
	public Camera cam2;
	
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	
	public float yMinLimit = -10;
	public float yMaxLimit = 80;
	
	private float x = 0.0f;
	private float y = 0.0f;
	
	
	public float smoothTime = 0.3f;
	
	private float xSmooth = 0.0f;
	private float ySmooth = 0.0f; 
	private float xVelocity = 0.0f;
	private float yVelocity = 0.0f;
	
	private Vector3 posSmooth = Vector3.zero;
	private Vector3 posVelocity = Vector3.zero;
	public bool distanceLimit = false;
	
	void Start ()
	{
		fpstotps = true;
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		// Make the rigid body not change rotation
//		if (rigidbody)
//			rigidbody.freezeRotation = true;
	}
	
	void FixedUpdate()
	{
//		if (Input.GetKeyDown(KeyCode.I)) {
//			fpstotps = !fpstotps;
//		}


			//Calculate the vector between the camera and the character
			Vector3 direction = target.position - transform.position;
			//Assigns the vector to the camera
			transform.forward = direction;
			//Calculate the projection vector
			Vector3 vpp = target.position - target.forward * 16;
			//calculate the new direction of the camera
			Vector3 direction2 = vpp - transform.position;
			//Apply the movement
			transform.position += direction2 * 5 * Time.deltaTime;

	}
	
	void LateUpdate ()
	{
		if (fpstotps == false) {
			cam1.enabled = true;
			cam2.enabled = false;
		} else if (fpstotps == true) {
			cam1.enabled = false;
			cam2.enabled = true;

		}

		if (Input.GetMouseButtonDown (2)) {
			camR = !camR;
			fpstotps = !fpstotps;
		} 
		//camR = true;
		//		if (Input.GetMouseButton (1)) {
//			camR = true;		
//		} else {
//			camR = false;
//		}
		if (Input.GetKey (KeyCode.P) && distanceLimit == false) {
			distance += 0.2f; 		
		}
		if (Input.GetKey (KeyCode.O) && distanceLimit == false) {
			distance -= 0.2f; 		
		}
		if (distance <= 3) {
			distanceLimit = true;
			distance =4;
		} 
		else if (distance >= 30) {
			distanceLimit = true;
			distance = 29;
		}
		else {
			distanceLimit = false;
		}
		if (target == true && camR == true)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			
			xSmooth = Mathf.SmoothDamp(xSmooth, (float) x, ref xVelocity, smoothTime);
			ySmooth = Mathf.SmoothDamp(ySmooth, (float) y, ref yVelocity, smoothTime);
			
			ySmooth = ClampAngle(ySmooth, yMinLimit, yMaxLimit);
			
			var rotation = Quaternion.Euler(ySmooth, xSmooth, 0);
			
			 //posSmooth = Vector3.SmoothDamp(posSmooth,target.position,ref posVelocity,smoothTime);
			
			posSmooth = target.position; // no follow smoothing
			
			transform.rotation = rotation;
			transform.position = rotation * new Vector3(0.0f, 0.0f, -distance) + posSmooth;
		}
	}
	
	static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		
		return Mathf.Clamp (angle, min, max);
	}
}