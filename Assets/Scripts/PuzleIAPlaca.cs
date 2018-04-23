using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleIAPlaca : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	[SerializeField] private Text observaText;

	[SerializeField] private List<GameObject> listaPlacas;
	private GameObject modeladoPlaca;

	private bool finalIntro = false;

	void Start () {
		modeladoPlaca = listaPlacas [AleatorioIAPlaca.randomPlaca];
		modeladoPlaca.SetActive (false);

		StartCoroutine (IntroPuzle ());


	}

	void Update () {
		
	}

	public void Tocado(GameObject obj){
		if (finalIntro) {

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
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		noVidasText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator IntroPuzle(){
		yield return new WaitForSeconds (3.0f);
		observaText.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		modeladoPlaca.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		modeladoPlaca.SetActive (false);
		finalIntro = true;
		yield return new WaitForSeconds (1.0f);
		//Mostrar el puzle
	}
}