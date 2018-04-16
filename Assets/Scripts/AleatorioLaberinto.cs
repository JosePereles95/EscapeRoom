using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioLaberinto : MonoBehaviour {

	[SerializeField] private List<GameObject> listLaberintos;
	public static string solucion;

	// Use this for initialization
	void Start () {
		int i = Random.Range (0, listLaberintos.Count);

		listLaberintos [i].SetActive (true);
		solucion = listLaberintos [i].name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
