﻿using System.Collections;
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

	private bool finalIntro = false;

	void Start () {
		StartCoroutine (IntroPuzle ());
	}

	void Update () {
		
	}

	public void ButtonPulsado(){
		if (finalIntro &&
			!wrongText.gameObject.activeSelf &&
			!correctText.gameObject.activeSelf &&
			!noVidasText.gameObject.activeSelf) {
			GameObject buttonCommand = EventSystem.current.currentSelectedGameObject;

			int index = ButtonListRenders.listButtonRenders.FindIndex (a => a.gameObject == buttonCommand);

			if (index >= 0 && index <= 4) {
				if (index == AleatorioIAPlaca.randomCilindro)
					listaCilindros [AleatorioIAPlaca.randomCilindro].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 5 && index <= 9) {
				if ((index - 5) == AleatorioIAPlaca.randomChip)
					listaChips [AleatorioIAPlaca.randomChip].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 10 && index <= 14) {
				if ((index - 10) == AleatorioIAPlaca.randomCPU)
					listaCPUs [AleatorioIAPlaca.randomCPU].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 15 && index <= 19) {
				if ((index - 15) == AleatorioIAPlaca.randomCubo)
					listaCubos [AleatorioIAPlaca.randomCubo].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 20 && index <= 24) {
				if ((index - 20) == AleatorioIAPlaca.randomRejilla)
					listaRejillas [AleatorioIAPlaca.randomRejilla].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 25 && index <= 29) {
				if ((index - 25) == AleatorioIAPlaca.randomConexion)
					listaConexiones [AleatorioIAPlaca.randomConexion].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 30 && index <= 34) {
				if ((index - 30) == AleatorioIAPlaca.randomTarjeta)
					listaTarjetas [AleatorioIAPlaca.randomTarjeta].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 35 && index <= 39) {
				if ((index - 35) == AleatorioIAPlaca.randomCajita)
					listaCajitas [AleatorioIAPlaca.randomCajita].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
			}
			else if (index >= 40 && index <= 44) {
				if ((index - 40) == AleatorioIAPlaca.randomCuadradito)
					listaCuadraditos [AleatorioIAPlaca.randomCuadradito].SetActive (true);
				else
					StartCoroutine (ShowWrongText ());
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
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
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
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false);
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

		yield return new WaitForSeconds (5.0f);

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