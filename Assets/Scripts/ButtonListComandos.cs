using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListComandos : MonoBehaviour {

	[SerializeField] private GameObject buttonTemplate;
	public static bool ready = false;
	public static List<GameObject> listButtonComandos;

	void Start() {
		listButtonComandos = new List<GameObject> ();
	}

	void Update() {
		if (ready) {
			CreateButtons ();
		}
	}

	void CreateButtons(){
		for (int i = 0; i < PuzleIAGirar.listComandos.Count; i++) {
			GameObject button = Instantiate (buttonTemplate) as GameObject;
			button.SetActive (true);

			button.GetComponent<ButtonListButton> ().SetText (PuzleIAGirar.listComandos[i]);

			button.transform.SetParent (buttonTemplate.transform.parent, false);

			listButtonComandos.Add (button);
		}
		ready = false;
	}
}
