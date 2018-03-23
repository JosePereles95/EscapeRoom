using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {

	GameObject gObj = null; 
	Vector3 mO;

	Ray GenerateMouseRay()
	{
		Vector3 mousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
		Vector3 mousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
		Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
		Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

		Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
		return mr;

	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray mouseRay = GenerateMouseRay();
			RaycastHit hit;

			if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit) && hit.collider.tag == "plano")
			{
				gObj = hit.transform.gameObject;
				mO = hit.transform.position - hit.point;
			}
		}

		else if(Input.GetMouseButton(0) && gObj)
		{
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gObj.transform.position = new Vector3(newPos.x + mO.x,newPos.y + mO.y,gObj.transform.position.z);
		}

		else if(Input.GetMouseButtonUp(0) && gObj)
		{
			gObj = null;
		}
	}
}