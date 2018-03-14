using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsData : MonoBehaviour {

	private Firebase.Database.DatabaseReference mDatabase;
	private Firebase.Database.DataSnapshot mDataSnapshot;
	private string urlDatabase = "https://escaperoom-b425b.firebaseio.com/";

	private bool questionChecked = false;
	private int questions = 5;

	[SerializeField]private List<InputField> questionsInput;

	[SerializeField] private GameObject questionCanvas;

	// Use this for initialization
	void Start () {
		mDatabase = Firebase.Database.FirebaseDatabase.GetInstance (urlDatabase).GetReference("/EscapeRoom");

		for (int i = 1; i <= questions; i++) {
			mDatabase.Child (SendData.userID).Child ("Questions").Child ("question" + i).SetValueAsync (questionChecked);
		}
	}
	
	// Update is called once per frame
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
				if (stateQuestion == "False")
					questionsInput [i - 1].image.color = Color.red;
				else
					questionsInput [i - 1].image.color = Color.green;
			}
		}
	}

	public void OpenQuestions(){
		questionCanvas.SetActive (!questionCanvas.activeSelf);
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
