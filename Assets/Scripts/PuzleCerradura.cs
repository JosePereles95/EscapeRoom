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
	private float speedRotation = 0.45f;

	[SerializeField] private int correctPosition;
	private int numPos = 0;
	public bool tocando = false;
	private int diferenciaPosition;
	private float tiempo;
	private bool clipRoto = false;
	private Vector3 defaultClipPos;

	public bool stopMoveDest = false;
	public bool stopMoveClip1 = false;
	public bool stopMoveClip2 = false;

	[SerializeField] private List<GameObject> listStopDest;

	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		defaultPos = objAll.transform.rotation;
		correctPosition = AleatorioCerradura.correctPos;
		for (int i = 0; i < listStopDest.Count; i++)
			listStopDest [i].SetActive (false);
		defaultClipPos = objClip.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (enableRotation)
			RotateObj ();
		else if(objTag == "destornillador"){
			objAll.transform.rotation = Quaternion.Lerp (objAll.transform.rotation, defaultPos, Time.deltaTime * speed);
			objClip.transform.position = defaultClipPos;
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
		if (Input.GetMouseButtonDown (0)) {
			f_difX = 0.0f;
			diferenciaPosition = (listStopDest.Count-1) - Mathf.Abs (numPos - correctPosition);
			if (objTag == "destornillador") {
				listStopDest [diferenciaPosition].SetActive (true);
			}
		}
		else if (Input.GetMouseButton (0)) {
			f_difX = Mathf.Abs (f_lastX - Input.GetAxis ("Mouse X")) * speedRotation;

			if (f_lastX > Input.GetAxis ("Mouse X")) {
				if (objTag == "destornillador" && !stopMoveDest) {
					objToRotate.transform.Rotate (Vector3.forward, f_difX);
				}
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

			if (stopMoveDest && !clipRoto) {
				if (diferenciaPosition == 5) {
					Debug.Log ("Correcto");
					StartCoroutine (ShowCorrectText ());
				}
				else {
					if (tiempo > 0.4f) {
						RomperClip ();
					}
					else {
						if(tiempo == 0.0f)
							Shake (0.4f);
						tiempo += Time.deltaTime;
					}
				}
			}
		}
		else if(Input.GetMouseButtonUp(0)) {
			tiempo = 0.0f;
			StartCoroutine (DisableStopDest ());
			if (clipRoto) {
				clipRoto = false;
				if(this.GetComponent<RestarVidas> ().vidas > 0)
					objClip.SetActive (true);
			}
		}
			
	}

	void RomperClip(){
		clipRoto = true;
		objClip.SetActive (false);
		this.GetComponent<RestarVidas> ().Resta ();

		if (this.GetComponent<RestarVidas> ().vidas > 0)
			StartCoroutine (ShowWrongText ());
		else
			StartCoroutine (ShowNoVidasText ());
	}

	void Shake(float seconds) {
		iTween.ShakePosition (objClip, new Vector3 (0.1f, 0.1f, 0.0f), seconds);
	}

	public void TocaPosition(string namePosition){
		if (!listStopDest [diferenciaPosition].activeSelf) {
			numPos = int.Parse (namePosition [10].ToString ());
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

	IEnumerator DisableStopDest(){
		yield return new WaitForSeconds (0.5f);
		stopMoveDest = false;
		enableRotation = false;
		listStopDest [diferenciaPosition].SetActive (false);
	}
}