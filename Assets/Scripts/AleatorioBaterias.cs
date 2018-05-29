using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AleatorioBaterias : MonoBehaviour {

	[SerializeField] private List<Button> listNumbers;
	[SerializeField] private List<int> listRandom;
	[SerializeField] private Text textTotal;
	public static int sumaTotal;
	private int posibilidades;

	void Start () {
		listRandom = new List<int> ();
		sumaTotal = 0;
	}

	void Update () {
		if (sumaTotal == 0) {
			listRandom.Clear();
			GenerarRespuesta ();
		}
	}

	void GenerarRespuesta(){
		//Primero se genera los números random y se evita que aparezcan duplicados
		for (int i = 0; i < listNumbers.Count; i++) {
			int num = Random.Range (1, 26);
			while (listRandom.Contains (num)) {
				Debug.Log ("Recalcula " + num);
				num = Random.Range (1, 26);
			}
			listRandom.Add (num);
			listNumbers [i].GetComponentInChildren<Text> ().text = listRandom [i].ToString();
		}

		//Luego se elige una cantidad random y se realiza la suma objetivo, asegurando que es posible
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

		//Y evitamos que la suma sea mayor a 100, ya que es un porcentaje
		if (sumaTotal > 100)
			GenerarRespuesta ();
	}
}