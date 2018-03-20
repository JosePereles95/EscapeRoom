using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour {

	void OnMouseDown(){
		if(GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleLlaves> () != null)
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleLlaves> ().Tocado (this.gameObject);
		
		else if(GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleBaterias> () != null)
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleBaterias> ().Tocado (this.gameObject);
	}
}
