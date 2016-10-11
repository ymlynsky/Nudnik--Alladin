using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinRotation : MonoBehaviour {
	
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "Item" || col.tag == "coin"){
			  col.GetComponent<Animation>().Play ();
		}
	}
	
}
