using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Matching : MonoBehaviour {

	public Button[] cardBack;		// Standard state
	public GameObject[] cardFront;		// Character side
	public GameObject matchText;

	bool[] matched = new bool[12]; // Keeps track of cards that have been matched

	public GameObject scoreCanvas;
	private int score = 0;
	public Text scoreText;
	private float timeLeft = 15.0f; // Game time in seconds
	public Text timeDisp;
	private bool gameOver = false;	// All matches found or time up
	System.Random rnd = new System.Random();

	private List<int> clickedIdx = new List<int>();

	public GameObject home;

	public ItemManager ItemManager;


	void Start() {
		int[] numbers = new [] { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6 };

		scoreCanvas.SetActive (false);
		matchText.SetActive (false);
		home.SetActive (false);

		// Add button event listeners
		for (int i = 0; i < cardBack.Length; i++) {
			int closureIndex = i;
			cardBack[i] = cardBack[i].GetComponent<Button> ();
			cardBack[closureIndex].onClick.AddListener(() => btnClick(closureIndex));
		}

		for (int i = 0; i < cardFront.Length; i++) {
			cardFront [i].SetActive (false);
		}
			

		// Set all matched to false
		for (int i = 0; i < matched.Length; i++)
			matched[i] = false;
	}

	void Update() {
		if (clickedIdx.Count == 2) {
			if (clickedIdx [0] % 6 == clickedIdx [1] % 6)
				match (clickedIdx [0], clickedIdx [1]);
			else {
				StartCoroutine (pause ());
				cardFront [clickedIdx [0]].SetActive (false);
				cardFront [clickedIdx [1]].SetActive (false);
			}
				
				
			clickedIdx.Clear();
		}

		if (allFound() == true)
			gameOver = true;
		
		// Timer
		timeLeft -= Time.deltaTime;
		timeDisp.text = timeLeft.ToString ();
		if ( timeLeft < 0 )
		{
			gameOver = true;
			timeDisp.text = "0";
		}

		if (scoreText == null) {
			Debug.Log ("ERR: scoreText set to null");
			Debug.Break ();
		}

		// End of game routine to show score
		if (gameOver) {
			Debug.Log ("Score is " + score);
			scoreCanvas.SetActive (true);
			scoreText.text = score.ToString ();
			home.SetActive (true);
			ItemManager.neurobucks += score;
		}
	}

	// Record card number when clicked TODO: Flip card over!
	public void btnClick(int buttonNum) {
		clickedIdx.Add(buttonNum);
		cardFront[buttonNum].SetActive(true);
		Debug.Log ("card number: " + buttonNum);
	}

	// Remove cards & add to score
	public void match(int idx1, int idx2) {
		Debug.Log ("Match!");
		matchText.SetActive (true);
		score += 10;
		matched [idx1] = true;
		matched [idx2] = true;
		Debug.Log (idx1);
		Debug.Log(idx2);
	}

	// TODO: Flip cards back over
	public void noMatch () {
		matchText.SetActive (false);
	}

	// Pause after 1 cards flipped
	IEnumerator pause() {
		yield return new WaitForSeconds (1);
		Debug.Log ("pausing...");
		noMatch ();
	}

	//All matches found
	bool allFound() {
		for (int i = 0; i < matched.Length; i++)
			if (matched[i] == false)
				return false;
		return true;
	}
}