using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayLetterInCanvas : MonoBehaviour {

	public Image placeholder;
	public Sprite[] images;

	private int currentLevel;

	// Use this for initialization
	void Start () {
		currentLevel = LetterCountController.countValue;
	}
	
	// Update is called once per frame
	void Update () {
		//if(currentLevel != LetterCountController.countValue){
		if(placeholder != null && images.Length > 0){
			placeholder.sprite = images[LetterCountController.countValue];
		}
		//}
	}
}
