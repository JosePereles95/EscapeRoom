﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy instance;

	void Awake () {
		DontDestroyOnLoad (this);

		if (instance == null)
			instance = this;
		else
			DestroyObject (gameObject);
	}
}
