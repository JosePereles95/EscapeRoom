using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioCerradura : MonoBehaviour {

	public static int correctPos;

	// Use this for initialization
	void Start () {
		int rnd = Random.Range (1, 6);

		correctPos = rnd;
	}
}
