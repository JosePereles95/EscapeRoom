using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioIAPlaca : MonoBehaviour {

	public static int randomPlaca;

	void Start () {
		randomPlaca = Random.Range (0, 5);
	}
}
