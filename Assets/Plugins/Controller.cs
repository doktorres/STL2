using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public int questNPC;
	public GameObject gameController;
	private Controller controller;

	public Text CoinText;


	public int coinAmount;
	public int woodAmount = 0;

	public int CurrentQuest = 0;

	// Use this for initialization
	void Start () {
		coinAmount = 0;
		SetCountText ();
	}

	public int IncrementCoinAmount(){
		Debug.Log (coinAmount);
		coinAmount += 1;
		SetCountText ();
		return coinAmount;
	}

	void SetCountText(){
		CoinText.text = "Gold: " + coinAmount.ToString ();
	}
}
