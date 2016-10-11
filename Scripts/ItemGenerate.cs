using UnityEngine;
using System.Collections;

public class ItemGenerate : MonoBehaviour {
	[Header("Варианты генерируемых препядствий:")]
	public GameObject ItemCase1;
	public GameObject ItemCase2;
	public GameObject ItemCase3;
	bool n;


	void Awake(){
		ItemCase1.SetActive (false);
		ItemCase2.SetActive (false);
		ItemCase3.SetActive (false);
		n = Generation.isStart;
	}

	void Start(){
		if (!n) {
			int CaseNum = UnityEngine.Random.Range (1, 10);
			if (CaseNum == 1 || CaseNum == 5 || CaseNum == 7 || CaseNum == 9)
					ItemCase1.SetActive (true);
			if (CaseNum == 2 || CaseNum == 8 || CaseNum == 10)
					ItemCase2.SetActive (true);
			if (CaseNum == 4 || CaseNum == 3 || CaseNum == 6)
					ItemCase3.SetActive (true);
		}
		
	}
}
