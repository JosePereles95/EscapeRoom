﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioCerradura : MonoBehaviour {

	public static int correctPos;

	void Start () {
		int rnd = Random.Range (0, 6);

		correctPos = rnd;
	}
}