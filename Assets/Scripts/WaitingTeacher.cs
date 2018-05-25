using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;
using UnityEngine.UI;

public class WaitingTeacher : MonoBehaviour {

	public static int numGrupos = 0;

	//private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	[SerializeField] private Button okButton;

	[SerializeField] private Text esperando;
	[SerializeField] private Text sesionActiva;

	private bool sesionOK = false;
	public static int actualSesion = 0;

	void Start(){
		Application.runInBackground = true;
		VuforiaBehaviour.Instance.enabled = false;
		//mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
	}
		
	void Update () {
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {
			
			if (sesionOK) {
				if (mDataSnapshot.Child ("Sesion " + WaitingTeacher.actualSesion).Child ("All Confirmed").GetValue (true) != null) {
					if (mDataSnapshot.Child ("Sesion " + WaitingTeacher.actualSesion).Child ("All Confirmed").GetValue (true).ToString () != "True") {
						if (mDataSnapshot.Child ("Sesion " + actualSesion).Child ("Num Grupos").GetValue (true) != null) {
							numGrupos = int.Parse (mDataSnapshot.Child ("Sesion " + actualSesion).Child ("Num Grupos").GetValue (true).ToString ());
						}
					}
					else {
						esperando.gameObject.SetActive (false);
						sesionActiva.gameObject.SetActive (true);
						okButton.gameObject.SetActive (false);
					}
				}
			}
			else if (mDataSnapshot.Child ("Sesiones").GetValue (true) != null) {
				actualSesion = int.Parse (mDataSnapshot.Child ("Sesiones").GetValue (true).ToString ());
				sesionOK = true;
			}
				

		}

		if (numGrupos != 0) {
			okButton.gameObject.SetActive (true);	
		}
	}

	void HandleValueChanged(object sender, Firebase.Database.ValueChangedEventArgs args){

		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			return;
		}
		mDataSnapshot = args.Snapshot;
	}

	public void NextScene(){
		SceneManager.LoadScene ("SelectGroup");
	}
}