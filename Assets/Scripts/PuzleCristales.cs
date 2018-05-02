﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Vuforia;

public class PuzleCristales : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;
	[SerializeField] private GameObject panel;

	[SerializeField] private InputField sumaRespuesta;
	[SerializeField] private List<GameObject> listReferencia;

	private int totalColores = 10;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;

		for (int i = 0; i < totalColores; i++) {
			int j = Random.Range (1, 99);
			listReferencia [i].GetComponentInChildren<Text> ().text = j.ToString();
		}
	}

	void Update () {
		
	}

	public void CheckAnswer(){
		if (!wrongText.gameObject.activeSelf &&
			!correctText.gameObject.activeSelf &&
			!noVidasText.gameObject.activeSelf) {
			if (sumaRespuesta.text != "" && !sumaRespuesta.text.Contains(".")) {
				int sumaCorrecta = int.Parse (listReferencia [AleatorioCristales.listPosColores [0]].GetComponentInChildren<Text> ().text) +
				                   int.Parse (listReferencia [AleatorioCristales.listPosColores [1]].GetComponentInChildren<Text> ().text) *
				                   int.Parse (listReferencia [AleatorioCristales.listPosColores [2]].GetComponentInChildren<Text> ().text) -
				                   int.Parse (listReferencia [AleatorioCristales.listPosColores [3]].GetComponentInChildren<Text> ().text) -
				                   int.Parse (listReferencia [AleatorioCristales.listPosColores [4]].GetComponentInChildren<Text> ().text) *
				                   int.Parse (listReferencia [AleatorioCristales.listPosColores [5]].GetComponentInChildren<Text> ().text) +
				                   int.Parse (listReferencia [AleatorioCristales.listPosColores [6]].GetComponentInChildren<Text> ().text);

				if (int.Parse (sumaRespuesta.text) == sumaCorrecta)
					StartCoroutine (ShowCorrectText ());
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			
			}
		}
	}

	IEnumerator ShowWrongText(){
		panel.SetActive (true);
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		panel.SetActive (false);
		wrongText.gameObject.SetActive (false);
		sumaRespuesta.text = "";
	}

	IEnumerator ShowCorrectText(){
		panel.SetActive (true);
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		Timer.ChangeCanvas (false);
		LevelStructure.completados [13] = true;
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		panel.SetActive (true);
		noVidasText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}
}