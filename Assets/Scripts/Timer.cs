using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;

public class Timer : MonoBehaviour{

	[SerializeField] private float tiempo = 0.0f;
	private bool asignado = false;
	[SerializeField] private Text textTiempo;
	[SerializeField] private Text textTiempoMenu;

	public static GameObject tiempoContador;
	public static bool canvasActivado = false;
	public static bool entraCanvas = false;

	private int intentosLlaves = 0;
	private int intentosTangram = 0;
	private int intentosBaterias = 0;
	private int intentosCerradura = 0;
	private int intentosLaberinto = 0;
	private int intentosCristales = 0;

	private int intentosIAPlaca = 0;
	private int intentosIAGirar = 0;
	private int intentosIALoops = 0;
	private int intentosIAWords = 0;

	private float tiempoInicial = 0.0f;
	private float tiempoFinal = 0.0f;

	public static string sceneName = "";
	public static string estado = "";

	private Firebase.Database.DatabaseReference mDatabase;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private DateTime lastMinimize;
	private double minimizedSeconds;

	void Start(){
		textTiempo.gameObject.SetActive (false);
		tiempoContador = GameObject.FindGameObjectWithTag ("tiempoContador");
		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/TiemposPuzles");
	}

	void Update(){

		if (canvasActivado && entraCanvas) {
			textTiempo.gameObject.SetActive (true);
			tiempoContador.SetActive (false);
			tiempoInicial = tiempo;
			entraCanvas = false;
		}
		else if(entraCanvas) {
			textTiempo.gameObject.SetActive (false);
			tiempoContador.SetActive (true);
			int intento = CheckIntentos ();
			tiempoFinal = tiempoInicial - tiempo;
			string fecha = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year;
			mDatabase.Child(fecha).Child(SendData.userID).Child(sceneName).Child("Intento " + intento).Child(estado).SetValueAsync (tiempoFinal);
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

	int CheckIntentos () {
		int numIntentos = 0;

		if (sceneName == "PuzleLlaves") {
			intentosLlaves++;
			numIntentos = intentosLlaves;
		}
		else if (sceneName == "PuzleTangram") {
			intentosTangram++;
			numIntentos = intentosTangram;
		}
		else if (sceneName == "PuzleBaterias") {
			intentosBaterias++;
			numIntentos = intentosBaterias;
		}
		else if (sceneName == "PuzleCerradura") {
			intentosCerradura++;
			numIntentos = intentosCerradura;
		}
		else if (sceneName == "PuzleLaberinto") {
			intentosLaberinto++;
			numIntentos = intentosLaberinto;
		}
		else if (sceneName == "PuzleCristales") {
			intentosCristales++;
			numIntentos = intentosCristales;
		}
		else if (sceneName == "PuzleIAPlaca") {
			intentosIAPlaca++;
			numIntentos = intentosIAPlaca;
		}
		else if (sceneName == "PuzleIAGirar") {
			intentosIAGirar++;
			numIntentos = intentosIAGirar;
		}
		else if (sceneName == "PuzleIALoops") {
			intentosIALoops++;
			numIntentos = intentosIALoops;
		}
		else if (sceneName == "PuzleIAWords") {
			intentosIAWords++;
			numIntentos = intentosIAWords;
		}

		return numIntentos;
	}

	public static void ChangeCanvas(bool enabled, string nameScene, int conseguido){
		canvasActivado = enabled;
		sceneName = nameScene;
		if (conseguido == 1)
			estado = "Correcto";
		else if (conseguido == -1)
			estado = "Incorrecto";
		entraCanvas = true;
	}

	void OnApplicationPause (bool isGamePause)	{
		if (isGamePause)
			GoToMinimize ();
	}

	void OnApplicationFocus (bool isGameFocus)	{
		if (isGameFocus)
			GoToMaximize ();
	}

	public void GoToMinimize ()	{
		lastMinimize = DateTime.Now;
	}

	public void GoToMaximize ()	{
		minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
		tiempo -= (float) minimizedSeconds;
	}
}