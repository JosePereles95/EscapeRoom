using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour {

	void OnMouseDown(){
		GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleLlaves> ().Tocado (this.tag);
	}
}
