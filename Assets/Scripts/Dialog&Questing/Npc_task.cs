using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_task : MonoBehaviour {
	public GameObject gameController;
	private Controller controller;

	public string[] Introduction;
	public string Introduction_Answer;
	public string[] Questions;
	public string[] Questions_Answers;
	public string[] Closing_Statement;
	public string Closing_Statement_Answer;

	private string str = "";

	private bool DisplayDialog = false;
	private bool ActivateQuest = false;
	private bool FirstTime = true;

	public GameObject Player;
	private WorldInteraction movement;


	private int goalAmount = 20;
	private bool goal = false;
	public int NPC_ID;

	public GameObject coins;	
	public GameObject wood;
	public GameObject axe;
	public GameObject helmet;

	// Use this for initialization
	void Start () {

		movement = Player.GetComponent<WorldInteraction> ();
		controller = gameController.GetComponent<Controller> ();

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
		GUILayout.BeginArea(new Rect(700,400, 400, 400));

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

			GUILayout.Label (Questions [1]);

			str = GUILayout.TextField (str , 25);



			if (GUILayout.Button (Questions_Answers[0])) {

				if (str.ToString() == "4") {
					wood.SetActive (true);
					controller.woodAmount = 1;
					HideWindow ();
				} else {
				
					str = "Prøv igen";
				
				}

			}
				
		}
		if (DisplayDialog && ActivateQuest && !goal) {


			//InputField input = GUI.TextArea ();
			if (GUILayout.Button (Questions_Answers [2])) {
				//if(
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
		switch (NPC_ID) {
		case(1):
			if (controller.coinAmount >= goalAmount) {

				goal = true;

			}
			break;
		case(2):
			//Debug.Log (this.name);
			if (controller.woodAmount == 1) {

				goal = true;

			}
			break;
		case(3):

			break;

		}
	}
}
