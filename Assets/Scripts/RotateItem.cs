using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour {

	public float speed = 0.05f;
	float i;
	// Update is called once per frame
	void Start(){
		
		i = Random.Range (0.0f, 1.0f);
		//print (i);

	}
	void Update () {
		if(i <= 0.5f)
			transform.Rotate(new Vector3(0,Time.deltaTime*speed,0));
		else
			transform.Rotate(new Vector3(0,-(Time.deltaTime*speed),0));
		
	}
		
}
