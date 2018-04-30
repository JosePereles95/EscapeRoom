using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TouchVuforia : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseDown(){
		if(this.name == "Cerradura")
			WindowsManager.CerraduraStatic ();
		if(this.name == "Bateria")
			WindowsManager.BateriasStatic ();
		if(this.name == "Tangram")
			WindowsManager.TangramStatic ();
	}
}
