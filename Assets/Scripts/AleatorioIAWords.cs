using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioIAWords : MonoBehaviour {

	public static string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGH";

	public static List<string> listWords;
	public static List<int> listNums;
	public static List<List<int>> listPositions;
	public static bool ready = false;

	private int numPalabras = 3;

	void Start () {
		listWords = new List<string> ();
		listNums = new List<int> ();

		listPositions = new List<List<int>> ();


		int charAmount = 7;
		for (int i = 0; i < numPalabras; i++) {
			listPositions.Add (new List<int> ());
			string cadena = "";
			for (int j = 0; j < charAmount; j++) {
				int pos = Random.Range(0, 26);
				cadena += letras[pos].ToString();
				listPositions [i].Add (pos);
			}
			listWords.Add (cadena);
		}

		for (int j = 0; j < numPalabras; j++)
			listNums.Add (Random.Range (3, 9));

		ready = true;
	}

	void Update () {
		
	}
}
