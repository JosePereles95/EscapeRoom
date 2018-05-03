using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioIAWords : MonoBehaviour {

	private string letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

	public static List<string> listWords;
	public static List<int> listNums;
	public static List<int> listPositions;
	public static bool ready = false;
	public static List<string> palabrasRandom;

	private int numPalabras = 3;

	void Start () {
		listWords = new List<string> ();
		listNums = new List<int> ();
		listPositions = new List<int> ();

		palabrasRandom = new List<string> ();
		palabrasRandom.Add ("ABILITY");
		palabrasRandom.Add ("ACHIEVE");
		palabrasRandom.Add ("ADVANCE");
		palabrasRandom.Add ("AGAINST");
		palabrasRandom.Add ("BALANCE");
		palabrasRandom.Add ("BELIEVE");
		palabrasRandom.Add ("CLOSURE");
		palabrasRandom.Add ("COMMAND");
		palabrasRandom.Add ("COMPACT");
		palabrasRandom.Add ("CONNECT");
		palabrasRandom.Add ("CONTROL");
		palabrasRandom.Add ("COUNTER");
		palabrasRandom.Add ("DEFENCE");
		palabrasRandom.Add ("DIGITAL");
		palabrasRandom.Add ("DISPLAY");
		palabrasRandom.Add ("DIVIDED");
		palabrasRandom.Add ("ENHANCE");
		palabrasRandom.Add ("EXAMPLE");
		palabrasRandom.Add ("FAILING");
		palabrasRandom.Add ("FAILURE");
		palabrasRandom.Add ("FORWARD");
		palabrasRandom.Add ("FREEDOM");
		palabrasRandom.Add ("GATEWAY");
		palabrasRandom.Add ("GIGABIT");
		palabrasRandom.Add ("HELPFUL");
		palabrasRandom.Add ("IMPROVE");
		palabrasRandom.Add ("INVOLVE");
		palabrasRandom.Add ("JUSTICE");
		palabrasRandom.Add ("LIBERTY");
		palabrasRandom.Add ("LICENSE");
		palabrasRandom.Add ("LOGICAL");
		palabrasRandom.Add ("MACHINE");
		palabrasRandom.Add ("MISSING");
		palabrasRandom.Add ("MISSION");
		palabrasRandom.Add ("MYSTERY");
		palabrasRandom.Add ("NETWORK");
		palabrasRandom.Add ("OPERATE");
		palabrasRandom.Add ("OUTCOME");
		palabrasRandom.Add ("PATTERN");
		palabrasRandom.Add ("PERFECT");
		palabrasRandom.Add ("PERFORM");
		palabrasRandom.Add ("PREDICT");
		palabrasRandom.Add ("PRECISE");
		palabrasRandom.Add ("PROBLEM");
		palabrasRandom.Add ("PROGRAM");
		palabrasRandom.Add ("PROJECT");
		palabrasRandom.Add ("PROTECT");
		palabrasRandom.Add ("PURPOSE");
		palabrasRandom.Add ("REALITY");
		palabrasRandom.Add ("RECOVER");
		palabrasRandom.Add ("RELEASE");
		palabrasRandom.Add ("REMOVAL");
		palabrasRandom.Add ("REMOVED");
		palabrasRandom.Add ("RESTORE");
		palabrasRandom.Add ("SCIENCE");
		palabrasRandom.Add ("SEGMENT");
		palabrasRandom.Add ("SETTING");
		palabrasRandom.Add ("SOCIETY");
		palabrasRandom.Add ("STORAGE");
		palabrasRandom.Add ("SUCCEED");
		palabrasRandom.Add ("SUCCESS");
		palabrasRandom.Add ("SUPPORT");
		palabrasRandom.Add ("SURVIVE");
		palabrasRandom.Add ("TOWARDS");
		palabrasRandom.Add ("UPGRADE");
		palabrasRandom.Add ("VICTORY");
		palabrasRandom.Add ("VIRTUAL");
		palabrasRandom.Add ("WARFARE");
		palabrasRandom.Add ("WELFARE");
		palabrasRandom.Add ("WINNING");
		palabrasRandom.Add ("WITHOUT");
		palabrasRandom.Add ("UNKNOWN");

		for (int i = 0; i < numPalabras; i++) {
			listPositions.Add (Random.Range (0, palabrasRandom.Count));
			listNums.Add (Random.Range (3, 9));

			int charAmount = 7;
			if (i % 2 == 0) {
				string cadena = "";
				for (int j = 0; j < charAmount; j++) {
					int pos = letras.IndexOf(palabrasRandom[listPositions[i]][j]) - listNums[i];
					if (pos < 0)
						pos += 27;
					cadena += letras[pos].ToString();
				}
				listWords.Add (cadena);
			}
			else {
				string cadena = "";
				for (int j = 0; j < charAmount; j++) {
					int pos = letras.IndexOf(palabrasRandom[listPositions[i]][j]) + listNums[i];
					if (pos > 26)
						pos -= 27;
					cadena += letras[pos].ToString();
				}
				listWords.Add (cadena);
			}
		}

		ready = true;
	}

	void Update () {
		
	}
}
