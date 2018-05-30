using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//Administra los botones de la escena de Vuforia para que se puedan cambiar de uno a tro fácilmente
//También están las llamadas al inicio de los puzles, cambiando el tiempo para ponerlo en la esquina

public class WindowsManager : MonoBehaviour {

	public static bool penalized = false;

	[SerializeField] private GameObject puzlesButtons;

	[SerializeField] private GameObject vuforiaCanvas;
	[SerializeField] private GameObject questionCanvas;
	[SerializeField] private GameObject inventarioCanvas;
	[SerializeField] private GameObject opcionesCanvas;
	[SerializeField] private GameObject instruccionesCanvas;
	[SerializeField] private GameObject creditosCanvas;
	[SerializeField] private GameObject fondo;
	private GameObject tiempoContador;

	[SerializeField] private Text textTiempoPenalized;
	[SerializeField] private float tiempo = 0.0f;

	private float timePenalized = 10.0f;
	private bool asignado;
	private bool accessOn = false;
	private bool accessOff = true;

	private bool contadorAsignado = false;

	[SerializeField] private Button camaraButton;
	[SerializeField] private Sprite camaraNormal;
	[SerializeField] private Sprite camaraPulsado;

	[SerializeField] private Button progresoButton;
	[SerializeField] private Sprite progresoNormal;
	[SerializeField] private Sprite progresoPulsado;

	[SerializeField] private Button inventarioButton;
	[SerializeField] private Sprite inventarioNormal;
	[SerializeField] private Sprite inventarioPulsado;

