using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingTeacher : MonoBehaviour {

	public static int numGrupos = 0;

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	void Start(){
		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
	}

	// Update is called once per frame
	void Update () {
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {
			if(mDataSnapshot.Child ("Num Grupos").GetValue (true) != null)
				numGrupos = int.Parse (mDataSnapshot.Child ("Num Grupos").GetValue (true).ToString ());
		}

		if (numGrupos != 0) {
			SceneManager.LoadScene ("SelectGroup");
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
