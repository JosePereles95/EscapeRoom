using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStructure : MonoBehaviour {

	//Booleanos para indicar el progreso del alumno en el juego que van
	//cambiando los distintos scripts de los puzles y los objetos que se van completando

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
		objCogidos = new List<bool> ();

		//Se ha cpmpletado cada parte del juego (puzles, preguntas, cajones)
		for (int i = 0; i < numPuzles; i++) {
			completados.Add (false);
		}

		//Los objetos de las preguntas se han abierto
		for (int j = 0; j < numQuestions; j++) {
			openQuestions.Add (false);
		}

		//Ya se ha moestrado el mensaje de lo que se ha cogido, evitar duplicados al volver a Vuforia
		for (int k = 0; k < numPuzles; k++) {
			objMostrado.Add (false);
		}

		//Quitar objetos cogidos y evitar ponerlos al volver a Vuforia
		for (int m = 0; m < numObjetos; m++) {
			objCogidos.Add (false);
		}

		iniciado = true;
	}
}