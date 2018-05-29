using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioCristales : MonoBehaviour {

	[SerializeField] private List<GameObject> allNormalColores;
	[SerializeField] private List<GameObject> allShaderColores;
	[SerializeField] private List<GameObject> allPositions;
	public static List<int> listPosColores;

	void Start () {

		listPosColores = new List<int> ();

		//Se colocan los colores en posiciones random y evitamos que se repitan
		for (int i = 0; i < allPositions.Count; i++) {
			int j = Random.Range (0, allNormalColores.Count);
			int k = Random.Range (0, allShaderColores.Count);
			allNormalColores [j].transform.position = allPositions [i].transform.position;
			allShaderColores [k].transform.position = allPositions [i].transform.position;
			int n = int.Parse (allShaderColores [k].name [0].ToString ());
			listPosColores.Add (n);
			allNormalColores.Remove (allNormalColores [j]);
			allShaderColores.Remove (allShaderColores [k]);
		}
	}
}