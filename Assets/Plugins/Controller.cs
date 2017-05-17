using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public int questNPC;
	public GameObject gameController;
	private Controller controller;

	public int coinAmount = 0;
	public int woodAmount = 0;

	public int CurrentQuest = 0;

	// Use this for initialization
	void Start () {

	}

	public int IncrementCoinAmount(){
		Debug.Log (coinAmount);
		coinAmount += 1;
		return coinAmount;
	}

	// Update is called once per frame
	void Update () {

	}
}
