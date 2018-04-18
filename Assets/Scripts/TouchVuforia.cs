using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TouchVuforia : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Cerradura ();
	}

	public void Llaves(){
		SceneManager.LoadScene ("PuzleLlaves");
	}

	public void Baterias(){
		SceneManager.LoadScene ("PuzleBaterias");
	}

	public void Laberinto(){
		SceneManager.LoadScene ("PuzleLaberinto");
	}

	public void Cristales(){
		SceneManager.LoadScene ("PuzleCristales");
	}

	public void Tangram(){
		SceneManager.LoadScene ("PuzleTangram");
	}

	public void Cerradura(){
		SceneManager.LoadScene ("PuzleCerradura");
	}

	public void IAGirar(){
		SceneManager.LoadScene ("PuzleIAGirar");
	}

	public void IALoops(){
		SceneManager.LoadScene ("PuzleIALoops");
	}
}
