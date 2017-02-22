using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	public GameObject AudioController;
	public AudioClip[] way;
	public AudioClip[] wood;
	public AudioClip[] material;

	private float runSpeed;
	private string curMat;
	private bool crouch;
	private bool steps = true;
	
	void Update(){
		runSpeed = Generation.speed;
		crouch = Controller.crouch;

		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 10)) {
			curMat = hit.collider.transform.tag;
		}

		if (Controller.isGround && crouch == false && steps == true && Controller.die == false) {
			if (curMat == "ground"){
				StartCoroutine(Run(way));
			}
			if (curMat == "jumper"){
				StartCoroutine(Run(wood));
			}
			if (curMat == "blocks"){
				StartCoroutine(Run(material));
			}	
		}

	}

	IEnumerator Run(AudioClip[] name) {
		steps = false;
		AudioController.GetComponent<AudioSource>().clip = name[Random.Range(0, name.Length)];
		AudioController.GetComponent<AudioSource>().volume = UnityEngine.Random.Range (0.95F,1F);
		AudioController.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2.2F/runSpeed);
		steps = true;
	}
}
