using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Firebase;

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

	private string questionChecked = "false";
	//private string newDato;
	private string newQ1;

	const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
	public string userID;
	private bool grupoValido = false;
	private int questions = 5;

	void Start(){
		int charAmount = Random.Range(20, 35); //set those to the minimum and maximum length of your string
		for(int i=0; i<charAmount; i++)
		{
			userID += glyphs[Random.Range(0, glyphs.Length)];
		}

		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
		for (int i = 1; i <= questions; i++)
			mDatabase.Child (userID).Child ("Questions").Child ("question" + i).SetValueAsync (questionChecked);
	}

	void Update(){
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {

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

	/*public void SendButtonPressed(){
		mDatabase.Child(userID).Child ("data").SetValueAsync (data.text);
	}

	public void CheckButtonPressed(){
		questionChecked = "true";
		mDatabase.Child(userID).Child ("Questions").Child ("question1").SetValueAsync (questionChecked);
	}*/

	public void CheckGrupo(){
		if (grupoElegido == "") {
			grupoElegido = EventSystem.current.currentSelectedGameObject.name;

			if(mDataSnapshot.Child ("Grupos").Child (grupoElegido).GetValue(true) == null){
				grupoValido = true;
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