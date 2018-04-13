using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleIAGirar : MonoBehaviour {

	public static List<string> listComandos;
	private List<int> listUserOrder;
	private List<int> listCorrectOrder;

	void Start(){
		listComandos = new List<string> ();
		listUserOrder = new List<string> ();

		/* 0 */ listComandos.Add ("cd [IA_system]");
		/* 1 */ listComandos.Add ("ls -lh");
		/* 2 */ listComandos.Add ("sudo[hack]");
		/* 3 */ listComandos.Add ("[worm] &");
		/* 4 */ listComandos.Add ("![value]");
		/* 5 */ listComandos.Add ("cat");
		/* 6 */ listComandos.Add ("rm -R [user_data]");
		/* 7 */ listComandos.Add ("rm -f [IA_user_data]");
		/* 8 */ listComandos.Add ("[command] > [user_ID]");
		/* 9 */ listComandos.Add ("mkdir -p [/system_data] / [/system_user]");
		/* 10 */ listComandos.Add ("grep -r [user_ID] [/users]");
		/* 11 */ listComandos.Add ("pbcopy < [user_ID]");
		/* 12 */ listComandos.Add ("pbpaste");
		/* 13 */ listComandos.Add ("Ctrl+C");
		/* 14 */ listComandos.Add ("[start hack] || [force start hack]");
		/* 15 */ listComandos.Add ("open [/IA_system_data]");
		/* 16 */ listComandos.Add ("top");
		/* 17 */ listComandos.Add ("mdfind [IA_user_data]");
		/* 18 */ listComandos.Add ("reset");
		/* 19 */ listComandos.Add ("mv[user] [user_ID]");

		ButtonListComandos.ready = true;
	}

	void Update(){
		
	}

	public void PressButton(){
		/*string buttonCommand = 

		int index = allBaterias.FindIndex(a => a.gameObject == obj);*/
	}

	public void ResetList(){
		listUserOrder.Clear ();
	}

	public void CheckAnswer(){

	}
}