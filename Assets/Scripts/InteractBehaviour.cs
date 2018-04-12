using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour {

	void OnMouseDown(){
		if(GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleLlaves> () != null)
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleLlaves> ().Tocado (this.gameObject);
		
		else if(GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleBaterias> () != null)
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleBaterias> ().Tocado (this.gameObject);
		
		else if(GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> () != null)
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().Tocado (this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "stopDest") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().stopMoveDest = true;
		}
		else if (other.tag == "stopClip1") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().stopMoveClip1 = true;
		}
		else if (other.tag == "stopClip2") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().stopMoveClip2 = true;
		}
		/*else if (other.tag == "position") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().tocando = true;
		}*/
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "stopDest") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().stopMoveDest = false;
		}
		else if (other.tag == "stopClip1") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().stopMoveClip1 = false;
		}
		else if (other.tag == "stopClip2") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().stopMoveClip2 = false;
		}
		/*else if (other.tag == "position") {
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().tocando = false;
		}*/
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "position")
			GameObject.FindGameObjectWithTag ("GameLogic").GetComponent<PuzleCerradura> ().TocaPosition (other.name);
	}
}
