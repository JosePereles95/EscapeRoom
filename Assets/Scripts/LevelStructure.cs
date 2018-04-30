using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStructure : MonoBehaviour {

	public static List<bool> completados;

	void Start () {
		completados = new List<bool> ();

		for (int i = 0; i < 15; i++) {
			completados.Add (false);
		}
	}

	void Update () {
		
	}
}
