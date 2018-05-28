using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStructure : MonoBehaviour {

	public static List<bool> completados;
	public static List<bool> openQuestions;
	public static List<bool> objMostrado;
	public static List<bool> objCogidos;
	private int numPuzles = 19;
	private int numQuestions = 5;
	private int numObjetos = 9;
	public static bool iniciado = false;

	void Start () {
		completados = new List<bool> ();
		openQuestions = new List<bool> ();
		objMostrado = new List<bool> ();

		for (int i = 0; i < numPuzles; i++) {
			completados.Add (false);
		}

		for (int j = 0; j < numQuestions; j++) {
			openQuestions.Add (false);
		}

		for (int k = 0; k < numPuzles; k++) {
			objMostrado.Add (false);
		}

		for (int m = 0; m < numObjetos; m++) {
			objCogidos.Add (false);
		}

		iniciado = true;
	}

	void Update () {
		
	}
}
