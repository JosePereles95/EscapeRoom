using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Firebase;
using UnityEngine.SceneManagement;
using Vuforia;

public class SendData : MonoBehaviour {

	public static float minsJuego;

	public InputField gInput;

	private string grupoElegido = "";

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private string newQ1;

	const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
	public static string userID;
	private bool grupoValido = false;

	public static int miGrupo;

	private List<string> usuarios;

	void Start(){
		usuarios = new List<string> ();

		VuforiaBehaviour.Instance.enabled = false;

		int charAmount = Random.Range(25, 35); //set those to the minimum and maximum length of your string
		for(int i=0; i<charAmount; i++){
			bool ok = false;
			while(!ok) {
				userID += glyphs[Random.Range(0, glyphs.Length)];
				if (!(usuarios.Contains (userID))) {
					usuarios.Add (userID);
					ok = true;
				}
			}
		}

		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");
	}

	void Update(){
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {
			if (mDataSnapshot.Child("Sesion " + WaitingTeacher.actualSesion).Child ("All Confirmed").GetValue (true).ToString() == "True")
				SceneManager.LoadScene ("Vuforia");
			if(mDataSnapshot.Child("Sesion " + WaitingTeacher.actualSesion).Child ("Tiempo").GetValue (true) != null)
				minsJuego = float.Parse(mDataSnapshot.Child("Sesion " + WaitingTeacher.actualSesion).Child ("Tiempo").GetValue (true).ToString ());
		}

		if (grupoElegido != "") {
			if (grupoValido) {
				gInput.text = grupoElegido;
				gInput.image.color = Color.green;
			}
			else {
				gInput.image.color = Color.red;
				gInput.text = "Ocupado";
				grupoElegido = "";
			}
		}
	}

	public void CheckGrupo(){
		if (grupoElegido == "") {
			grupoElegido = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

			if(mDataSnapshot.Child("Sesion " + WaitingTeacher.actualSesion).Child ("Grupos").Child (grupoElegido).GetValue(true) == null){
				grupoValido = true;
				mDatabase.Child("Sesion " + WaitingTeacher.actualSesion).Child(userID).Child("mi Grupo").SetValueAsync (grupoElegido);
				mDatabase.Child("Sesion " + WaitingTeacher.actualSesion).Child ("Grupos").Child (grupoElegido).Child ("userID").SetValueAsync (userID);
				miGrupo = int.Parse(grupoElegido[6].ToString());
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