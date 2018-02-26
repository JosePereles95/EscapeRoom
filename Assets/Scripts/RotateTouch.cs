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
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		transform.RotateAround(Vector3.up, -rotX);

		/*float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;
		transform.RotateAround(Vector3.right, rotY);*/
	}

	public void ResetRotation(){
		this.transform.transform.rotation = defaultRotation;
	}

	public void Relocate(){
		if (pressed)
			transform.RotateAround (transform.position, transform.right, 90f);
		else
			transform.RotateAround (transform.position, transform.right, -90);
		pressed = !pressed;
	}
}