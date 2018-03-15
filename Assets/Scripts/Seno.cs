using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seno : MonoBehaviour {

	private Vector3 startPosition;
	
	public float velocidad;
	public float velocidadAngular;
	public float offsetMovimiento;
	public float offsetRotacion;

	public Vector3 amplitud;
	public Vector3 rotacion;

	void Start () {
		startPosition = transform.position;
	}

	void Update () {
		SetPosition();
		SetRotation();
	}

	void SetPosition () {
		transform.position = startPosition + new Vector3(
			Mathf.Sin(Time.time * velocidad + offsetMovimiento) * amplitud.x,
			Mathf.Sin(Time.time * velocidad + offsetMovimiento) * amplitud.y,
			Mathf.Sin(Time.time * velocidad + offsetMovimiento) * amplitud.z
		);
	}

	void SetRotation() {
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.x = rotationVector.x + (velocidadAngular * rotacion.x % 360);
		rotationVector.y = rotationVector.y + (velocidadAngular * rotacion.y % 360);
		rotationVector.z = rotationVector.z + (velocidadAngular * rotacion.z % 360);
		transform.rotation = Quaternion.Euler(rotationVector);
	}

}