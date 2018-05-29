using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventarioBehaviour : MonoBehaviour {

	[SerializeField] Canvas UICanvas;
	private RectTransform previousObj;
	private Vector2 preAnchors;
	private Vector2 preSize;
	private int prePosition;
	[SerializeField] private GameObject panelName;
	private List<string> listNames;
	[SerializeField] private List<Button> buttonsInventario;
	[SerializeField] private Sprite cuadradoNormal;
	[SerializeField] private List<Sprite> listObjects;
	private int num = 0;
	private List<bool> sumasUSB;

	[SerializeField] private GameObject panelGet;

	void Start () {
		sumasUSB = new List<bool> ();

		sumasUSB.Add (false);
		sumasUSB.Add (false);
		sumasUSB.Add (false);
		sumasUSB.Add (false);

		listNames = new List<string> ();

		listNames.Add ("Llave 1");
		listNames.Add ("Llave 2");
		listNames.Add ("Baterías");
		listNames.Add ("Destornillador");
		listNames.Add ("Nota");
		listNames.Add ("Clip");
		listNames.Add ("Clave");
		listNames.Add ("Datos");
		listNames.Add ("Tarjeta");
		listNames.Add ("Usuario");
		listNames.Add ("Cortadora");
		listNames.Add ("Cristal 1");
		listNames.Add ("Cristal 2");
		listNames.Add ("Foto");
		listNames.Add ("Comandos");
		listNames.Add ("Actualizaciones");
	}

	void Update () {
		//Puzle 1 - Llave
		if (LevelStructure.completados [1] == true) {
			buttonsInventario [15].image.sprite = listObjects [15];
			StartCoroutine (GetObject (1, "¡Has obtenido una Update!"));
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (SumaUSB (0));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
		}

		//Puzle 3 - Tangram
		if (LevelStructure.completados [3] == true) {
			buttonsInventario [2].image.sprite = listObjects [2];
			StartCoroutine (GetObject (3, "¡Has obtenido las Baterías!"));
		}

		//Puzle 4 - Baterías
		if (LevelStructure.completados [4] == true) {
			buttonsInventario [9].image.sprite = listObjects [9];
			StartCoroutine (GetObject (4, "¡Has obtenido el Usuario!"));
		}

		//Puzle 8 - Cerradura
		if (LevelStructure.completados [8] == true) {
			buttonsInventario [10].image.sprite = listObjects [10];
			StartCoroutine (GetObject (8, "¡Has obtenido la Cortadora!"));
		}

		//Puzle 10 - Laberinto
		if (LevelStructure.completados [10] == true) {
			buttonsInventario [6].image.sprite = listObjects [6];
			buttonsInventario [7].image.sprite = listObjects [7];
			StartCoroutine (GetObject (10, "¡Has obtenido la Clave y los Datos!"));
		}

		//Puzle 13 - Cristales
		if (LevelStructure.completados [13] == true) {
			buttonsInventario [14].image.sprite = listObjects [14];
			StartCoroutine (GetObject (13, "¡Has obtenido los Comandos!"));
		}

		//Question 0 - Pregunta 1
		if (LevelStructure.completados [0] &&
			LevelStructure.openQuestions[0]) {
			buttonsInventario [0].image.sprite = listObjects [0];
			buttonsInventario [1].image.sprite = listObjects [1];
			StartCoroutine (GetObject (0, "¡Has obtenido la Llave 1 y la Llave 2!"));
		}
		else {
			LevelStructure.objMostrado [0] = false;
			buttonsInventario [0].image.sprite = cuadradoNormal;
			buttonsInventario [1].image.sprite = cuadradoNormal;
		}

		//Question 5 - Pregunta 2
		if (LevelStructure.completados [5] &&
			LevelStructure.openQuestions[1]) {
			buttonsInventario [15].image.sprite = listObjects [15];
			StartCoroutine (GetObject (5, "¡Has obtenido una Update!"));
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (SumaUSB (1));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
		}
		else {
			LevelStructure.objMostrado [5] = false;
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (RestaUSB (1));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
			if(num == 0)
				buttonsInventario [15].image.sprite = cuadradoNormal;
		}

		//Question 6 - Pregunta 3
		if (LevelStructure.completados [6] &&
			LevelStructure.openQuestions[2]) {
			buttonsInventario [3].image.sprite = listObjects [3];
			StartCoroutine (GetObject (6, "¡Has obtenido el Destornillador!"));
		}
		else {
			LevelStructure.objMostrado [6] = false;
			buttonsInventario [3].image.sprite = cuadradoNormal;
		}

		//Question 14 - Pregunta 4
		if (LevelStructure.completados [14] &&
			LevelStructure.openQuestions[3]) {
			buttonsInventario [15].image.sprite = listObjects [15];
			StartCoroutine (GetObject (14, "¡Has obtenido una Update!"));
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (SumaUSB (2));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
		}
		else {
			LevelStructure.objMostrado [14] = false;
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (RestaUSB (2));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
			if(num == 0)
				buttonsInventario [15].image.sprite = cuadradoNormal;
		}

		//Question 12 - Pregunta 5
		if (LevelStructure.completados [12] &&
			LevelStructure.openQuestions[4]) {
			buttonsInventario [15].image.sprite = listObjects [15];
			StartCoroutine (GetObject (12, "¡Has obtenido una Update!"));
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (SumaUSB (3));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
		}
		else {
			LevelStructure.objMostrado [12] = false;
			num = int.Parse(buttonsInventario [15].GetComponentInChildren<Text> ().text [0].ToString());
			StartCoroutine (RestaUSB (3));
			string texto = num.ToString () + "/4";
			buttonsInventario [15].GetComponentInChildren<Text> ().text = texto;
			if(num == 0)
				buttonsInventario [15].image.sprite = cuadradoNormal;
		}

		//Cajón 2
		if (LevelStructure.completados [2] == true) {
			buttonsInventario [8].image.sprite = listObjects [8];
			StartCoroutine (GetObject (2, "¡Has obtenido la Tarjeta!"));
		}

		//Cajón 7
		if (LevelStructure.completados [7] == true){
			buttonsInventario [4].image.sprite = listObjects [4];
			buttonsInventario [5].image.sprite = listObjects [5];
			StartCoroutine (GetObject (7, "¡Has obtenido la Nota y el Clip!"));

		}

		//Cajón 9
		if (LevelStructure.completados [9] == true) {
			buttonsInventario [13].image.sprite = listObjects [13];
			StartCoroutine (GetObject (9, "¡Has obtenido la Foto!"));
		}

		//Cajón 11
		if (LevelStructure.completados [11] == true){
			buttonsInventario [11].image.sprite = listObjects [11];
			buttonsInventario [12].image.sprite = listObjects [12];
			StartCoroutine (GetObject (11, "¡Has obtenido el Cristal 1 y el Cristal 2!"));
		}
	}

	public void ButtonPressed(){
		RectTransform actualObject = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform> ();
		actualObject = actualObject.GetComponent (typeof(RectTransform)) as RectTransform;

		if (previousObj != null) {
			previousObj.anchoredPosition = preAnchors;
			previousObj.sizeDelta = preSize;
			previousObj.SetSiblingIndex (prePosition);
			panelName.SetActive (false);
		}

		if (actualObject != previousObj) {
			previousObj = actualObject;
			preAnchors = actualObject.anchoredPosition;
			preSize = actualObject.sizeDelta;

			prePosition = actualObject.GetSiblingIndex ();
			actualObject.SetSiblingIndex (15);
			actualObject.anchoredPosition = new Vector2 (0, 0);
			actualObject.sizeDelta = new Vector2 (1000, 1000);

			panelName.GetComponentInChildren<Text>().text = listNames[int.Parse(actualObject.name.Substring(8,2))];
			panelName.SetActive (true);
		}
		else
			previousObj = null;
	}

	IEnumerator SumaUSB(int i){
		if (!sumasUSB [i]) {
			num++;
			sumasUSB [i] = true;
		}
		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator RestaUSB(int i){
		if (sumasUSB [i]) {
			num--;
			sumasUSB [i] = false;
		}
		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator GetObject(int n, string objeto){
		if (!LevelStructure.objMostrado [n]) {
			LevelStructure.objMostrado [n] = true;
			panelGet.GetComponentInChildren<Text> ().text = objeto;
			panelGet.SetActive (true);
			yield return new WaitForSeconds (6.0f);
			panelGet.SetActive (false);

		}
		yield return new WaitForSeconds (0.1f);
	}
}