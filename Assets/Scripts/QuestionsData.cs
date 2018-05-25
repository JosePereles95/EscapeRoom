using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.EventSystems;

public class QuestionsData : MonoBehaviour {

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private bool questionChecked = false;
	private int questions = 5;

	[SerializeField]private List<Button> questionsButton;

	[SerializeField] private Sprite preguntaRojo;
	[SerializeField] private Sprite preguntaVerde;

	[SerializeField] private UnityEngine.UI.Image rombos;
	[SerializeField] private Sprite rombosRojo;
	[SerializeField] private Sprite rombosVerde;
	[SerializeField] private Text myGroup;

	public static bool q1Detected = false;
	public static bool q2Detected = false;
	public static bool q3Detected = false;
	public static bool q4Detected = false;
	public static bool q5Detected = false;

	private bool q1Verified = false;
	private bool q2Verified = false;
	private bool q3Verified = false;
	private bool q4Verified = false;
	private bool q5Verified = false;

	void Start () {

		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");

		if (LevelStructure.iniciado != true) {
			for (int i = 1; i <= questions; i++) {
				mDatabase.Child("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Questions").Child ("question" + i).SetValueAsync (questionChecked);
				mDatabase.Child("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Detection").Child ("question" + i).SetValueAsync (false);
			}
		}

		myGroup.text = "Grupo " + SendData.miGrupo;
	}

	void Update () {
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {
			CheckQuestion ();
		}

		if(!q1Verified || !q2Verified || !q3Verified
			|| !q4Verified || !q5Verified)
			VerifyDetection ();
	}

	void CheckQuestion(){
		string stateQuestion;
		for (int i = 1; i <= questions; i++) {
			if (mDataSnapshot.Child("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Questions").Child ("question" + i).GetValue (true) != null) {
				stateQuestion = mDataSnapshot.Child("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Questions").Child ("question" + i).GetValue (true).ToString ();
				if (stateQuestion == "False") {
					questionsButton [i - 1].image.sprite = preguntaRojo;

					if ((i - 1) == 0)
						LevelStructure.completados [0] = false;
					else if ((i - 1) == 1)
						LevelStructure.completados [5] = false;
					else if ((i - 1) == 2)
						LevelStructure.completados [6] = false;
					else if ((i - 1) == 3)
						LevelStructure.completados [14] = false;
					else if ((i - 1) == 4)
						LevelStructure.completados [12] = false;
				}
				else{
					questionsButton [i - 1].image.sprite = preguntaVerde;

					if ((i - 1) == 0)
						LevelStructure.completados [0] = true;
					else if ((i - 1) == 1)
						LevelStructure.completados [5] = true;
					else if ((i - 1) == 2)
						LevelStructure.completados [6] = true;
					else if ((i - 1) == 3)
						LevelStructure.completados [14] = true;
					else if ((i - 1) == 4)
						LevelStructure.completados [12] = true;
				}
			}
		}

		if (questionsButton [0].image.sprite == preguntaVerde &&
		    questionsButton [1].image.sprite == preguntaVerde &&
		    questionsButton [2].image.sprite == preguntaVerde &&
		    questionsButton [3].image.sprite == preguntaVerde &&
		    questionsButton [4].image.sprite == preguntaVerde) {
			rombos.sprite = rombosVerde;
		}
		else {
			rombos.sprite = rombosRojo;
		}

	}

	public void AutoCheckQuestion(){
		int numQuestion = int.Parse (EventSystem.current.currentSelectedGameObject.name [8].ToString ());

		if(questionsButton [numQuestion - 1].image.sprite == preguntaRojo)
			mDatabase.Child("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Questions").Child ("question" + numQuestion).SetValueAsync (true);
		else
			mDatabase.Child("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Questions").Child ("question" + numQuestion).SetValueAsync (false);
	}

	public static void CheckDetected(int n){
		if (n == 0)
			q1Detected = true;
		else if (n == 5)
			q2Detected = true;
		else if (n == 6)
			q3Detected = true;
		else if (n == 14)
			q4Detected = true;
		else if (n == 12)
			q5Detected = true;
			
	}

	void VerifyDetection(){
		if (q1Detected) {
			mDatabase.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Detection").Child ("question1").SetValueAsync (true);
			q1Verified = true;
		}
		if (q2Detected) {
			mDatabase.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Detection").Child ("question2").SetValueAsync (true);
			q2Verified = true;
		}
		if (q3Detected) {
			mDatabase.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Detection").Child ("question3").SetValueAsync (true);
			q3Verified = true;
		}
		if (q4Detected) {
			mDatabase.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Detection").Child ("question4").SetValueAsync (true);
			q4Verified = true;
		}
		if (q5Detected) {
			mDatabase.Child ("Sesion " + WaitingTeacher.actualSesion).Child (SendData.userID).Child ("Detection").Child ("question5").SetValueAsync (true);
			q5Verified = true;
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
