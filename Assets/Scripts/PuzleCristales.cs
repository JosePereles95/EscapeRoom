using System.Collections;
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

	[SerializeField] private InputField sumaRespuesta;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
	}

	void Update () {
		
	}

	public void CheckAnswer(){
		if (!wrongText.gameObject.activeSelf && !correctText.gameObject.activeSelf) {
			int sumaCorrecta = 0 + 0 * 0 - 0 - 0 * 0 + 0;

			if (sumaRespuesta.GetComponentInChildren<Text> ().text != "") {
				if (int.Parse (sumaRespuesta.GetComponentInChildren<Text> ().text) == sumaCorrecta)
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