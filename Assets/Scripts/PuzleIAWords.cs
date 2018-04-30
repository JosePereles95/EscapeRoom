﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleIAWords : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;
	[SerializeField] private GameObject panel;

	[SerializeField] private GameObject nota;

	[SerializeField] private InputField word1;
	[SerializeField] private InputField word2;
	[SerializeField] private InputField word3;

	[SerializeField] private Text texto1;
	[SerializeField] private Text texto2;
	[SerializeField] private Text texto3;

	[SerializeField] private Text num1;
	[SerializeField] private Text num2;
	[SerializeField] private Text num3;

	[SerializeField] private Sprite notaNormal;
	[SerializeField] private Sprite notaPulsado;

	private List<string> soluciones;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		nota.SetActive (false);
		soluciones = new List<string> ();
	}

	void Update () {
		if (AleatorioIAWords.ready) {
			texto1.text = AleatorioIAWords.listWords [0];
			texto2.text = AleatorioIAWords.listWords [1];
			texto3.text = AleatorioIAWords.listWords [2];

			num1.text = "+ " + AleatorioIAWords.listNums [0];
			num2.text = "- " + AleatorioIAWords.listNums [1];
			num3.text = "+ " + AleatorioIAWords.listNums [2];

			AleatorioIAWords.ready = false;
		}

		string text1 = word1.text;
		if (text1 != word1.text.ToUpper ())
			word1.text = word1.text.ToUpper ();
		string text2 = word2.text;
		if (text2 != word2.text.ToUpper ())
			word2.text = word2.text.ToUpper ();
		string text3 = word3.text;
		if (text3 != word3.text.ToUpper ())
			word3.text = word3.text.ToUpper ();
	}

	public void OpenHelp(){
		nota.SetActive (!nota.activeSelf);

		if(!nota.activeSelf)
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = notaNormal;
		else
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = notaPulsado;
	}

	public void CheckWords(){
		Cifrado ();
	}

	private void Cifrado(){
		if (!wrongText.gameObject.activeSelf &&
		    !correctText.gameObject.activeSelf &&
		    !noVidasText.gameObject.activeSelf &&
			word1.text != "" &&
			word2.text != "" &&
			word3.text != "") {
			for (int i = 0; i < AleatorioIAWords.listWords.Count; i++) {
				string solucion = "";
				int j = 0;
				foreach (char x in AleatorioIAWords.listWords[i]) {
					if (i % 2 == 0) {
						int position = AleatorioIAWords.listPositions [i] [j] + AleatorioIAWords.listNums [i];
						if (position > 27)
							position -= 27;
						solucion += AleatorioIAWords.letras [position];
					}
					else {
						int position = AleatorioIAWords.listPositions [i] [j] - AleatorioIAWords.listNums [i];
						if (position < 0)
							position += 27;
						solucion += AleatorioIAWords.letras [position];
					}
					j++;
				}
				Debug.Log (solucion);
				soluciones.Add (solucion);
			}

			//Check if correct
			if (word1.text == soluciones [0] &&
			   word2.text == soluciones [1] &&
			   word3.text == soluciones [2]) {
				StartCoroutine (ShowCorrectText ());
			}
			else {
				word1.text = "";
				word2.text = "";
				word3.text = "";

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

	IEnumerator ShowWrongText(){
		panel.SetActive (true);
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		panel.SetActive (false);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		panel.SetActive (true);
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		Timer.ChangeCanvas (false);
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