	[SerializeField] private Button opcionesButton;
	[SerializeField] private Sprite opcionesNormal;
	[SerializeField] private Sprite opcionesPulsado;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		questionCanvas.SetActive (false);
		vuforiaCanvas.SetActive(false);
		textTiempoPenalized.gameObject.SetActive (false);
		fondo.SetActive (true);
	}

	void Update () {
		if (Timer.tiempoContador != null && !contadorAsignado) {
			tiempoContador = Timer.tiempoContador;
			tiempoContador.SetActive (true);
			contadorAsignado = true;
		}

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
				textTiempoPenalized.text = "Estás penalizado\ndurante " + minutos.ToString () + ":" + segundos.ToString ("D2");
			else
				textTiempoPenalized.text = "Estás penalizado\ndurante " + segundos.ToString ();

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

	//Static para modelados, normales para botones (CanvasPuzles)
	public void OpenPuzles(){
		puzlesButtons.SetActive (!puzlesButtons.activeSelf);
	}
	/*
	public void Llaves(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLlaves");
	}
	*/
	public static void LlavesStatic(){
		Timer.ChangeCanvas (true, "PuzleLlaves", 0);
		SceneManager.LoadScene ("PuzleLlaves");
	}
	/*
	public void Baterias(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleBaterias");
	}
	*/
	public static void BateriasStatic(){
		Timer.ChangeCanvas (true, "PuzleBaterias", 0);
		SceneManager.LoadScene ("PuzleBaterias");
	}
	/*
	public void Laberinto(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLaberinto");
	}
	*/
	public static void LaberintoStatic(){
		Timer.ChangeCanvas (true, "PuzleLaberinto", 0);
		SceneManager.LoadScene ("PuzleLaberinto");
	}
	/*
	public void Cristales(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCristales");
	}
	*/
	public static void CristalesStatic(){
		Timer.ChangeCanvas (true, "PuzleCristales", 0);
		SceneManager.LoadScene ("PuzleCristales");
	}
	/*
	public void Tangram(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleTangram");
	}
	*/
	public static void TangramStatic(){
		Timer.ChangeCanvas (true, "PuzleTangram", 0);
		SceneManager.LoadScene ("PuzleTangram");
	}
	/*
	public void Cerradura(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCerradura");
	}
	*/
	public static void CerraduraStatic(){
		Timer.ChangeCanvas (true, "PuzleCerradura", 0);
		SceneManager.LoadScene ("PuzleCerradura");
	}
	/*
	public void IAPlaca(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleIAPlaca");
	}
	*/
	public static void IAPlacaStatic(){
		Timer.ChangeCanvas (true, "PuzleIAPlaca", 0);
		SceneManager.LoadScene ("PuzleIAPlaca");
	}
	/*
	public void IAGirar(){
		Timer.ChangeCanvas (true, "PuzleIAGirar", 0);
		SceneManager.LoadScene ("PuzleIAGirar");
	}
	*/
	public static void IAGirarStatic(){
		Timer.ChangeCanvas (true, "PuzleIAGirar", 0);
		SceneManager.LoadScene ("PuzleIAGirar");
	}
	/*
	public void IALoops(){
		Timer.ChangeCanvas (true, "PuzleIALoops", 0);
		SceneManager.LoadScene ("PuzleIALoops");
	}
	*/
	public static void IALoopsStatic(){
		Timer.ChangeCanvas (true, "PuzleIALoops", 0);
		SceneManager.LoadScene ("PuzleIALoops");
	}
	/*
	public void IAWords(){
		Timer.ChangeCanvas (true, "PuzleIAWords", 0);
		SceneManager.LoadScene ("PuzleIAWords");
	}
	*/
	public static void IAWordsStatic(){
		Timer.ChangeCanvas (true, "PuzleIAWords", 0);
		SceneManager.LoadScene ("PuzleIAWords");
	}

	void TurnOnVuforia(){
		accessOff = true;
		if (textTiempoPenalized.gameObject.activeSelf) {
			VuforiaBehaviour.Instance.enabled = true;
			textTiempoPenalized.gameObject.SetActive (false);
			fondo.SetActive (false);
			vuforiaCanvas.gameObject.SetActive (true);
		}
		accessOn = false;
	}

	void TurnOffVuforia(){
		accessOn = true;
		vuforiaCanvas.SetActive (false);
		accessOff = false;
	}

	public void OpenQuestions(){
		camaraButton.image.sprite = camaraNormal;
		inventarioButton.image.sprite = inventarioNormal;
		opcionesButton.image.sprite = opcionesNormal;
		inventarioCanvas.SetActive (false);
		opcionesCanvas.SetActive (false);
		CloseItself ();
		fondo.SetActive (true);
		questionCanvas.SetActive (!questionCanvas.activeSelf);

		if (!questionCanvas.activeSelf) {
			tiempoContador.SetActive (true);
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = progresoNormal;
		}
		else {
			tiempoContador.SetActive (false);
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = progresoPulsado;
		}

		textTiempoPenalized.gameObject.SetActive (false);
		vuforiaCanvas.SetActive (false);
		VuforiaBehaviour.Instance.enabled = false;
	}

	public void OpenCamera(){
		progresoButton.image.sprite = progresoNormal;
		inventarioButton.image.sprite = inventarioNormal;
		opcionesButton.image.sprite = opcionesNormal;
		questionCanvas.SetActive (false);
		opcionesCanvas.SetActive (false);
		CloseItself ();
		inventarioCanvas.SetActive (false);

		if (vuforiaCanvas.activeSelf || textTiempoPenalized.gameObject.activeSelf) {
			fondo.SetActive (true);
			VuforiaBehaviour.Instance.enabled = false;
			vuforiaCanvas.SetActive (false);
			textTiempoPenalized.gameObject.SetActive (false);
		}
		else {
			if (!penalized) {
				fondo.SetActive (false);
				VuforiaBehaviour.Instance.enabled = true;
				vuforiaCanvas.SetActive (true);
				textTiempoPenalized.gameObject.SetActive (false);
			} else {
				textTiempoPenalized.gameObject.SetActive (true);
			}
		}

		if (!vuforiaCanvas.activeSelf && !textTiempoPenalized.gameObject.activeSelf) {
			tiempoContador.SetActive (true);
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = camaraNormal;

		}
		else {
			tiempoContador.SetActive (false);
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = camaraPulsado;
		}
	}

	public void OpenInventario(){
		progresoButton.image.sprite = progresoNormal;
		opcionesButton.image.sprite = opcionesNormal;
		questionCanvas.SetActive (false);
		opcionesCanvas.SetActive (false);
		CloseItself ();
		inventarioCanvas.SetActive (!inventarioCanvas.activeSelf);

		if (!inventarioCanvas.activeSelf) {
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = inventarioNormal;
			if(!vuforiaCanvas.activeSelf)
				tiempoContador.SetActive (true);
		}
		else {
			tiempoContador.SetActive (false);
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = inventarioPulsado;
		}
	}

	public void OpenOpciones(){
		camaraButton.image.sprite = camaraNormal;
		inventarioButton.image.sprite = inventarioNormal;
		progresoButton.image.sprite = progresoNormal;

		inventarioCanvas.SetActive (false);
		fondo.SetActive (true);
		questionCanvas.SetActive (false);

		opcionesCanvas.SetActive (!opcionesCanvas.activeSelf);

		if (!opcionesCanvas.activeSelf) {
			tiempoContador.SetActive (true);
			CloseItself ();
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = opcionesNormal;
		}
		else {
			tiempoContador.SetActive (false);
			EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().image.sprite = opcionesPulsado;
		}

		textTiempoPenalized.gameObject.SetActive (false);
		vuforiaCanvas.SetActive (false);
		VuforiaBehaviour.Instance.enabled = false;
	}

	public void OpenInstrucciones(){
		instruccionesCanvas.SetActive (true);
	}

	public void OpenCreditos(){
		creditosCanvas.SetActive (true);
	}

	public void CloseItself(){
		instruccionesCanvas.SetActive (false);
		creditosCanvas.SetActive (false);
	}
}