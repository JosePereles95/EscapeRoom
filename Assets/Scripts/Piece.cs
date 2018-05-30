using UnityEngine;
using System.Collections;

//Controla la partida de IA Loops y va realizando los giros que el alumno haga hasta
//que se haya creado un bucle correcto

public class Piece : MonoBehaviour {

	public int[] values;
	public float speed;
	private float realRotation;

	public GameManager gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}
		
	void Update () {

		if (transform.root.eulerAngles.x != realRotation) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (realRotation, -90, 90), speed);
		}
	}

	void OnMouseDown(){

		int difference = -gm.QuickSweep((int)transform.position.x,(int)transform.position.y);

		RotatePiece ();

		difference += gm.QuickSweep((int)transform.position.x,(int)transform.position.y);

		gm.puzzle.curValue += difference;

		if (gm.puzzle.curValue == gm.puzzle.winValue)
			gm.Win ();
	}

	public void RotatePiece(){
		realRotation += 90;

		if (realRotation == 360)
			realRotation = 0;

		RotateValues ();
	}

	public void RotateValues(){
		int aux = values [0];

		for (int i = 0; i < values.Length-1; i++) {
			values [i] = values [i + 1];
		}
		values [3] = aux;
	}
}