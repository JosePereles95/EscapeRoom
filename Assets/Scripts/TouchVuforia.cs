using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TouchVuforia : MonoBehaviour {

	[SerializeField] private GameObject textFalta;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseDown(){
		if (this.name == "Cerradura" &&
		   LevelStructure.completados [6] &&
		   LevelStructure.completados [7])
			WindowsManager.CerraduraStatic ();
		else {
			StartCoroutine (ShowFaltaText ());
		}
		if(this.name == "Bateria" &&
		LevelStructure.completados[3])
			WindowsManager.BateriasStatic ();
		else {
			StartCoroutine (ShowFaltaText ());
		}
		if(this.name == "Tangram")
			WindowsManager.TangramStatic ();
		else {
			StartCoroutine (ShowFaltaText ());
		}
	}

	IEnumerator ShowFaltaText(){
		textFalta.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		textFalta.SetActive (false);
	}
}