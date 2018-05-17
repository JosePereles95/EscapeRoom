using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleIAGirar : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;
	[SerializeField] private GameObject panel;

	public static List<string> listComandos;
	private List<int> listUserOrder;
	private List<int> listCorrectOrder;

	[SerializeField] private GameObject commandsScroll;
	[SerializeField] private Button checkButton;
	[SerializeField] private Button resetButton;

	void Start(){
		VuforiaBehaviour.Instance.enabled = false;

		listComandos = new List<string> ();
		listUserOrder = new List<int> ();

		/* 0 */ listComandos.Add ("cd [IA_system]");
		/* 1 */ listComandos.Add ("ls -lh");
		/* 2 */ listComandos.Add ("sudo[hack]");
		/* 3 */ listComandos.Add ("[worm] &");
		/* 4 */ listComandos.Add ("![value]");
		/* 5 */ listComandos.Add ("cat");
		/* 6 */ listComandos.Add ("rm -R [user_data]");
		/* 7 */ listComandos.Add ("rm -f [IA_user_data]");
		/* 8 */ listComandos.Add ("[command] > [user_ID]");
		/* 9 */ listComandos.Add ("mkdir -p [/system_data] / [/system_user]");
		/* 10 */ listComandos.Add ("grep -r [user_ID] [/users]");
		/* 11 */ listComandos.Add ("pbcopy < [user_ID]");
		/* 12 */ listComandos.Add ("pbpaste");
		/* 13 */ listComandos.Add ("Ctrl+C");
		/* 14 */ listComandos.Add ("[start hack] || [force start hack]");
		/* 15 */ listComandos.Add ("open [/IA_system_data]");
		/* 16 */ listComandos.Add ("top");
		/* 17 */ listComandos.Add ("mdfind [IA_user_data]");
		/* 18 */ listComandos.Add ("reset");
		/* 19 */ listComandos.Add ("mv[user] [user_ID]");

		ButtonListComandos.ready = true;
	}

	void Update(){
		
	}

	public void PressButton(){
		GameObject buttonCommand = EventSystem.current.currentSelectedGameObject;

		string buttonCommandName = buttonCommand.GetComponentInChildren<Text> ().text;
		int index = listComandos.FindIndex (a => a == buttonCommandName);

		if (!(buttonCommand.GetComponent<Button> ().image.color == Color.green)) {
			buttonCommand.GetComponent<Button> ().image.color = Color.green;

			listUserOrder.Add (index);
		}
		else if(listUserOrder[listUserOrder.Count-1] == index){
			buttonCommand.GetComponent<Button> ().image.color = Color.white;
			listUserOrder.RemoveAt (listUserOrder.Count - 1);
		}
	}

	public void ResetList(){
		listUserOrder.Clear ();

		for (int i = 0; i < ButtonListComandos.listButtonComandos.Count; i++)
			ButtonListComandos.listButtonComandos [i].GetComponent<Button> ().image.color = Color.white;
	}

	public void CheckAnswer(){
		if (!wrongText.gameObject.activeSelf &&
		    !correctText.gameObject.activeSelf &&
		    !noVidasText.gameObject.activeSelf) {
			bool correcto = false;
			if (listUserOrder.Count == AleatorioIAGirar.listSoluciones [AleatorioIAGirar.randomSolution].Count) {
				correcto = true;
				for (int i = 0; i < AleatorioIAGirar.listSoluciones [AleatorioIAGirar.randomSolution].Count; i++) {
					if (!(listUserOrder [i] == AleatorioIAGirar.listSoluciones [AleatorioIAGirar.randomSolution] [i])) {
						correcto = false;
						break;
					}
				}
			}

			if (correcto)
				StartCoroutine (ShowCorrectText ());
			else {
				this.GetComponent<RestarVidas> ().Resta ();

				if (this.GetComponent<RestarVidas> ().vidas > 0)
					StartCoroutine (ShowWrongText ());
				else
					StartCoroutine (ShowNoVidasText ());
			}
		}
	}

	public void OpenComands(){
		commandsScroll.SetActive (!commandsScroll.activeSelf);
		checkButton.gameObject.SetActive (!checkButton.gameObject.activeSelf);
		resetButton.gameObject.SetActive (!resetButton.gameObject.activeSelf);
	}

	IEnumerator ShowWrongText(){
		panel.SetActive (true);
		wrongText.gameObject.SetActive (true);
		Handheld.Vibrate ();
		yield return new WaitForSeconds (3.0f);
		panel.SetActive (false);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		panel.SetActive (true);
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		Timer.ChangeCanvas (false, SceneManager.GetActiveScene().name, 1);
		LevelStructure.completados [16] = true;
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