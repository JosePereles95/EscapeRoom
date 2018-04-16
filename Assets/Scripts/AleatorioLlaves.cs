using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioLlaves : MonoBehaviour {

	[SerializeField] private List<GameObject> allCerraduras;
	[SerializeField] private List<GameObject> allPositions;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < allCerraduras.Count; i++) {
			int j = Random.Range (0, allPositions.Count);
			allCerraduras [i].transform.position = allPositions [j].transform.position;
			allPositions.Remove (allPositions [j]);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}