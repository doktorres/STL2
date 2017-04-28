using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Dialog : MonoBehaviour {
	public string[] Introduction;
	public string Introduction_Answer;
	public string[] Questions;
	public string[] Questions_Answers;
	public string[] Closing_Statement;
	public string Closing_Statement_Answer;

	private bool DisplayDialog = false;
	private bool ActivateQuest = false;
	private bool FirstTime = true;

	public GameObject Player;
	private WorldInteraction movement;
	public int numberOfQuests;

	public int coinAmount = 0;

	private int goalAmount = 100;
	private bool goal = false;



	// Use this for initialization
	void Start () {
		movement = Player.GetComponent<WorldInteraction> ();
	}

	public void HideWindow (){

		DisplayDialog = false;

		movement.enabled = true;
	
	}


	public void ShowWindow (){

		DisplayDialog = true;
		movement.enabled = false;
	
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(700, 600, 400, 400));

		if (DisplayDialog && !ActivateQuest && FirstTime) {

			foreach (string a in Introduction) {

				GUILayout.Label (a);

			}

			if (GUILayout.Button (Introduction_Answer)) {

				FirstTime = false;

			}
		}
		if (DisplayDialog && !ActivateQuest && !FirstTime) {

			GUILayout.Label (Questions[0]);


			if (GUILayout.Button (Questions_Answers[0])) {
				ActivateQuest = true;

				HideWindow ();

			}
			if (GUILayout.Button (Questions_Answers[1])) {

				HideWindow ();

			}
		}
		if (DisplayDialog && ActivateQuest && !goal) {

			GUILayout.Label (Questions [0]);

			if (GUILayout.Button (Questions_Answers [2])) {

				HideWindow ();

			}
		}

		if (DisplayDialog && ActivateQuest && goal) {
			foreach (string a in Closing_Statement) {

				GUILayout.Label (a);

			}
			if (GUILayout.Button (Closing_Statement_Answer)) {

				HideWindow ();

			}

		}
		GUILayout.EndArea();	
	}



	// Update is called once per frame
	void Update () {
		if (coinAmount >= goalAmount) {

			goal = true;

		}
	}
	void OnMouseDown(){
	
		Debug.Log ("hello");
	
	}
}
