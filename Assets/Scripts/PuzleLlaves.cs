using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleLlaves : MonoBehaviour {

	//[SerializeField] private GameObject vidasScript;
	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	void Start(){
		VuforiaBehaviour.Instance.enabled = false;
	}

	public void Tocado(GameObject obj){
		
		if (!wrongText.gameObject.activeSelf && !correctText.gameObject.activeSelf) {
			if (obj.tag == "correct") {
				StartCoroutine (ShowCorrectText ());
			}
			else if (obj.tag == "wrong") {
				this.GetComponent<RestarVidas> ().Resta ();

				if(this.GetComponent<RestarVidas> ().vidas > 0)
					StartCoroutine (ShowWrongText ());
				else
					StartCoroutine (ShowNoVidasText ());
			}
		}
	}

	void Update(){
			
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