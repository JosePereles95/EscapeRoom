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
	[SerializeField] private GameObject panel;

	[SerializeField] private Text observaText;

	[SerializeField] private List<GameObject> listaBases;
	[SerializeField] private List<GameObject> listaCilindros;
	[SerializeField] private List<GameObject> listaChips;
	[SerializeField] private List<GameObject> listaCPUs;
	[SerializeField] private List<GameObject> listaCubos;
	[SerializeField] private List<GameObject> listaRejillas;
	[SerializeField] private List<GameObject> listaConexiones;
	[SerializeField] private List<GameObject> listaTarjetas;
	[SerializeField] private List<GameObject> listaCajitas;
	[SerializeField] private List<GameObject> listaCuadraditos;

	[SerializeField] private GameObject canvasBotones;
	[SerializeField] private Sprite correctObj;
	[SerializeField] private Sprite wrongObj;

	private bool finalIntro = false;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		StartCoroutine (IntroPuzle ());
	}

	void Update () {
		
	}

	public void ButtonPulsado(){
		if (finalIntro &&
			!wrongText.gameObject.activeSelf &&
			!correctText.gameObject.activeSelf &&
			!noVidasText.gameObject.activeSelf) {
			GameObject buttonObject = EventSystem.current.currentSelectedGameObject;

			int index = ButtonListRenders.listButtonRenders.FindIndex (a => a.gameObject == buttonObject);

			if (index >= 0 && index <= 4) {
				if (index == AleatorioIAPlaca.randomCilindro) {
					listaCilindros [AleatorioIAPlaca.randomCilindro].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 5 && index <= 9) {
				if ((index - 5) == AleatorioIAPlaca.randomChip) {
					listaChips [AleatorioIAPlaca.randomChip].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 10 && index <= 14) {
				if ((index - 10) == AleatorioIAPlaca.randomCPU) {
					listaCPUs [AleatorioIAPlaca.randomCPU].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 15 && index <= 19) {
				if ((index - 15) == AleatorioIAPlaca.randomCubo) {
					listaCubos [AleatorioIAPlaca.randomCubo].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 20 && index <= 24) {
				if ((index - 20) == AleatorioIAPlaca.randomRejilla) {
					listaRejillas [AleatorioIAPlaca.randomRejilla].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 25 && index <= 29) {
				if ((index - 25) == AleatorioIAPlaca.randomConexion) {
					listaConexiones [AleatorioIAPlaca.randomConexion].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 30 && index <= 34) {
				if ((index - 30) == AleatorioIAPlaca.randomTarjeta) {
					listaTarjetas [AleatorioIAPlaca.randomTarjeta].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 35 && index <= 39) {
				if ((index - 35) == AleatorioIAPlaca.randomCajita) {
					listaCajitas [AleatorioIAPlaca.randomCajita].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}
			else if (index >= 40 && index <= 44) {
				if ((index - 40) == AleatorioIAPlaca.randomCuadradito) {
					listaCuadraditos [AleatorioIAPlaca.randomCuadradito].SetActive (true);
					buttonObject.GetComponent<Button> ().image.sprite = correctObj;
				}
				else {
					this.GetComponent<RestarVidas> ().Resta ();

					buttonObject.GetComponent<Button> ().image.sprite = wrongObj;
					buttonObject.GetComponent<Button> ().enabled = false;

					if (this.GetComponent<RestarVidas> ().vidas > 0) {
						StartCoroutine (ShowWrongText ());
					}
					else {
						StartCoroutine (ShowNoVidasText ());
					}
				}
			}

			if (listaCilindros [AleatorioIAPlaca.randomCilindro].activeSelf &&
			    listaChips [AleatorioIAPlaca.randomChip].activeSelf &&
			    listaCPUs [AleatorioIAPlaca.randomCPU].activeSelf &&
			    listaCubos [AleatorioIAPlaca.randomCubo].activeSelf &&
			    listaRejillas [AleatorioIAPlaca.randomRejilla].activeSelf &&
			    listaConexiones [AleatorioIAPlaca.randomConexion].activeSelf &&
			    listaTarjetas [AleatorioIAPlaca.randomTarjeta].activeSelf &&
			    listaCajitas [AleatorioIAPlaca.randomCajita].activeSelf &&
			    listaCuadraditos [AleatorioIAPlaca.randomCuadradito].activeSelf)
				StartCoroutine (ShowCorrectText ());
		}
	}

	IEnumerator ShowWrongText(){
		panel.SetActive (true);
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		panel.SetActive (false);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		panel.SetActive (true);
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, 1);
		LevelStructure.completados [15] = true;
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		panel.SetActive (true);
		noVidasText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, -1);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator IntroPuzle(){
		observaText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.5f);
		observaText.gameObject.SetActive (false);
		yield return new WaitForSeconds (1.0f);

		listaBases [AleatorioIAPlaca.randomBase].SetActive (true);
		listaCilindros [AleatorioIAPlaca.randomCilindro].SetActive (true);
		listaChips [AleatorioIAPlaca.randomChip].SetActive (true);
		listaCPUs [AleatorioIAPlaca.randomCPU].SetActive (true);
		listaCubos [AleatorioIAPlaca.randomCubo].SetActive (true);
		listaRejillas [AleatorioIAPlaca.randomRejilla].SetActive (true);
		listaConexiones [AleatorioIAPlaca.randomConexion].SetActive (true);
		listaTarjetas [AleatorioIAPlaca.randomTarjeta].SetActive (true);
		listaCajitas [AleatorioIAPlaca.randomCajita].SetActive (true);
		listaCuadraditos [AleatorioIAPlaca.randomCuadradito].SetActive (true);

		yield return new WaitForSeconds (10.0f);

		listaBases [AleatorioIAPlaca.randomBase].SetActive (false);
		listaCilindros [AleatorioIAPlaca.randomCilindro].SetActive (false);
		listaChips [AleatorioIAPlaca.randomChip].SetActive (false);
		listaCPUs [AleatorioIAPlaca.randomCPU].SetActive (false);
		listaCubos [AleatorioIAPlaca.randomCubo].SetActive (false);
		listaRejillas [AleatorioIAPlaca.randomRejilla].SetActive (false);
		listaConexiones [AleatorioIAPlaca.randomConexion].SetActive (false);
		listaTarjetas [AleatorioIAPlaca.randomTarjeta].SetActive (false);
		listaCajitas [AleatorioIAPlaca.randomCajita].SetActive (false);
		listaCuadraditos [AleatorioIAPlaca.randomCuadradito].SetActive (false);

		yield return new WaitForSeconds (1.5f);

		listaBases [AleatorioIAPlaca.randomBase].SetActive (true);
		canvasBotones.SetActive (true);
		finalIntro = true;
	}
}