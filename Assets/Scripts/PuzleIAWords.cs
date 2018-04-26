using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Vuforia;

public class PuzleIAWords : MonoBehaviour {

	[SerializeField] private Text correctText;
	[SerializeField] private Text wrongText;
	[SerializeField] private Text noVidasText;

	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
	}

	void Update () {
		
	}
}