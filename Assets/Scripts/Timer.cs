using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using UnityEngine.SceneManagement;

//Maneja todo lo relativo al tiempo, a cambiar la UI del tiempo
//No se destruye entre escenas

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
	private double tiempoFinal = 0.0f;

	public static string sceneName = "";
	public static string estado = "";

	private Firebase.Database.DatabaseReference mDatabaseTiempo;
	private Firebase.Database.DatabaseReference mDatabaseNormal;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private DateTime lastMinimize;
	private double minimizedSeconds;
	private bool llamado = false;

	[SerializeField] private GameObject panelBack;

	private int intento;
	private string fecha;
	private int horas;
	private int minutos;
	private int segundos;
	private int resultado;
	private int numIntentos;

	private string dosPuntos = ":";

	void Start(){
		textTiempo.gameObject.SetActive (false);
		tiempoContador = GameObject.FindGameObjectWithTag ("tiempoContador");
		mDatabaseTiempo = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/TiemposPuzles");
		mDatabaseNormal = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape) && !tiempoContador.activeSelf)
			StartCoroutine (ShowPanelBack ());

		if (canvasActivado && entraCanvas) {
			textTiempo.gameObject.SetActive (true);
			tiempoContador.SetActive (false);
			tiempoInicial = tiempo;
			entraCanvas = false;
		}
		else if(entraCanvas) {
			textTiempo.gameObject.SetActive (false);
			tiempoContador.SetActive (true);
			intento = CheckIntentos ();
			tiempoFinal = Math.Round ((tiempoInicial - tiempo), 2);
			fecha = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year;
			mDatabaseTiempo.Child(fecha).Child(SendData.userID).Child(sceneName).Child("Intento " + intento).Child(estado).SetValueAsync (tiempoFinal);
			entraCanvas = false;
		}

		if (!asignado) {
			tiempo = SendData.minsJuego;
			asignado = true;
		}

		tiempo -= Time.deltaTime;

		horas = ((int) tiempo / 3600);
		minutos = (((int) tiempo - horas * 3600) / 60);
		segundos = (int) tiempo - (horas * 3600 + minutos * 60);

		if (horas > 0)
			textTiempo.text = horas.ToString () + dosPuntos + minutos.ToString ("D2");
		else {
			if(minutos > 0)
				textTiempo.text = minutos.ToString () + dosPuntos + segundos.ToString ("D2");
			else
				textTiempo.text = segundos.ToString ();
		}

		textTiempoMenu.text = horas.ToString () + dosPuntos + minutos.ToString ("D2") + dosPuntos + segundos.ToString ("D2");

		if (horas == 0 && minutos == 0 && segundos == 0) {
			if(!llamado)
				TiempoAgotado ();
		}
	}

	void TiempoAgotado(){
		Debug.Log ("Se acabó el tiempo");
		resultado = 0;

		for (int i = 0; i < LevelStructure.completados.Count; i++)
			if (LevelStructure.completados [i])
				resultado++;
		
		mDatabaseNormal.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Resultado").SetValueAsync (resultado);
		llamado = true;
		SceneManager.LoadScene ("FinalScene");
		Destroy (transform.parent.gameObject);
	}

	int CheckIntentos () {
		numIntentos = 0;

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
		if (isGamePause) {
			lastMinimize = DateTime.Now;
		}
		else {
			minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
			tiempo -= (float) minimizedSeconds;
		}
	}

	IEnumerator ShowPanelBack(){
		panelBack.SetActive (true);
		//Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		panelBack.SetActive (false);
	}
}