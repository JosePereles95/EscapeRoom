using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

//Se cogen varios números random y luego se calcula una solución posible que sea menor a 100
//luego se va comprobando la solución con la suma que va poniendo el alumno apilando baterías

public class PuzleBaterias : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;
	[SerializeField] private Text porcentajeText;
	[SerializeField] private GameObject panel;

	private int sumaActual = 0;
	[SerializeField] private GameObject objBase;
	[SerializeField] private List<GameObject> allBaterias;
	private List<GameObject> objsApilados;
	[SerializeField] private List<Button> numsBaterias;
	private List<Vector3> defaultPosObjsApilados;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		objsApilados = new List<GameObject> ();
		defaultPosObjsApilados = new List<Vector3> ();
	}

	public void Tocado(GameObject obj){

		if (!wrongText.gameObject.activeSelf &&
			!correctText.gameObject.activeSelf &&
			!noVidasText.gameObject.activeSelf) {

			Apilar (obj);

			int index = allBaterias.FindIndex(a => a.gameObject == obj);

			sumaActual += int.Parse (numsBaterias[index].GetComponentInChildren<Text>().text);
			porcentajeText.text = sumaActual + " %";

			if (sumaActual == AleatorioBaterias.sumaTotal) {
				StartCoroutine (ShowCorrectText ());
			}
			else if (sumaActual > AleatorioBaterias.sumaTotal) {
				this.GetComponent<RestarVidas> ().Resta ();

				if (this.GetComponent<RestarVidas> ().vidas > 0)
					StartCoroutine (ShowWrongText ());
				else
					StartCoroutine (ShowNoVidasText ());
			}
		}
	}

	void Apilar (GameObject objApilado){
		objsApilados.Add (objApilado);
		objApilado.GetComponent<Collider> ().enabled = false;
		defaultPosObjsApilados.Add (objApilado.transform.position);

		objApilado.transform.position = new Vector3(objBase.transform.position.x, objBase.transform.position.y + (objsApilados.Count - 1) * 0.38f, objBase.transform.position.z);
	}

	void Desapilar (){
		int numObjs = objsApilados.Count;
		int i = 0;
		while (i < numObjs) {
			objsApilados [0].transform.position = defaultPosObjsApilados [0];
			objsApilados [0].GetComponent<Collider> ().enabled = true;
			objsApilados.Remove (objsApilados [0]);
			defaultPosObjsApilados.Remove (defaultPosObjsApilados [0]);
			i++;
		}

		sumaActual = 0;
		porcentajeText.text = sumaActual + " %";
	}

	IEnumerator ShowWrongText(){
		panel.SetActive (true);
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		panel.SetActive (false);
		wrongText.gameObject.SetActive (false);
		Desapilar ();
	}

	IEnumerator ShowCorrectText(){
		panel.SetActive (true);
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, 1);
		LevelStructure.completados [4] = true;
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		panel.SetActive (true);
		noVidasText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, -1);
		SceneManager.LoadScene ("Vuforia");
	}
}