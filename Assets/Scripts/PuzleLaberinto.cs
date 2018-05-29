using System.Collections;
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
	[SerializeField] private GameObject panel;

	[SerializeField] private List<InputField> listLetras;
	private List<int> actualPos;
	private string letras = "DHJLPWX";
	private string solucion;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		actualPos = new List<int> ();

		for (int i = 0; i < listLetras.Count; i++) {
			actualPos.Add (-1);
		}
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
		solucion = AleatorioLaberinto.solucion;
		if (!wrongText.gameObject.activeSelf &&
			!correctText.gameObject.activeSelf &&
			!noVidasText.gameObject.activeSelf) {
			string respuesta = "";
			for (int i = 0; i < listLetras.Count; i++) {
				respuesta += listLetras [i].GetComponentInChildren<Text> ().text;
			}
			Debug.Log (solucion);
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
		if (direction == 1) {
			actualPos[nLetra] = actualPos[nLetra] + 1;
			if (actualPos[nLetra] > letras.Length - 1)
				actualPos[nLetra] = 0;
		}
		else {
			actualPos[nLetra] = actualPos[nLetra] - 1;
			if (actualPos[nLetra] < 0)
				actualPos[nLetra] = letras.Length - 1;
		}

		listLetras [nLetra].GetComponentInChildren<Text> ().text = letras [actualPos[nLetra]].ToString();
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
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, 1);
		LevelStructure.completados [10] = true;
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		panel.SetActive (true);
		noVidasText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, -1);
		SceneManager.LoadScene ("Vuforia");
	}
}