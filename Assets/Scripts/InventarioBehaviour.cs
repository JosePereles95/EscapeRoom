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
	[SerializeField] private GameObject panelName;
	private List<string> listNames;

	void Start () {
		listNames = new List<string> ();
		listNames.Add ("Llave 1");
		listNames.Add ("Llave 2");
		listNames.Add ("Baterías");
		listNames.Add ("Destornillador");
		listNames.Add ("Nota");
		listNames.Add ("Clip");
		listNames.Add ("Contraseña");
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
		
	}

	public void ButtonPressed(){
		RectTransform actualObject = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform> ();
		actualObject = actualObject.GetComponent (typeof(RectTransform)) as RectTransform;

		if (previousObj != null) {
			previousObj.anchoredPosition = preAnchors;
			previousObj.sizeDelta = preSize;
			panelName.SetActive (false);
		}

		if (actualObject != previousObj) {
			previousObj = actualObject;
			preAnchors = actualObject.anchoredPosition;
			preSize = actualObject.sizeDelta;

			actualObject.SetSiblingIndex (15);
			actualObject.anchoredPosition = new Vector2 (0, 0);
			actualObject.sizeDelta = new Vector2 (1000, 1000);

			panelName.GetComponentInChildren<Text>().text = listNames[int.Parse(actualObject.name.Substring(8,2))];
			panelName.SetActive (true);
		}
		else
			previousObj = null;
	}
}