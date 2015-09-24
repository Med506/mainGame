using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	public CursorLockMode wantedMode;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Texture2D hitTexture;
	public Vector2 hotSpot = Vector2.zero;
	InteractScript intScript;
//	public bool isSphere;
//	public bool isCube;
//	public int cubeCount = 0;
//	public int sphereCount = 0;
	void SetCursorState() {

		Cursor.lockState = wantedMode;

		Cursor.visible = (CursorLockMode.Locked != wantedMode);
//		isSphere = false;
//		isCube = false;
	}

	void OnMouseEnter() {
	
		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
		if (GameObject.Find("HEAD").GetComponent<InteractScript>().h.transform.name != null) {
			Cursor.SetCursor(hitTexture, hotSpot, cursorMode);
		}

	}

	void OnMouseExit() {
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
	}


	void OnGUI() {

		GUILayout.BeginVertical ();

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.lockState = wantedMode = CursorLockMode.None;
		}

		switch (Cursor.lockState) {
		
		case CursorLockMode.None:
			GUILayout.Label("Cursor is Normal");
			if(GUILayout.Button("Lock Cursor")) {
				wantedMode = CursorLockMode.Locked;
			}

			break;

		case CursorLockMode.Locked:
			GUILayout.Label ("Cursor is Locked Press Escape to Unlock");
			break;
		
		}
//		if (isSphere == true) {
//			sphereCount++;
//		}
//
//		if (isCube == true) {
//			cubeCount++;
//		}
//
//		GUILayout.Label ("Spheres "+ sphereCount);
//		GUILayout.Label ("Cubes " + cubeCount);
		GUILayout.EndVertical ();

		SetCursorState ();

	}




}
