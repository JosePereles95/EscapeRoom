using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTangram : MonoBehaviour {

	GameObject gObj = null; 
	Vector3 mO;
	private Vector3 defaultPosition;

	Ray GenerateMouseRay(){
		Vector3 mousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
		Vector3 mousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
		Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
		Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

		Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
		return mr;

	}

	void Update()	{
		if(Input.GetMouseButtonDown(0)){
			Ray mouseRay = GenerateMouseRay();
			RaycastHit hit;

			if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit) && hit.collider.tag == "pieza"){
				gObj = hit.transform.gameObject;
				defaultPosition = gObj.transform.position;
				mO = hit.transform.position - hit.point;
			}
		}

		else if(Input.GetMouseButton(0) && gObj){
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gObj.transform.position = new Vector3(newPos.x + mO.x,newPos.y + mO.y,gObj.transform.position.z);
		}

		else if(Input.GetMouseButtonUp(0) && gObj){
			PuzleTangram.CheckBounds (gObj, gObj.transform.position, defaultPosition);
			gObj = null;
		}
	}
}