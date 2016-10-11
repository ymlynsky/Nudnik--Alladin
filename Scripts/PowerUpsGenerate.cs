using UnityEngine;
using System.Collections;

public class PowerUpsGenerate : MonoBehaviour {
	
	public GameObject[] PowerUps;
	bool start,inst;

	void Awake(){
		start = Generation.isStart;
	}

	void Start () {
		int num = UnityEngine.Random.Range (0, 4);
		if (num == 2) {
			inst = true;	
		} else {
			inst = false;	
		}
		if (!start && inst == true) {
			PowerUps[UnityEngine.Random.Range (0,PowerUps.Length)].SetActive(true);
		}
	}

}
