using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestarVidas : MonoBehaviour {

	public int vidas = 3;
	[SerializeField] private List<GameObject> listVidas;

	public void Resta(){
		vidas--;
		listVidas [vidas].SetActive (false);
	}
}