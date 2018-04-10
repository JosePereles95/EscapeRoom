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

	public List<GameObject> invisiblesCollider;

	private static bool checkedActive = false;
	private static GameObject obj;
	private static Vector3 mousePos;
	private static Vector3 defaultPos;

	[SerializeField] private int correctos;

	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		correctos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!wrongText.gameObject.activeSelf && !correctText.gameObject.activeSelf) {
			if (checkedActive) {
				mousePos.z = 0.0f;
				bool colocado = false;
				for (int i = 0; i < invisiblesCollider.Count; i++) {
					if (invisiblesCollider [i].GetComponent<Collider> ().bounds.Contains (mousePos) && invisiblesCollider [i].name == obj.name) {
						colocado = true;
						bool inside = invisiblesCollider [i].GetComponent<Collider> ().bounds.Intersects (obj.GetComponent<Collider> ().bounds);
						if (inside) {
							inside = false;
							correctos++;
							obj.transform.position = invisiblesCollider [i].transform.position;
							if (correctos == invisiblesCollider.Count*2) {
								StartCoroutine(ShowCorrectText());
							}
						}
					}
				}

				if (!colocado) {
					obj.transform.position = defaultPos;
					this.GetComponent<RestarVidas> ().Resta ();

					if (this.GetComponent<RestarVidas> ().vidas > 0)
						StartCoroutine (ShowWrongText ());
					else
						StartCoroutine (ShowNoVidasText ());
				}
			}
		}
		else if(correctos != invisiblesCollider.Count*2)
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
		yield return new WaitForSeconds (3.0f);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		noVidasText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		SceneManager.LoadScene ("Vuforia");
	}
}
