using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleIAWords : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	[SerializeField] private GameObject nota;

	[SerializeField] private InputField word1;
	[SerializeField] private InputField word2;
	[SerializeField] private InputField word3;

	[SerializeField] private Text texto1;
	[SerializeField] private Text texto2;
	[SerializeField] private Text texto3;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		nota.SetActive (false);
	}

	void Update () {
		if (AleatorioIAWords.ready) {
			texto1.text = AleatorioIAWords.listWords [0];
			texto2.text = AleatorioIAWords.listWords [1];
			texto3.text = AleatorioIAWords.listWords [2];
			AleatorioIAWords.ready = false;
		}

		string text1 = word1.text;
		if (text1 != word1.text.ToUpper ())
			word1.text = word1.text.ToUpper ();
		string text2 = word2.text;
		if (text2 != word2.text.ToUpper ())
			word2.text = word2.text.ToUpper ();
		string text3 = word3.text;
		if (text3 != word3.text.ToUpper ())
			word3.text = word3.text.ToUpper ();
	}

	public void OpenHelp(){
		nota.SetActive (!nota.activeSelf);
	}

	public void CheckWords(){
		
	}
}