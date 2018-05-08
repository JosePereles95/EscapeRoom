using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TouchVuforia : MonoBehaviour {

	[SerializeField] private GameObject textFalta;
	[SerializeField] private GameObject textCompleted;

	[SerializeField] private GameObject objCajoneraIn;

	//private bool checking = false;

	void Start () {
		DisableCompleted ();
	}

	void Update () {
		
	}

	void OnMouseDown(){
		if (this.name == "Cerradura") {
			if (LevelStructure.completados [6] &&
				LevelStructure.completados [7]) {
				if (LevelStructure.completados [8])
					StartCoroutine (ShowCompletedText ());
				else
					WindowsManager.CerraduraStatic ();
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Bateria") {
			if (LevelStructure.completados [3]) {
				if (LevelStructure.completados [4])
					StartCoroutine (ShowCompletedText ());
				else
					WindowsManager.BateriasStatic ();
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Tangram") {
			if (LevelStructure.completados [3])
				StartCoroutine (ShowCompletedText ());
			else
				WindowsManager.TangramStatic ();
		}

		if (this.name == "Laberinto") {
			if (LevelStructure.completados [10])
				StartCoroutine (ShowCompletedText ());
			else
				WindowsManager.LaberintoStatic ();
		}

		if (this.name == "Cristales") {
			if (LevelStructure.completados [11]) {
				if (LevelStructure.completados [13])
					StartCoroutine (ShowCompletedText ());
				else
					WindowsManager.CristalesStatic ();
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Problema0") {
			if (LevelStructure.completados [0]) {
				ActivateProblema (this.gameObject, this.objCajoneraIn);
			}
		}

		if (this.name == "Problema2") {

			if (LevelStructure.completados [2] &&
				LevelStructure.completados [4]) {
				if (LevelStructure.completados [5]) {
					ActivateProblema (this.gameObject, this.objCajoneraIn);
				}
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Problema6") {
			if (LevelStructure.completados [6]) {
				ActivateProblema (this.gameObject, this.objCajoneraIn);
			}
		}

		if (this.name == "Problema12") {

			if (LevelStructure.completados [10]) {
				if (LevelStructure.completados [12]) {
					ActivateProblema (this.objCajoneraIn, this.gameObject);
				}
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Cajonera2") {
			if (LevelStructure.completados [2])
				StartCoroutine (ShowCompletedText ());
			else
				ActivateCajonera (2, this.gameObject, this.objCajoneraIn);
		}

		if (this.name == "Cajonera7") {
			if (LevelStructure.completados [7])
				StartCoroutine (ShowCompletedText ());
			else
				ActivateCajonera (7, this.gameObject, this.objCajoneraIn);
		}

		if (this.name == "Cajonera9") {
			if (LevelStructure.completados [9])
				StartCoroutine (ShowCompletedText ());
			else
				ActivateCajonera (9, this.gameObject, this.objCajoneraIn);
		}

		if (this.name == "Cajonera11") {
			if (LevelStructure.completados [11])
				StartCoroutine (ShowCompletedText ());
			else
				ActivateCajonera (11, this.gameObject, this.objCajoneraIn);
		}
	}

	IEnumerator ShowFaltaText() {
		textFalta.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		textFalta.SetActive (false);
	}

	IEnumerator ShowCompletedText() {
		textCompleted.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		textCompleted.SetActive (false);
	}

	void ActivateCajonera (int n, GameObject objOut, GameObject objIn){
		LevelStructure.completados [n] = true;
		objOut.SetActive (false);
		objIn.SetActive (true);
	}

	void ActivateProblema (GameObject objOut, GameObject objIn){
		objOut.SetActive (false);
		objIn.SetActive (true);
	}

	void DisableCompleted (){
		if (this.tag == "Cajonera" &&
			LevelStructure.completados [2]) {
			this.gameObject.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.tag == "Cajonera" &&
			LevelStructure.completados [7]) {
			this.gameObject.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.tag == "Cajonera" &&
			LevelStructure.completados [9]) {
			this.gameObject.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.tag == "Cajonera" &&
			LevelStructure.completados [11]) {
			this.gameObject.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.tag == "ObjCosas" &&
			LevelStructure.completados [6]) {
			ActivateProblema (this.gameObject, this.objCajoneraIn);
		}

		if (this.tag == "ObjCosas" &&
			LevelStructure.completados [12]) {
			ActivateProblema (this.objCajoneraIn, this.gameObject);
		}

		if (this.tag == "ObjCosas" &&
			LevelStructure.completados [10]) {
			this.objCajoneraIn.SetActive (false);
		}

		if (this.tag == "ObjCosas" &&
			LevelStructure.completados [5]) {
			ActivateProblema (this.gameObject, this.objCajoneraIn);
		}

		if (this.tag == "ObjCosas" &&
			LevelStructure.completados [0]) {
			ActivateProblema (this.gameObject, this.objCajoneraIn);
		}
	}
}