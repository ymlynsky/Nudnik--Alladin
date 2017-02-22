using UnityEngine;
using System.Collections;

public class BollAnim : MonoBehaviour {
	public GameObject obj;

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Collider>().tag == "Player") {
			obj.GetComponent<Animation>().Play ("bochki");
		}
	}
}
