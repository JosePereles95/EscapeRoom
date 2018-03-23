﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Vuforia;

public class PuzleLaberinto : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	[SerializeField] private List<InputField> listLetras;
	private List<int> actualPos;
	private string letras = "DHJLPWX";
	private string solucion = "LXDJ";

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		actualPos = new List<int> ();

		for (int i = 0; i < listLetras.Count; i++) {
			actualPos.Add (-1);
		}
	}

	void Update () {
		
	}

	public void LetrasGoUp(){
		int numLetra = int.Parse (EventSystem.current.currentSelectedGameObject.name [2].ToString ()) - 1;

		ChangePosLetras (numLetra, 0);
	}

	public void LetrasGoDown(){
		int numLetra = int.Parse (EventSystem.current.currentSelectedGameObject.name [2].ToString ()) - 1;;

		ChangePosLetras (numLetra, 1);
	}

	public void CheckAnswer(){
		if (!wrongText.gameObject.activeSelf && !correctText.gameObject.activeSelf) {
			string respuesta = "";
			for (int i = 0; i < listLetras.Count; i++) {
				respuesta += listLetras [i].GetComponentInChildren<Text> ().text;
			}

			if (respuesta == solucion)
				StartCoroutine (ShowCorrectText ());
			else {
				this.GetComponent<RestarVidas> ().Resta ();

				if (this.GetComponent<RestarVidas> ().vidas > 0)
					StartCoroutine (ShowWrongText ());
				else
					StartCoroutine (ShowNoVidasText ());
			}
		}
	}

	void ChangePosLetras(int nLetra, int direction){
		Debug.Log ("Change: " + direction);
		if (direction == 1) {
			actualPos[nLetra] = actualPos[nLetra] + 1;
			Debug.Log ("NewPos - change = 1: " + actualPos[nLetra]);
			if (actualPos[nLetra] > letras.Length - 1)
				actualPos[nLetra] = 0;
		}
		else {
			actualPos[nLetra] = actualPos[nLetra] - 1;
			Debug.Log ("NewPos - change = 0: " + actualPos[nLetra]);
			if (actualPos[nLetra] < 0)
				actualPos[nLetra] = letras.Length - 1;
		}

		listLetras [nLetra].GetComponentInChildren<Text> ().text = letras [actualPos[nLetra]].ToString();
	}

	IEnumerator ShowWrongText(){
		wrongText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		noVidasText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		SceneManager.LoadScene ("Vuforia");
	}
}