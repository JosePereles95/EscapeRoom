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

	void Start () {
		
	}

	void Update () {
		
	}

	public void ButtonPressed(){
		RectTransform actualObject = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform> ();
		actualObject = actualObject.GetComponent (typeof(RectTransform)) as RectTransform;

		if (previousObj != null) {
			previousObj.anchoredPosition = preAnchors;
			previousObj.sizeDelta = preSize;
		}

		if (actualObject != previousObj) {
			previousObj = actualObject;
			preAnchors = actualObject.anchoredPosition;
			preSize = actualObject.sizeDelta;

			actualObject.SetAsLastSibling ();
			actualObject.anchoredPosition = new Vector2 (0, 0);
			actualObject.sizeDelta = new Vector2 (1000, 1000);
		}
		else
			previousObj = null;
	}
}