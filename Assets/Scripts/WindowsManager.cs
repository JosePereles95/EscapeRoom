using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class WindowsManager : MonoBehaviour {

	public static bool penalized = false;

	[SerializeField] private GameObject vuforiaCanvas;
	[SerializeField] private Text textTiempo;
	[SerializeField] private float tiempo = 0.0f;

	private float timePenalized = 10.0f;
	private bool asignado;
	private bool accessOn = false;
	private bool accessOff = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (penalized) {
			if(accessOff)
				TurnOffVuforia();

			if (!asignado) {
				tiempo = timePenalized;
				asignado = true;
			}

			tiempo -= Time.deltaTime;

			int minutos = ((int)tiempo / 60);
			int segundos = (int)tiempo - (minutos * 60);

			if (minutos > 0)
				textTiempo.text = "Estás penalizado\ndurante " + minutos.ToString () + ":" + segundos.ToString ("D2");
			else
				textTiempo.text = "Estás penalizado\ndurante " + segundos.ToString ();

			if (minutos == 0 && segundos == 0) {
				penalized = false;
				asignado = false;
			}
		}
		else {
			if(accessOn)
				TurnOnVuforia ();
		}
			
	}

	public void Llaves(){
		SceneManager.LoadScene ("PuzleLlaves");
	}

	void TurnOnVuforia(){
		accessOff = true;
		VuforiaBehaviour.Instance.enabled = true;
		textTiempo.gameObject.SetActive(false);
		vuforiaCanvas.gameObject.SetActive (true);
		accessOn = false;
	}

	void TurnOffVuforia(){
		accessOn = true;
		VuforiaBehaviour.Instance.enabled = false;
		textTiempo.gameObject.SetActive (true);
		vuforiaCanvas.SetActive (false);
		accessOff = false;
	}
}
