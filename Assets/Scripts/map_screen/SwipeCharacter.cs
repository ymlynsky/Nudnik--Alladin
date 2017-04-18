using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCharacter : MonoBehaviour {

	private Ray blockSwipeColliderRay;


	public float DistSwipe = 2.5f;

	void Start (){
		blockSwipeColliderRay = new Ray ();
	}

	void Update () {
		
		RaycastHit leftRaycastHit;
		blockSwipeColliderRay.direction = Vector3.left;
		if (Physics.Raycast (blockSwipeColliderRay, out leftRaycastHit, 0.20F)) {

			if (leftRaycastHit.collider) {
				//sw += DistSwipe;
				Debug.Log("Swipe value: " + DistSwipe);
			}

		}
	}
}
