using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour {

	private float speed = 50f;
	private float i;

	void Start(){
		
		i = Random.Range (0.0f, 1.0f);

	}

	void Update () {
		if (i <= 0.5f)
			transform.Rotate (new Vector3 (0, Time.deltaTime * speed, 0), Space.World);
		else
			transform.Rotate (new Vector3 (0, -(Time.deltaTime * speed), 0), Space.World);
		
	}
}