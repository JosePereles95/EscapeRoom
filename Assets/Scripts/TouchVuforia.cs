using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class TouchVuforia : MonoBehaviour {

	[SerializeField] private GameObject textFalta;
	[SerializeField] private GameObject textCompleted;
	[SerializeField] private GameObject textPregunta;

	[SerializeField] private GameObject objCajoneraIn;
	private GameObject obj2;
	private GameObject obj8;

	void Start () {
		obj2 = GameObject.FindGameObjectWithTag ("delete");
		obj8 = GameObject.FindGameObjectWithTag ("delete2");
		DisableCompleted ();
	}

	void OnMouseDown(){
		if (this.name == "Llaves") {
			if (LevelStructure.completados [0]) {
				if (LevelStructure.completados [1])
					StartCoroutine (ShowCompletedText ());
				else
					WindowsManager.LlavesStatic ();
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

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

		if (this.name == "IAFinal") {
			if (LevelStructure.completados [1] &&
			    LevelStructure.completados [5] &&
			    LevelStructure.completados [9] &&
			    LevelStructure.completados [12] &&
			    LevelStructure.completados [13] &&
			    LevelStructure.completados [14]) {

				if (LevelStructure.completados [18])
					StartCoroutine (ShowCompletedText ());
				else if (LevelStructure.completados [17])
					WindowsManager.IAWordsStatic ();
				else if (LevelStructure.completados [16])
					WindowsManager.IALoopsStatic ();
				else if (LevelStructure.completados [15])
					WindowsManager.IAGirarStatic ();
				else
					WindowsManager.IAPlacaStatic ();
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Problema0") {
			if (LevelStructure.completados [0]) {
				ActivateProblema (0, this.gameObject, this.objCajoneraIn);
			}
			else {
				StartCoroutine (ShowQuestionText (1));
			}
		}

		if (this.name == "Problema5") {

			if (LevelStructure.completados [2] &&
				LevelStructure.completados [4]) {
				if (LevelStructure.completados [5]) {
					ActivateProblema (1, this.gameObject, this.objCajoneraIn);
					this.GetComponent<MeshCollider> ().enabled = false;
				}
				else {
					StartCoroutine (ShowQuestionText (2));
				}
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}

		}

		if (this.name == "Problema6") {
			if (LevelStructure.completados [6]) {
				ActivateProblema (2, this.gameObject, this.objCajoneraIn);
			}
			else {
				StartCoroutine (ShowQuestionText (3));
			}
		}

		if (this.name == "Problema14") {

			if (LevelStructure.completados [11]) {
				if (LevelStructure.completados [14]) {
					ActivateProblema (3, this.gameObject, this.objCajoneraIn);
				}
				else {
					StartCoroutine (ShowQuestionText (4));
				}
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}

		}

		if (this.name == "Problema12") {

			if (LevelStructure.completados [10]) {
				if (LevelStructure.completados [12]) {
					ActivateProblema (4, this.objCajoneraIn, this.gameObject);
				}
				else {
					StartCoroutine (ShowQuestionText (5));
				}
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}

		}

		if (this.name == "Cajonera2") {
			if (LevelStructure.completados [2])
				StartCoroutine (ShowCompletedText ());
			else if(LevelStructure.completados[0]){
				ActivateCajonera (2, obj2, this.objCajoneraIn);
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
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
			else if(LevelStructure.completados[8]){
				ActivateCajonera (9, this.gameObject, this.objCajoneraIn);
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
		}

		if (this.name == "Cajonera11") {
			if (LevelStructure.completados [11])
				StartCoroutine (ShowCompletedText ());
			else if (LevelStructure.completados [10]) {
				ActivateCajonera (11, this.objCajoneraIn, this.gameObject);
			}
			else {
				StartCoroutine (ShowFaltaText ());
			}
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

	IEnumerator ShowQuestionText(int n) {
		string cadena = "Ve a buscar\nla pregunta "  + n.ToString ();
		textPregunta.GetComponentInChildren<Text> ().text = cadena;
		textPregunta.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		textPregunta.SetActive (false);
	}

	void ActivateCajonera (int n, GameObject objOut, GameObject objIn){
		LevelStructure.completados [n] = true;
		objOut.SetActive (false);
		objIn.SetActive (true);
	}

	void ActivateProblema (int n, GameObject objOut, GameObject objIn){
		LevelStructure.openQuestions [n] = true;
		objOut.SetActive (false);
		objIn.SetActive (true);
	}

	void DisableCompleted (){
		if (this.name == "Cajonera2" &&
			LevelStructure.completados [2]) {
			obj2.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.name == "Cajonera7" &&
			LevelStructure.completados [7]) {
			this.gameObject.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.name == "Cajonera9" &&
			LevelStructure.completados [9]) {
			this.gameObject.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.name == "Cajonera11" &&
			LevelStructure.completados [11]) {
			this.gameObject.SetActive (true);
			this.objCajoneraIn.SetActive (false);
		}

		if (this.name == "Problema0" &&
			LevelStructure.completados [0]) {
			ActivateProblema (0, this.gameObject, this.objCajoneraIn);
		}

		if (this.name == "Problema5" &&
			LevelStructure.completados [5]) {
			ActivateProblema (1, this.objCajoneraIn, this.gameObject);
		}

		if (this.name == "Problema6" &&
			LevelStructure.completados [6]) {
			ActivateProblema (2, this.gameObject, this.objCajoneraIn);
		}

		if (this.name == "Problema14" &&
			LevelStructure.completados [14]) {
			ActivateProblema (3, this.gameObject, this.objCajoneraIn);
		}

		if (this.name == "Problema12" &&
			LevelStructure.completados [12]) {
			ActivateProblema (4, this.objCajoneraIn, this.gameObject);
		}

		if (this.name == "Laberinto" &&
			LevelStructure.completados [10]) {
			this.objCajoneraIn.SetActive (false);
		}

		if (this.name == "Tangram" &&
		    LevelStructure.completados [3]) {
			this.objCajoneraIn.SetActive (false);
		}

		if (this.name == "Cristales" &&
			LevelStructure.completados [13]) {
			this.objCajoneraIn.SetActive (false);
		}

		if (this.name == "Cerradura" &&
			LevelStructure.completados [8]) {
			obj8.SetActive (false);
			this.objCajoneraIn.SetActive (true);
		}

		if (this.name == "Bateria" &&
			LevelStructure.completados [4]) {
			this.objCajoneraIn.SetActive (false);
		}
	}
}