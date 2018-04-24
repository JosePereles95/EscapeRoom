using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TouchVuforia : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(this.name == "Cerradura")
			WindowsManager.CerraduraStatic ();
		if(this.name == "Bateria")
			WindowsManager.BateriasStatic ();
	}
}
