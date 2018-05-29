using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioTangram : MonoBehaviour {

	public static int randomTangram;

	[SerializeField] private GameObject piezasGato;
	[SerializeField] private GameObject invisiblesGato;
	[SerializeField] private GameObject baseGato;

	[SerializeField] private GameObject piezasElefante;
	[SerializeField] private GameObject invisiblesElefante;
	[SerializeField] private GameObject baseElefante;

	[SerializeField] private GameObject piezasPerro;
	[SerializeField] private GameObject invisiblesPerro;
	[SerializeField] private GameObject basePerro;

	[SerializeField] private GameObject piezasLagartija;
	[SerializeField] private GameObject invisiblesLagartija;
	[SerializeField] private GameObject baseLagartija;

	private List<GameObject> listaConjuntos;

	void Start () {
		//Base para mostrar la forma, invisible para saber si se ha colocado bien, y las piezas normales
		randomTangram = Random.Range (0, 4);

		listaConjuntos = new List<GameObject> ();

		listaConjuntos.Add (piezasGato);
		listaConjuntos.Add (invisiblesGato);
		listaConjuntos.Add (baseGato);

		listaConjuntos.Add (piezasElefante);
		listaConjuntos.Add (invisiblesElefante);
		listaConjuntos.Add (baseElefante);

		listaConjuntos.Add (piezasPerro);
		listaConjuntos.Add (invisiblesPerro);
		listaConjuntos.Add (basePerro);

		listaConjuntos.Add (piezasLagartija);
		listaConjuntos.Add (invisiblesLagartija);
		listaConjuntos.Add (baseLagartija);

		//Activamos los 3 conjuntos de la figura que haya tocado random
		listaConjuntos [randomTangram * 3].SetActive (true);
		listaConjuntos [randomTangram * 3 + 1].SetActive (true);
		listaConjuntos [randomTangram * 3 + 2].SetActive (true);
	}
}