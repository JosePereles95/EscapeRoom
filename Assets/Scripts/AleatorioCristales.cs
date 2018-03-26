using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioCristales : MonoBehaviour {

	[SerializeField] private List<GameObject> allNormalColores;
	[SerializeField] private List<GameObject> allShaderColores;
	[SerializeField] private List<GameObject> allPositions;
	public static List<int> listPosColores;

	// Use this for initialization
	void Start () {

		listPosColores = new List<int> ();

		for (int i = 0; i < allPositions.Count; i++) {
			int j = Random.Range (0, allNormalColores.Count - 1);
			int k = Random.Range (0, allShaderColores.Count - 1);
			allNormalColores [j].transform.position = allPositions [i].transform.position;
			allShaderColores [k].transform.position = allPositions [i].transform.position
				+ new Vector3 (0f, 0f, -0.005f);
			listPosColores.Add (k);
			allNormalColores.Remove (allNormalColores [j]);
			allShaderColores.Remove (allShaderColores [k]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
