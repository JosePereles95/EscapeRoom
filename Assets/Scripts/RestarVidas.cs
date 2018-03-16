using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestarVidas : MonoBehaviour {

	public int vidas = 3;
	[SerializeField] private Text vidasText;

	void Update () {
		vidasText.text = "Quedan " + vidas + " vidas";
	}

	public void Resta(){
		vidas--;
	}
}