using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioIAPlaca : MonoBehaviour {

	public static int randomBase;
	public static int randomCilindro;
	public static int randomChip;
	public static int randomCPU;
	public static int randomCubo;
	public static int randomRejilla;
	public static int randomConexion;
	public static int randomTarjeta;
	public static int randomCajita;
	public static int randomCuadradito;

	void Start () {
		randomBase = Random.Range (0, 5);
		randomCilindro = Random.Range (0, 5);
		randomChip = Random.Range (0, 5);
		randomCPU = Random.Range (0, 5);
		randomCubo = Random.Range (0, 5);
		randomRejilla = Random.Range (0, 5);
		randomConexion = Random.Range (0, 5);
		randomTarjeta = Random.Range (0, 5);
		randomCajita = Random.Range (0, 5);
		randomCuadradito = Random.Range (0, 5);
	}
}
