using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;

//Se encarga de mostrar por pantalla el puesto en que se ha quedado cuando se acabe el tiempo

public class FinalResult : MonoBehaviour {

	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";
	[SerializeField] private Text puesto;
	
	void Update () {
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		//Mostrar el pueto el en que se ha quedado cuando la app del profesor lo haya calculado
		if (mDataSnapshot != null) {
			if (mDataSnapshot.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Puesto").GetValue (true) != null) {
				puesto.text = mDataSnapshot.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Puesto").GetValue (true).ToString () + " / " + WaitingTeacher.numGrupos;
			}
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