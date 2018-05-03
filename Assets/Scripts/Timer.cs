using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{

	[SerializeField] private float tiempo = 0.0f;
	private bool asignado = false;
	[SerializeField] private Text textTiempo;
	[SerializeField] private Text textTiempoMenu;

	public static GameObject tiempoContador;
	public static bool canvasActivado = false;
	public static bool entraCanvas = false;

	void Start(){
		textTiempo.gameObject.SetActive (false);
		tiempoContador = GameObject.FindGameObjectWithTag ("tiempoContador");
	}

	void Update(){

		if (canvasActivado && entraCanvas) {
			textTiempo.gameObject.SetActive (true);
			tiempoContador.SetActive (false);
			entraCanvas = false;
		}
		else if(entraCanvas) {
			textTiempo.gameObject.SetActive (false);
			tiempoContador.SetActive (true);
			entraCanvas = false;
		}

		if (!asignado) {
			tiempo = SendData.minsJuego;
			asignado = true;
		}

		tiempo -= Time.deltaTime;

		int horas = ((int) tiempo / 3600);
		int minutos = (((int) tiempo - horas * 3600) / 60);
		int segundos = (int) tiempo - (horas * 3600 + minutos * 60);

		if (horas > 0)
			textTiempo.text = horas.ToString () + ":" + minutos.ToString ("D2");
		else {
			if(minutos > 0)
				textTiempo.text = minutos.ToString () + ":" + segundos.ToString ("D2");
			else
				textTiempo.text = segundos.ToString ();
		}

		textTiempoMenu.text = horas.ToString () + ":" + minutos.ToString ("D2") + ":" + segundos.ToString ("D2");

		if (horas == 0 && minutos == 0 && segundos == 0)
			TiempoAgotado ();
	}

	void TiempoAgotado(){
		Debug.Log ("Se acabó el tiempo");
	}

	public static void ChangeCanvas(bool enabled){
		canvasActivado = enabled;
		entraCanvas = true;
	}
}