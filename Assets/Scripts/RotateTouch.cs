using UnityEngine;
using System.Collections;

public class RotateTouch : MonoBehaviour 
{
	float rotSpeed = 2;
	Quaternion defaultRotation;
	bool pressed = true;

	void Awake(){
		defaultRotation = this.transform.localRotation;
	}

	void OnMouseDrag()
	{
		if (pressed) {
			float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
			transform.RotateAround (Vector3.up, -rotX);
		}
		else {
			float rotZ = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
			transform.RotateAround (Vector3.back, rotZ);
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