using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class QuestionsData : MonoBehaviour {

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private bool questionChecked = false;
	private int questions = 5;

	[SerializeField]private List<InputField> questionsInput;

	[SerializeField] private Sprite preguntaRojo;
	[SerializeField] private Sprite preguntaVerde;

	[SerializeField] private UnityEngine.UI.Image rombos;
	[SerializeField] private Sprite rombosRojo;
	[SerializeField] private Sprite rombosVerde;

	void Start () {

		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");

		if (LevelStructure.iniciado != true) {
			for (int i = 1; i <= questions; i++) {
				mDatabase.Child (SendData.userID).Child ("Questions").Child ("question" + i).SetValueAsync (questionChecked);
			}
		}
	}

	void Update () {
		Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom").ValueChanged += HandleValueChanged;

		if (mDataSnapshot != null) {
			CheckQuestion ();
		}
	}

	void CheckQuestion(){
		string stateQuestion;
		for (int i = 1; i <= questions; i++) {
			if (mDataSnapshot.Child (SendData.userID).Child ("Questions").Child ("question" + i).GetValue (true) != null) {
				stateQuestion = mDataSnapshot.Child (SendData.userID).Child ("Questions").Child ("question" + i).GetValue (true).ToString ();
				if (stateQuestion == "False") {
					questionsInput [i - 1].image.sprite = preguntaRojo;

					if ((i - 1) == 0)
						LevelStructure.completados [0] = false;
					else if ((i - 1) == 1)
						LevelStructure.completados [5] = false;
					else if ((i - 1) == 2)
						LevelStructure.completados [6] = false;
					else if ((i - 1) == 3)
						LevelStructure.completados [12] = false;
					else if ((i - 1) == 4)
						LevelStructure.completados [14] = false;
				}
				else{
					questionsInput [i - 1].image.sprite = preguntaVerde;

					if ((i - 1) == 0)
						LevelStructure.completados [0] = true;
					else if ((i - 1) == 1)
						LevelStructure.completados [5] = true;
					else if ((i - 1) == 2)
						LevelStructure.completados [6] = true;
					else if ((i - 1) == 3)
						LevelStructure.completados [12] = true;
					else if ((i - 1) == 4)
						LevelStructure.completados [14] = true;
				}
			}
		}

		if (questionsInput [0].image.sprite == preguntaVerde &&
		    questionsInput [1].image.sprite == preguntaVerde &&
		    questionsInput [2].image.sprite == preguntaVerde &&
		    questionsInput [3].image.sprite == preguntaVerde &&
		    questionsInput [4].image.sprite == preguntaVerde) {
			rombos.sprite = rombosVerde;
		}
		else {
			rombos.sprite = rombosRojo;
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
