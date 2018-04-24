using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonListButton : MonoBehaviour {

	[SerializeField] private Text myText;

	public void SetText(string textString){
		myText.text = textString;
	}

	public void SetImage(Sprite sprite){
		this.GetComponent<UnityEngine.UI.Image> ().sprite = sprite;
	}
}