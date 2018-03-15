using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class WaitingTeacher : MonoBehaviour {

	public static int numGrupos = 0;

	//private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	void Start(){
		VuforiaBehaviour.Instance.enabled = false;
		//mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
	}
		
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

		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			return;
		}
		mDataSnapshot = args.Snapshot;
	}
}