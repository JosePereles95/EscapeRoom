using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioIAWords : MonoBehaviour {

	private string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public static List<string> listWords;
	public static bool ready = false;

	private int numPalabras = 3;

	void Start () {
		listWords = new List<string> ();

		int charAmount = 7;
		for (int i = 0; i < numPalabras; i++) {
			string cadena = "";
			for (int j = 0; j < charAmount; j++) {
				cadena += letras[Random.Range(0, 26)].ToString();
			}
			Debug.Log (cadena);
			listWords.Add (cadena);
		}

		ready = true;
	}

	void Update () {
		
	}
}
