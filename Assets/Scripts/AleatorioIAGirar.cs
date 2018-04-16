using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioIAGirar : MonoBehaviour {

	[SerializeField] private List<GameObject> listIcosaedros;
	public static List<List<int>> listSoluciones;
	public static int randomSolution;

	void Start () {
		listSoluciones = new List<List<int>> ();
		listSoluciones.Add (new List<int> ());
		listSoluciones.Add (new List<int> ());
		listSoluciones.Add (new List<int> ());
		listSoluciones.Add (new List<int> ());
		listSoluciones.Add (new List<int> ());

		listSoluciones [0].Add (9);
		listSoluciones [0].Add (13);
		listSoluciones [0].Add (10);
		listSoluciones [0].Add (3);
		listSoluciones [0].Add (7);
		listSoluciones [0].Add (8);
		listSoluciones [0].Add (4);
		listSoluciones [0].Add (1);
		listSoluciones [0].Add (12);
		listSoluciones [0].Add (5);

		listSoluciones [1].Add (19);
		listSoluciones [1].Add (8);
		listSoluciones [1].Add (6);
		listSoluciones [1].Add (16);
		listSoluciones [1].Add (7);
		listSoluciones [1].Add (9);
		listSoluciones [1].Add (18);
		listSoluciones [1].Add (15);
		listSoluciones [1].Add (2);
		listSoluciones [1].Add (4);

		listSoluciones [2].Add (14);
		listSoluciones [2].Add (13);
		listSoluciones [2].Add (5);
		listSoluciones [2].Add (17);
		listSoluciones [2].Add (3);
		listSoluciones [2].Add (12);
		listSoluciones [2].Add (0);
		listSoluciones [2].Add (10);
		listSoluciones [2].Add (1);
		listSoluciones [2].Add (11);

		listSoluciones [3].Add (19);
		listSoluciones [3].Add (15);
		listSoluciones [3].Add (8);
		listSoluciones [3].Add (6);
		listSoluciones [3].Add (18);
		listSoluciones [3].Add (9);
		listSoluciones [3].Add (3);
		listSoluciones [3].Add (10);
		listSoluciones [3].Add (0);
		listSoluciones [3].Add (12);

		listSoluciones [4].Add (4);
		listSoluciones [4].Add (17);
		listSoluciones [4].Add (14);
		listSoluciones [4].Add (7);
		listSoluciones [4].Add (11);
		listSoluciones [4].Add (16);
		listSoluciones [4].Add (1);
		listSoluciones [4].Add (5);
		listSoluciones [4].Add (13);
		listSoluciones [4].Add (2);

		randomSolution = Random.Range (0, 5);

		listIcosaedros [randomSolution].SetActive (true);
	}
}
