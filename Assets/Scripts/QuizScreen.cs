using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScreen : MonoBehaviour {

	public static bool isQuizTime=false;
	public GameObject firstCoin;
	public GameObject secondCoin;
	public GameObject thirdCoin;
	public GameObject quizzPanel;
	public Animator firstCoinAnimator;
	public Animator secondCoinAnimator;
	public Animator thirdCoinAnimator;
	public Camera cameraGameObject;

	private char correctLetter;
	private int correctPosition;
	private List<char> letters;

	char[] hebrewCharLettersArray = new char[]	{'\u05D0','\uFB31','\u05D1','\u05D2','\u05D3','\u05D4','\u05D5',
		'\u05D6','\u05D7','\u05D8','\u05D9','\uFB3B','\u05DB','\u05DA',
		'\u05DC','\u05DE','\u05DD','\u05E0','\u05DF','\u05E1','\u05E2',
		'\uFB44','\u05E4','\u05E3','\u05E6','\u05E5','\u05E7','\u05E8',
		'\uFB2A','\uFB2B','\uFB4A','\u05EA'};


	// Use this for initialization
	void Start () {
		isQuizTime = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (isQuizTime) {
			quizzPanel.SetActive (true);
			StartCoroutine (coinEntrance ());


		}
			
	}

	IEnumerator coinEntrance(){

		firstCoinAnimator.SetTrigger ("Appear");
		firstCoin.SetActive (true);

		yield return new WaitForSeconds (0.2f);

		secondCoinAnimator.SetTrigger ("Appear");
		secondCoin.SetActive (true);

		yield return new WaitForSeconds (0.2f);

		thirdCoinAnimator.SetTrigger ("Appear");
		thirdCoin.SetActive (true);


	}

	public void selectCoin(GameObject coin){

		if (coin.tag.Equals(correctPosition.ToString())) {
			coin.GetComponent<Animator> ().SetTrigger ("isCorrect");
			if(!coin.Equals(firstCoin))

				firstCoin.GetComponent<Animator> ().SetTrigger ("Disappear");

			if(!coin.Equals(secondCoin))
				secondCoin.GetComponent<Animator> ().SetTrigger ("Disappear");

			if(!coin.Equals(thirdCoin))
				thirdCoin.GetComponent<Animator> ().SetTrigger ("Disappear");
		} else {
			coin.GetComponent<Animator> ().SetTrigger ("isWrong");
			if(!coin.Equals(firstCoin))
				firstCoin.GetComponent<Animator> ().SetTrigger ("FadeDown");

			if(!coin.Equals(secondCoin))
				secondCoin.GetComponent<Animator> ().SetTrigger ("FadeDown");

			if(!coin.Equals(thirdCoin))
				thirdCoin.GetComponent<Animator> ().SetTrigger ("FadeDown");
			
			generateQuestion ();
		}

	}

	private void generateQuestion(){

		letters = new List<char> ();
		int level = PlayerPrefs.GetInt ("level");
		correctLetter = hebrewCharLettersArray [level];
		letters.Add (correctLetter);
		int x;
		while ((x = Random.Range (0, hebrewCharLettersArray.Length)) == level)
			;
		
		while ((x = Random.Range (0, hebrewCharLettersArray.Length)) == level)
			;
		letters.Add (hebrewCharLettersArray [x]);

		Shuffle ();

		for (int i = 0; i < letters.Count; i++) {
			if (letters [i].Equals (correctLetter))
				correctPosition = i;
		}
	
	}

	private void Shuffle(){

		int n = letters.Count;
		while (n > 1) {
			n--;
			int k = Random.Range (0, n + 1);
			char value = letters[k];
			letters [k] = letters [n];
			letters [n] = value;
		}
	}
}
