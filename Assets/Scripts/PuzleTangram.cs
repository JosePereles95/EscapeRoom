using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Vuforia;

public class PuzleTangram : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	[SerializeField] private List<GameObject> invisiblesColliderGato;
	[SerializeField] private List<GameObject> invisiblesColliderElefante;
	[SerializeField] private List<GameObject> invisiblesColliderPerro;
	[SerializeField] private List<GameObject> invisiblesColliderLagartija;

	private List<GameObject> invisiblesCollider;
	private List<List<GameObject>> listaInvisibles;

	private static bool checkedActive = false;
	private static GameObject obj;
	private static Vector3 mousePos;
	private static Vector3 defaultPos;

	private bool insideFigura = false;

	[SerializeField] private int correctos;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		correctos = 0;
		listaInvisibles = new List<List<GameObject>> ();

		listaInvisibles.Add (new List<GameObject> ());
		listaInvisibles.Add (new List<GameObject> ());
		listaInvisibles.Add (new List<GameObject> ());
		listaInvisibles.Add (new List<GameObject> ());

		for (int i = 0; i < invisiblesColliderGato.Count; i++) {
			listaInvisibles [0].Add (invisiblesColliderGato[i]);
		}

		for (int i = 0; i < invisiblesColliderElefante.Count; i++) {
			listaInvisibles [1].Add (invisiblesColliderElefante[i]);
		}

		for (int i = 0; i < invisiblesColliderPerro.Count; i++) {
			listaInvisibles [2].Add (invisiblesColliderPerro[i]);
		}

		for (int i = 0; i < invisiblesColliderLagartija.Count; i++) {
			listaInvisibles [3].Add (invisiblesColliderLagartija[i]);
		}
		invisiblesCollider = listaInvisibles [AleatorioTangram.randomTangram];
	}

	void Update () {
		if (!wrongText.gameObject.activeSelf &&
			!correctText.gameObject.activeSelf &&
			!noVidasText.gameObject.activeSelf) {
			if (checkedActive) {
				mousePos.z = 0.0f;
				bool colocado = false;
				insideFigura = false;
				for (int i = 0; i < invisiblesCollider.Count; i++) {
					if (invisiblesCollider [i].GetComponent<Collider> ().bounds.Contains (mousePos)) {
						insideFigura = true;
						if (invisiblesCollider [i].name == obj.name) {
							colocado = true;
							bool inside = invisiblesCollider [i].GetComponent<Collider> ().bounds.Intersects (obj.GetComponent<Collider> ().bounds);
							if (inside) {
								inside = false;
								correctos++;
								obj.transform.position = invisiblesCollider [i].transform.position;
								if (correctos == invisiblesCollider.Count) {
									StartCoroutine (ShowCorrectText ());
								}
							}
						}
					}
				}

				if (!colocado) {
					obj.transform.position = defaultPos;
					if (insideFigura) {
						this.GetComponent<RestarVidas> ().Resta ();

						if (this.GetComponent<RestarVidas> ().vidas > 0)
							StartCoroutine (ShowWrongText ());
						else
							StartCoroutine (ShowNoVidasText ());
					}
				}
			}
		}
		else if(correctos != invisiblesCollider.Count)
			obj.transform.position = defaultPos;
		
		checkedActive = false;
	}

	public static void CheckBounds(GameObject thisObj, Vector3 mousePosition, Vector3 defaultPosition){
		mousePos = mousePosition;
		defaultPos = defaultPosition;
		obj = thisObj;
		checkedActive = true;
	}

	IEnumerator ShowWrongText(){
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		noVidasText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}
}
