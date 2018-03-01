using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;

public class SendData : MonoBehaviour {

	public InputField data;
	public InputField readData;
	public InputField q1Data;

	public InputField consolaAndroid;
	public int check = 0;

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private bool questionChecked = false;
	private string newDato;
	private string newQ1;

	void Start(){
		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
		mDatabase.Child ("question1").SetValueAsync (questionChecked);
	}

	void Update(){

		Firebase.Database.FirebaseDatabase.DefaultInstance.GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		consolaAndroid.text = check.ToString();

		if (mDataSnapshot != null) {
			consolaAndroid.image.color = Color.green;
			if (mDataSnapshot.Child ("data").GetValue (true) != null) {
				newDato = mDataSnapshot.Child ("data").GetValue (true).ToString ();
				readData.text = newDato;
			}

			if (newDato == "hola")
				readData.image.color = Color.green;
		
			if (mDataSnapshot.Child ("question1").GetValue (true) != null) {
				if (newQ1 == "true")
					q1Data.image.color = Color.yellow;
				else
					q1Data.image.color = Color.red;
			}
		}
	}

	public void SendButtonPressed(){
		mDatabase.Child ("data").SetValueAsync (data.text);
	}

	public void CheckButtonPressed(){
		questionChecked = true;
		mDatabase.Child ("question1").SetValueAsync (questionChecked);
	}

	void HandleValueChanged(object sender, Firebase.Database.ValueChangedEventArgs args){
		check++;

		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			return;
		}
		mDataSnapshot = args.Snapshot;
	}
		
}