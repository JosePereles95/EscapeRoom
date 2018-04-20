using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WindowsManager : MonoBehaviour {

	public static bool penalized = false;

	[SerializeField] private GameObject puzlesButtons;

	[SerializeField] private GameObject vuforiaCanvas;
	[SerializeField] private GameObject questionCanvas;
	[SerializeField] private GameObject fondo;
	private GameObject tiempoContador;

	[SerializeField] private Text textTiempoPenalized;
	[SerializeField] private float tiempo = 0.0f;

	private float timePenalized = 10.0f;
	private bool asignado;
	private bool accessOn = false;
	private bool accessOff = true;

	private bool contadorAsignado = false;

	[SerializeField] private Sprite camaraNormal;
	[SerializeField] private Sprite camaraPulsado;
	[SerializeField] private Sprite progresoNormal;
	[SerializeField] private Sprite progresoPulsado;

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
		/*
		if (!questionCanvas.activeSelf &&
		    !vuforiaCanvas.activeSelf &&
		    !textTiempoPenalized.gameObject.activeSelf) {
			Debug.Log ("Activa Contador");
			tiempoContador.SetActive (true);
		}
		else
			tiempoContador.SetActive (false);
*/
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

	public void OpenPuzles(){
		puzlesButtons.SetActive (!puzlesButtons.activeSelf);
	}
	/*
	public static void Llaves(){
		SceneManager.LoadScene ("PuzleLlaves");
		Timer.ChangeCanvas (true);
	}

	public static void Baterias(){
		SceneManager.LoadScene ("PuzleBaterias");
		Timer.ChangeCanvas (true);
	}

	public static void Laberinto(){
		SceneManager.LoadScene ("PuzleLaberinto");
		Timer.ChangeCanvas (true);
	}

	public static void Cristales(){
		SceneManager.LoadScene ("PuzleCristales");
		Timer.ChangeCanvas (true);
	}

	public static void Tangram(){
		SceneManager.LoadScene ("PuzleTangram");
		Timer.ChangeCanvas (true);
	}

	public static void Cerradura(){
		SceneManager.LoadScene ("PuzleCerradura");
		Timer.ChangeCanvas (true);
	}

	public static void IAGirar(){
		SceneManager.LoadScene ("PuzleIAGirar");
		Timer.ChangeCanvas (true);
	}

	public static void IALoops(){
		SceneManager.LoadScene ("PuzleIALoops");
		Timer.ChangeCanvas (true);
	}*/

	public void Llaves(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLlaves");
	}

	public void Baterias(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleBaterias");
	}

	public void Laberinto(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLaberinto");
	}

	public void Cristales(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCristales");
	}

	public void Tangram(){
		SceneManager.LoadScene ("PuzleTangram");
		Timer.ChangeCanvas (true);
	}

	public void Cerradura(){
		SceneManager.LoadScene ("PuzleCerradura");
		Timer.ChangeCanvas (true);
	}

	public void IAGirar(){
		SceneManager.LoadScene ("PuzleIAGirar");
		Timer.ChangeCanvas (true);
	}

	public void IALoops(){
		SceneManager.LoadScene ("PuzleIALoops");
		Timer.ChangeCanvas (true);
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
		//VuforiaBehaviour.Instance.enabled = false;
		//textTiempo.gameObject.SetActive (true);
		vuforiaCanvas.SetActive (false);
		accessOff = false;
	}

	public void OpenQuestions(){
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
		questionCanvas.SetActive (false);

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
}
