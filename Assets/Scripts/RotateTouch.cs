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

	void OnMouseDrag()
	{
		if (pressed) {
			float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
			transform.Rotate (Vector3.up, -rotX, Space.Self);
		}
		else {
			float rotZ = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
			transform.Rotate (Vector3.back, rotZ, Space.Self);
		}
	}

	public void ResetRotation(){
		this.transform.transform.rotation = defaultRotation;
		pressed = true;
	}

	public void Relocate(){
		this.transform.transform.rotation = defaultRotation;

		if (pressed)
			transform.RotateAround (transform.position, transform.right, 90f);
		
		pressed = !pressed;
	}
}