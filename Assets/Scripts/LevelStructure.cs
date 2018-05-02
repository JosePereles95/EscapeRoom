using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStructure : MonoBehaviour {

	public static List<bool> completados;
	private int numPuzles = 14;

	void Start () {
		completados = new List<bool> ();

		for (int i = 0; i < numPuzles; i++) {
			completados.Add (false);
		}
	}

	void Update () {
		
	}
}
