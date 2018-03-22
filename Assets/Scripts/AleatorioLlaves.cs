using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AleatorioLlaves : MonoBehaviour {

	[SerializeField] private List<Button> listNumbers;
	[SerializeField] private List<int> listRandom;
	[SerializeField] private Text textTotal;
	public static int sumaTotal;
	private int posibilidades;

	// Use this for initialization
	void Start () {
		listRandom = new List<int> ();
		sumaTotal = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (sumaTotal == 0) {
			listRandom.Clear();
			GenerarRespuesta ();
		}
	}

	void GenerarRespuesta(){
		
		for (int i = 0; i < listNumbers.Count; i++) {
			int num = Random.Range (1, 25);
			while (listRandom.Contains (num)) {
				Debug.Log ("Recalcula " + num);
				num = Random.Range (1, 25);
			}
			listRandom.Add (num);
			listNumbers [i].GetComponentInChildren<Text> ().text = listRandom [i].ToString();
		}

		int limite = Random.Range (3, 7);
		int a = 0;
		sumaTotal = 0;
		while (a < limite) {
			int i = Random.Range (0, listRandom.Count);
			sumaTotal += listRandom [i];
			listRandom.Remove (listRandom [i]);
			a++;
		}

		textTotal.text = sumaTotal + " %";

		if (sumaTotal > 100)
			GenerarRespuesta ();
	}
}