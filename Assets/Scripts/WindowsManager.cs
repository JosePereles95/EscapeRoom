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
	[SerializeField] private GameObject inventarioCanvas;
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

	public void OpenPuzles(){
		puzlesButtons.SetActive (!puzlesButtons.activeSelf);
	}

	public void Llaves(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLlaves");
	}

	//
	public static void LlavesStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLlaves");
	}
	//

	public void Baterias(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleBaterias");
	}

	//
	public static void BateriasStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleBaterias");
	}
	//

	public void Laberinto(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLaberinto");
	}

	//
	public static void LaberintoStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleLaberinto");
	}
	//

	public void Cristales(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCristales");
	}

	//
	public static void CristalesStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCristales");
	}
	//

	public void Tangram(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleTangram");
	}

	//
	public static void TangramStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleTangram");
	}
	//

	public void Cerradura(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCerradura");
	}

	//
	public static void CerraduraStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleCerradura");
	}
	//

	public void IAGirar(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleIAGirar");
	}

	public void IALoops(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleIALoops");
	}

	public void IAPlaca(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleIAPlaca");
	}

	//
	public static void IAPlacaStatic(){
		Timer.ChangeCanvas (true);
		SceneManager.LoadScene ("PuzleIAPlaca");
	}
	//

	public void IAWords(){
		Timer.ChangeCanvas (true);
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
		//VuforiaBehaviour.Instance.enabled = false;
		//textTiempo.gameObject.SetActive (true);
		vuforiaCanvas.SetActive (false);
		accessOff = false;
	}

	public void OpenQuestions(){
		camaraButton.image.sprite = camaraNormal;
		inventarioButton.image.sprite = inventarioNormal;
		inventarioCanvas.SetActive (false);
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
		questionCanvas.SetActive (false);
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
		//camaraButton.image.sprite = camaraNormal;
		//fondo.SetActive (true);
		questionCanvas.SetActive (false);
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

		//textTiempoPenalized.gameObject.SetActive (false);
		//vuforiaCanvas.SetActive (false);
		//VuforiaBehaviour.Instance.enabled = false;
	}
}
