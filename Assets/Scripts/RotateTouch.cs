using UnityEngine;
using System.Collections;

public class RotateTouch : MonoBehaviour 
{
	private float rotSpeed = 100;
	private Quaternion defaultRotation;
	private bool pressed = true;

	void Awake(){
		defaultRotation = this.transform.localRotation;
	}

	void OnMouseDrag(){
			float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
			this.transform.Rotate (Vector3.up, -rotX, Space.Self);
	}

	public void ResetRotation(){
		this.transform.rotation = defaultRotation;
		pressed = true;
	}

	public void Relocate(){
		Debug.Log ("Recolocate: " + pressed);
		this.transform.rotation = defaultRotation;

		if (pressed) {
			this.transform.Rotate (Vector3.right, 90f, Space.Self);
			Debug.Log ("Inside pressed");
		}
		
		pressed = !pressed;
	}
}