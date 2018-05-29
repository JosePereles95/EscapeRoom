using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioLaberinto : MonoBehaviour {

	[SerializeField] private List<GameObject> listLaberintos;
	public static string solucion;

	void Start () {
		//Activar una de las 10 soluciones posibles
		int i = Random.Range (0, listLaberintos.Count);

		listLaberintos [i].SetActive (true);
		solucion = listLaberintos [i].name;
	}
}