using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour {

	/*[SerializeField] private GameObject */

	[SerializeField] private GameObject tangramText;
	[SerializeField] private GameObject bateriasText;
	[SerializeField] private GameObject problema2Text;
	[SerializeField] private GameObject problema3Text1;
	[SerializeField] private GameObject problema3Text2;
	[SerializeField] private GameObject problema5Text;

	[SerializeField] private GameObject text1IA1;
	[SerializeField] private GameObject text2IA1;
	[SerializeField] private GameObject text1IA2;
	[SerializeField] private GameObject text2IA2;
	[SerializeField] private GameObject text1IA3;
	[SerializeField] private GameObject text2IA3;

	[SerializeField] private GameObject objDesapareceLlaves;
	[SerializeField] private GameObject objDesapareceTarjeta;
	[SerializeField] private GameObject objDesapareceBaterias;
	[SerializeField] private GameObject objDesapareceUsuario;
	[SerializeField] private GameObject objDesapareceDestornillador;
	[SerializeField] private GameObject objDesapareceNotaClip;
	[SerializeField] private GameObject objDesapareceCortadora;
	[SerializeField] private GameObject objDesapareceFoto;
	[SerializeField] private GameObject objDesapareceCristales;

	private bool firstFrame = true;

	void Update () {
		//Quitar los objetos cogidos de Vuforia y evitar volver a mostrarlos (todo feedback visual)
		if (LevelStructure.iniciado) {
			if (LevelStructure.completados [3])
				tangramText.SetActive (true);

			if (LevelStructure.completados [4])
				bateriasText.SetActive (true);

			if (LevelStructure.openQuestions [1])
				problema2Text.SetActive (true);

			if (LevelStructure.completados [6]) {
				problema3Text1.SetActive (false);
				problema3Text2.SetActive (true);
			}

			if (LevelStructure.openQuestions [4])
				problema5Text.SetActive (true);

			if (LevelStructure.completados [15]) {
				text1IA1.SetActive (false);
				text2IA1.SetActive (true);
			}

			if (LevelStructure.completados [16]) {
				text1IA2.SetActive (false);
				text2IA2.SetActive (true);
			}

			if (LevelStructure.completados [17]) {
				text1IA3.SetActive (false);
				text2IA3.SetActive (true);
			}


			if (!LevelStructure.objCogidos [0]) {
				if (LevelStructure.openQuestions [0])
					StartCoroutine (DesapareceObjeto (0, objDesapareceLlaves));
			} else if (firstFrame)
				objDesapareceLlaves.SetActive (false);

			if (!LevelStructure.objCogidos [1]) {
				if (LevelStructure.completados [2])
					StartCoroutine (DesapareceObjeto (1, objDesapareceTarjeta));
			} else if (firstFrame)
				objDesapareceTarjeta.SetActive (false);

			if (!LevelStructure.objCogidos [2]) {
				if (LevelStructure.completados [3])
					StartCoroutine (DesapareceObjeto (2, objDesapareceBaterias));
			}
			else if (firstFrame)
				objDesapareceBaterias.SetActive (false);

			if (!LevelStructure.objCogidos [3]) {
				if (LevelStructure.completados [4])
					StartCoroutine (DesapareceObjeto (3, objDesapareceUsuario));
			}
			else if (firstFrame)
				objDesapareceUsuario.SetActive (false);

			if (!LevelStructure.objCogidos [4]) {
				if (LevelStructure.objMostrado [2])
					StartCoroutine (DesapareceObjeto (4, objDesapareceDestornillador));
			}
			else if (firstFrame)
				objDesapareceDestornillador.SetActive (false);

			if (!LevelStructure.objCogidos [5]) {
				if (LevelStructure.completados [7])
					StartCoroutine (DesapareceObjeto (5, objDesapareceNotaClip));
			}
			else if (firstFrame)
				objDesapareceNotaClip.SetActive (false);

			if (!LevelStructure.objCogidos [6]) {
				if (LevelStructure.completados [8])
					StartCoroutine (DesapareceObjeto (6, objDesapareceCortadora));
			}
			else if (firstFrame)
				objDesapareceCortadora.SetActive (false);

			if (!LevelStructure.objCogidos [7]) {
				if (LevelStructure.completados [9])
					StartCoroutine (DesapareceObjeto (7, objDesapareceFoto));
			}
			else if (firstFrame)
				objDesapareceFoto.SetActive (false);

			if (!LevelStructure.objCogidos [8]) {
				if (LevelStructure.completados [11])
					StartCoroutine (DesapareceObjeto (8, objDesapareceCristales));
			}
			else if (firstFrame)
				objDesapareceCristales.SetActive (false);

			firstFrame = false;
		}
	}

	IEnumerator DesapareceObjeto (int n, GameObject obj) {
		LevelStructure.objCogidos [n] = true;
		yield return new WaitForSeconds (8.0f);
		obj.SetActive (false);
	}
}