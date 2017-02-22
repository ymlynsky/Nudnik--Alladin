using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	public GameObject magnetAbsorbPos;
	public Transform prefCoinDie;
	public AudioClip coinSound;
	private AudioSource am;

	private bool isLoop;
	private Collider b;

	void Start(){
		am = GameObject.FindGameObjectWithTag ("coinrot").GetComponent<AudioSource> ();
	}

	void OnTriggerStay(Collider cc) {
		if(cc.gameObject.tag == "coin") {
			isLoop = true;	
			b = cc;
			StartCoroutine (Com());

		}
	}
	IEnumerator Com(){
		while(isLoop){
			b.transform.position =  Vector3.Lerp(b.transform.position, magnetAbsorbPos.transform.position,Generation.speed*Time.smoothDeltaTime);
			b.transform.localScale =  Vector3.Lerp(b.transform.localScale, new Vector3(0.25f,0.25f,0.25f),Generation.speed/6*Time.smoothDeltaTime);
			if(Vector3.Distance(b.transform.position, magnetAbsorbPos.transform.position) < 0.65f){
				Controller.coinCount++;
				Instantiate (prefCoinDie, new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.5F), transform.rotation);
				am.clip = coinSound;
				am.Play ();
				Destroy (b.GetComponent<Collider>().gameObject);
				isLoop = false;	
			}
			yield return 0;
		}
	}
	
}
