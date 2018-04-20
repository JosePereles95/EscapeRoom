using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleCerradura : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	private Quaternion defaultPos;

	[SerializeField] private GameObject objAll;
	[SerializeField] private GameObject objClip;
	[SerializeField] private GameObject objClipRoto;

	private GameObject objToRotate;
	private string objTag;
	private float speed = 8.0f;

	[SerializeField] private int correctPosition;
	private int numPos = 0;
	public bool tocando = false;
	private int diferenciaPosition;
	private float tiempo;
	private bool clipRoto = false;
	private bool parado = false;
	private Vector3 defaultClipPos;
	private float sliderDestValue = 0.0f;
	private float sliderDestStop = 0.0f;
	private float sliderClipValue = 0.0f;

	public bool stopMoveDest = false;
	public bool stopMoveClip1 = false;
	public bool stopMoveClip2 = false;

	[SerializeField] private List<GameObject> listStopDest;

	[SerializeField] private Slider sliderDest;
	[SerializeField] private Slider sliderClip;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
		defaultPos = objAll.transform.rotation;
		correctPosition = AleatorioCerradura.correctPos;
		for (int i = 0; i < listStopDest.Count; i++)
			listStopDest [i].SetActive (false);
		defaultClipPos = objClip.transform.position;
	}
		
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			parado = false;
			diferenciaPosition = (listStopDest.Count - 1) - Mathf.Abs (numPos - correctPosition);
			sliderDestStop = (float) diferenciaPosition / (float) (listStopDest.Count - 1);
		}
		else if (Input.GetMouseButton (0)) {
			if (parado && !clipRoto) {
				if (diferenciaPosition == 5) {
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
		else {
			objAll.transform.rotation = Quaternion.Lerp (objAll.transform.rotation, defaultPos, Time.deltaTime * speed);

			sliderDest.value = Mathf.Lerp (sliderDest.value, 0.0f, Time.deltaTime * speed);

			tiempo = 0.0f;
			if (clipRoto) {
				clipRoto = false;
				parado = false;
				if (this.GetComponent<RestarVidas> ().vidas > 0) {
					objClipRoto.SetActive (false);
					objClip.SetActive (true);
					objClip.transform.position = defaultClipPos;
				}
			}
		}
	}

	public void RotateDest(){
		
		if (!(sliderDest.value >= sliderDestStop)) {
			sliderDestValue = sliderDest.value;
			objAll.transform.rotation = Quaternion.Euler (180, 0, 180 + sliderDestValue * 90);
		}
		else {
			parado = true;
			sliderDest.value = sliderDestValue;
		}
	}

	public void RotateClip(){

		sliderClipValue = sliderClip.value;
		objClip.transform.rotation = Quaternion.Euler (0, 180, sliderClipValue);
	}

	void RomperClip(){
		clipRoto = true;
		objClipRoto.SetActive (true);
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
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}

	IEnumerator ShowNoVidasText(){
		noVidasText.gameObject.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		WindowsManager.penalized = true;
		Timer.ChangeCanvas (false);
		SceneManager.LoadScene ("Vuforia");
	}
}