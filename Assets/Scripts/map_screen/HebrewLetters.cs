using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HebrewLetters : MonoBehaviour
{

	private GameObject[] textObjectsWithTag;
	private List<GameObject> gameObjectList;
	public GameObject pinPointPrefab;
	private GameObject pinPointBullet;
	public Sprite activeBullet;
	public Sprite inactiveBullet;
	private Animator pinPointAnimator;
	private bool levelSelected=false;
	private bool pinPointSeted=false;
	private string level;
	// Use this for initialization
	void Start ()
	{
		gameObjectList = new List<GameObject>();
		//string[] hebrewLettersArray = new string[] {"א","בּ","ב","ג","ד","ה","ו‎","ז","ח","ט","י","כּ","כ","ךּ‎","ך","ל","מ","ם","ן","ס","ע","פּ","פ","ף‎","צ‎","ץ‎","ק‎","ר‎","שׁ","שׂ","תּ","ת"};
		char[] hebrewCharLettersArray = new char[]	{'\u05D0','\uFB31','\u05D1','\u05D2','\u05D3','\u05D4','\u05D5',
													'\u05D6','\u05D7','\u05D8','\u05D9','\uFB3B','\u05DB','\u05DA',
													'\u05DC','\u05DE','\u05DD','\u05E0','\u05DF','\u05E1','\u05E2',
													'\uFB44','\u05E4','\u05E3','\u05E6','\u05E5','\u05E7','\u05E8',
													'\uFB2A','\uFB2B','\uFB4A','\u05EA'};
	
		gameObjectList.AddRange(GameObject.FindGameObjectsWithTag ("map_letter_tag"));
		gameObjectList.Sort(SortByName);

		int currentLevel = PlayerPrefs.GetInt ("level",0);

		//if (textObjectsWithTag.Length == hebrewLettersArray.Length) {
			for (int i = 0; i < hebrewCharLettersArray.Length; i++) {
				gameObjectList[i].GetComponent<Text> ().text = ""+hebrewCharLettersArray[i];
			Image bulletSprite= gameObjectList [i].transform.parent.gameObject.GetComponent<Image> ();
			if (i <= currentLevel) {
				bulletSprite.sprite = activeBullet;
			} else {
				bulletSprite.sprite = inactiveBullet;
			}
			}
		//}
	}

	private static int SortByName(GameObject o1, GameObject o2) {
     	return o1.name.CompareTo(o2.name);
 	}
	// Update is called once per frame
	void Update ()
	{
		if (!pinPointSeted) {
			GameObject bullet = GameObject.FindWithTag (PlayerPrefs.GetInt("level",0).ToString());
			pinPointBullet = Instantiate (pinPointPrefab,bullet.transform.parent.transform) as GameObject;
			pinPointAnimator = pinPointBullet.GetComponent<Animator> ();
			Vector3 bulletPosition = new Vector3 (bullet.transform.position.x, bullet.transform.position.y + (((RectTransform)bullet.transform).rect.height)+20f, bullet.transform.position.z);
			pinPointBullet.transform.position = bulletPosition;
			pinPointSeted = true;
		}
	}

	public void begginGame(GameObject bullet){
		int currentLevel = PlayerPrefs.GetInt ("level", 0);
		if (!levelSelected && Int32.Parse(bullet.tag)<=currentLevel) {
			Vector3 bulletPosition = new Vector3 (bullet.transform.position.x, bullet.transform.position.y + (((RectTransform)bullet.transform).rect.height)+50f, bullet.transform.position.z);
			pinPointBullet.transform.SetParent (bullet.transform.parent.transform);
			pinPointBullet.transform.position = bulletPosition;
			StartCoroutine (showTransition ());
			levelSelected = true;
			PlayerPrefs.SetInt("level", Int32.Parse(bullet.tag));
		}
	}

	IEnumerator showTransition(){

		pinPointAnimator.SetBool ("pinPointBool", true);

		yield return new WaitForSeconds (0.3f);

		Application.LoadLevel (2);
	}
		
}
