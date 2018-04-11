using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Vuforia;

public class PuzleCerradura : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	private float f_lastX = 0.0f;
	private float f_difX = 0.5f;

	private Quaternion defaultPos;

	[SerializeField] private GameObject objAll;
	[SerializeField] private GameObject objClip;

	private GameObject objToRotate;
	private bool enableRotation = false;
	private string objTag;
	private float speed = 10.0f;
	private float speedRotation = 0.1f;

	public bool stopMoveDest = false;
	public bool stopMoveClip1 = false;
	public bool stopMoveClip2 = false;

	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		defaultPos = objAll.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if (enableRotation)
			RotateObj ();
		else if(objTag == "destornillador"){
			objAll.transform.rotation = Quaternion.Lerp (objAll.transform.rotation, defaultPos, Time.deltaTime * speed);
		}
	}

	public void Tocado(GameObject obj){
		objTag = obj.tag;

		if (objTag == "clip")
			objToRotate = objClip;
		else if (objTag == "destornillador")
			objToRotate = objAll;
		
		enableRotation = true;
	}

	void RotateObj(){
		if (Input.GetButtonDown (0))
			f_lastX = 0.0f;
		else if (Input.GetMouseButton (0)) {
			f_difX = Mathf.Abs (f_lastX - Input.GetAxis ("Mouse X")) * speedRotation;

			if (f_lastX > Input.GetAxis ("Mouse X")) {
				if(objTag == "destornillador" && !stopMoveDest)
					objToRotate.transform.Rotate (Vector3.forward, f_difX);
				else if(objTag == "clip" && !stopMoveClip2)
					objToRotate.transform.Rotate (Vector3.forward, -f_difX);
			}
			if (f_lastX < Input.GetAxis ("Mouse X")) {
				if(objTag == "destornillador" && !stopMoveDest)
					objToRotate.transform.Rotate (Vector3.forward, -f_difX);
				else if(objTag == "clip" && !stopMoveClip1)
					objToRotate.transform.Rotate (Vector3.forward, f_difX);
			}

			f_lastX = -Input.GetAxis ("Mouse X");
		}
		else {
			enableRotation = false;
		}
			
	}

	IEnumerator ShowWrongText(){
		wrongText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		wrongText.gameObject.SetActive (false);
	}

	IEnumerator ShowCorrectText(){
		correctText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		noVidasText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		SceneManager.LoadScene ("Vuforia");
	}
}
