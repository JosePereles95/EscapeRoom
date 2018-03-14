using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Firebase;
using UnityEngine.SceneManagement;

public class SendData : MonoBehaviour {

	//public InputField data;
	//public InputField readData;
	public InputField q1Data;

	public InputField gInput;
	//Button buttonPressed;

	//public InputField consolaAndroid;
	//public int check = 0;
	public string grupoElegido = "";

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	//private string newDato;
	private string newQ1;

	const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
	public static string userID;
	private bool grupoValido = false;


	void Start(){
		int charAmount = Random.Range(20, 35); //set those to the minimum and maximum length of your string
		for(int i=0; i<charAmount; i++)
		{
			userID += glyphs[Random.Range(0, glyphs.Length)];
		}

		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
	}

	void Update(){
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {
			Debug.Log (mDataSnapshot.Child ("All Confirmed").GetValue (true).ToString ());
			if (mDataSnapshot.Child ("All Confirmed").GetValue (true).ToString() == "True")
				SceneManager.LoadScene ("Vuforia");
		}

		if (grupoElegido != "") {
			if (grupoValido) {
				gInput.text = grupoElegido;
				gInput.image.color = Color.green;
			}
			else {
				gInput.image.color = Color.red;
				gInput.text = "Grupo inválido";
				grupoElegido = "";
			}
		}
	}

	public void CheckGrupo(){
		if (grupoElegido == "") {
			grupoElegido = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

			if(mDataSnapshot.Child ("Grupos").Child (grupoElegido).GetValue(true) == null){
				grupoValido = true;
				Debug.Log (grupoElegido + " ; " + userID);
				mDatabase.Child(userID).Child("mi Grupo").SetValueAsync (grupoElegido);
				mDatabase.Child ("Grupos").Child (grupoElegido).Child ("userID").SetValueAsync (userID);
			}
		}
	}

	void HandleValueChanged(object sender, Firebase.Database.ValueChangedEventArgs args){
		//check++;

		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			//consolaAndroid.text = "ERROR";
			return;
		}
		mDataSnapshot = args.Snapshot;
	}
}