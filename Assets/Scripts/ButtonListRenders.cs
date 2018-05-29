using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListRenders : MonoBehaviour {

	[SerializeField] private GameObject buttonTemplate;
	[SerializeField] private List<Sprite> rendersObjs;
	public static List<GameObject> listButtonRenders;

	private int numButtons = 45;

	void Start() {
		listButtonRenders = new List<GameObject> ();
		CreateButtons ();
	}

	void CreateButtons(){

		for (int i = 0; i < numButtons; i++) {
			GameObject button = Instantiate (buttonTemplate) as GameObject;
			button.SetActive (true);

			button.GetComponent<ButtonListButton> ().SetImage(rendersObjs[i]);

			button.transform.SetParent (buttonTemplate.transform.parent, false);

			listButtonRenders.Add (button);
		}
	}
}