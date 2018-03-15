﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour {

	public float speed = 0f;

	void OnMouseDown(){

		if(this.gameObject.GetComponent<Renderer>().material.color != Color.red)
			this.gameObject.GetComponent<Renderer>().material.color = Color.red;
		else
			this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		
		if (speed == 0)
			speed = 100f;
		else
			speed = 0f;
	}

	void Update(){
		transform.RotateAround (transform.parent.position, transform.parent.up, Time.deltaTime * speed);
	}
}