﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStructure : MonoBehaviour {

	public static List<bool> completados;
	public static List<bool> openQuestions;
	private int numPuzles = 15;
	private int numQuestions = 5;
	public static bool iniciado = false;

	void Start () {
		completados = new List<bool> ();
		openQuestions = new List<bool> ();

		for (int i = 0; i < numPuzles; i++) {
			completados.Add (false);
		}

		for (int j = 0; j < numQuestions; j++) {
			openQuestions.Add (false);
		}

		iniciado = true;
	}

	void Update () {
		
	}
}
