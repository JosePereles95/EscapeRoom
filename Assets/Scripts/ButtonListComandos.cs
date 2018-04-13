using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListComandos : MonoBehaviour {

	[SerializeField] private GameObject buttonTemplate;
	public static bool ready = false;

	void Update(){
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
		}
		ready = false;
	}
}
