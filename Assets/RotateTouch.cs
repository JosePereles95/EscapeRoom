using UnityEngine;
using System.Collections;

public class RotateTouch : MonoBehaviour 
{
	float rotSpeed = 2;

	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		transform.RotateAround(Vector3.up, -rotX);

		/*float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;
		transform.RotateAround(Vector3.right, rotY);*/
	}
}