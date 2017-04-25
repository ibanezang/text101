using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	public Text text;

	private enum GameStates
	{
		cell,
		sheets_0,
		mirror,
		lock_0,
		cell_mirror,
		sheets_1,
		lock_1,
		freedom
	};

	private GameStates currentState;

	// Use this for initialization
	void Start () {
		currentState = GameStates.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (currentState);
		if (currentState == GameStates.cell) 			{state_cell();}
		else if (currentState == GameStates.sheets_0) 	{state_sheets_0();}
		else if (currentState == GameStates.sheets_1) 	{state_sheets_1();}
		else if (currentState == GameStates.lock_0) 		{state_lock_0();}
		else if (currentState == GameStates.lock_1) 		{state_lock_1();}
		else if (currentState == GameStates.mirror) 		{state_mirror();}
		else if (currentState == GameStates.cell_mirror) {state_cell_mirror();}
		else if (currentState == GameStates.freedom) 	{state_freedom();}
	}

	void state_cell(){
		text.text = "You are in a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door " +
			"is locked from the outside\n\n" +
			"Press S to view Sheets, M to view Mirror, L to view Lock.";

		if(Input.GetKeyDown(KeyCode.S)){
			currentState = GameStates.sheets_0;
		}
		if(Input.GetKeyDown(KeyCode.M)){
			currentState = GameStates.mirror;
		}
		if(Input.GetKeyDown(KeyCode.L)){
			currentState = GameStates.lock_0;
		}
	}

	void state_sheets_0(){
		text.text = "You can't believe you sleep in these thing! Surely it's " +
			"time somebody changed them. The pleasure of prison life " +
			"I guess!\n\n" +
			"Press R to Return to roaming Cell.";

		if(Input.GetKeyDown(KeyCode.R)){
			currentState = GameStates.cell;
		}
	}

	void state_mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell" ;
		if (Input.GetKeyDown(KeyCode.T)) 		{currentState = GameStates.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{currentState = GameStates.cell;}
	}

	void state_cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock";
		if (Input.GetKeyDown (KeyCode.S)) {
			currentState = GameStates.sheets_1;
		} else if (Input.GetKeyDown (KeyCode.L)) {
			currentState = GameStates.lock_1;
		}
	}

	void state_lock_0(){
		text.text = "This is one of those button locks. You have the idea what the " +
					"combination  is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming Cell.";

		if(Input.GetKeyDown(KeyCode.R)){
			currentState = GameStates.cell;
		}
	}

	void state_sheets_1(){
		text.text = "Holding a mirror in your hand doesn't make the sheets look "+
					"any better.\n\n" +
					"Press R to Return to roaming you cell";
		if(Input.GetKeyDown(KeyCode.R)){
			currentState = GameStates.cell_mirror;
		}
	}

	void state_lock_1(){
		text.text = "You carefully put the mirror through the bars and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press 0 to Open, or R to Return to your Cell.";

		if(Input.GetKeyDown(KeyCode.Alpha0)){
			currentState = GameStates.freedom;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			currentState = GameStates.cell_mirror;
		}
	}

	void state_freedom() {
		text.text = "You are FREE!\n\n" +
			"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) 		{currentState = GameStates.cell;}
	}
}
