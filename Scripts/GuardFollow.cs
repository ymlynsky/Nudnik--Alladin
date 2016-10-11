using UnityEngine;
using System.Collections;

public class GuardFollow : MonoBehaviour {
	
	public Transform target; 
	private float angle = 0; 
	public float distance = -4; 
	private float height = 0F; 
	private float timer;
	public GameObject anim;
	public AudioSource asr;
	
	private Vector3 posCamera;
	private Vector3 angleCam;
	private bool shake,xx,yy;
	public static GuardFollow instace;

	void Start(){
		instace = this;
	}

	void Update (){

			if (yy == false) {
			if(PauseMenu.Pause == false){
				anim.GetComponent<Animation>().enabled = true;
				this.GetComponent<Rigidbody>().isKinematic=false;
				if (xx == true) {
					timer += Time.deltaTime;
					if (timer >= 5) {
						timer = 0;
						asr.enabled=false;
						anim.GetComponent<Animation> ()["guardRun"].speed = 1.35F;
						anim.GetComponent<Animation> ().Play ("guardRun");
						xx = false;
					}
				}
				}
				else if(PauseMenu.Pause == true && Controller.die == false){
					anim.GetComponent<Animation>().enabled = false;
					this.GetComponent<Rigidbody>().isKinematic=true;
				}
				if (Controller.die == true && Controller.jPuck == false) {
					asr.enabled=false;
					distance = Mathf.Lerp (transform.position.z, 3.6F, Generation.speed / 2 * Time.deltaTime);
					posCamera.x = target.position.x - 0.3F;
					if (Controller.guardGo == true && Controller.jPuck == false) {
						anim.GetComponent<Animation> ().Play ("killAladdinGuard2");
						yy = true;
					} else {
						anim.GetComponent<Animation> ().Play ("killAladdinGuard");
						yy = false;
					}
				}
				
				if (Controller.guardGo == true && Controller.jPuck==false) {
					GuardGo ();
				}
			}
	}

	void GuardGo(){
		xx = true;
		distance = Mathf.Lerp (transform.position.z, 2.5f, Generation.speed * Time.deltaTime);	
}

	void LateUpdate(){
		if(target != null){
			if(target.position.z >= 0){
				if(shake == false){
					if(Controller.die==false)
					posCamera.x = Mathf.Lerp(posCamera.x, target.position.x, Generation.speed* 2 * Time.deltaTime);
					posCamera.y = Mathf.Lerp(posCamera.y, target.position.y + height, 3 * Time.deltaTime);
					posCamera.z = Mathf.Lerp(posCamera.z, target.position.z + distance, Generation.speed); 
					transform.position = posCamera;
					angleCam.x = angle;
					angleCam.y = Mathf.Lerp(angleCam.y, 0, 1 * Time.deltaTime);
					angleCam.z = transform.eulerAngles.z;
					transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, angleCam, 1 * Time.deltaTime);
				}
			}else{

					Vector3 dummy = Vector3.zero;
					posCamera.x = Mathf.Lerp(posCamera.x, 0, 5 * Time.deltaTime);
					posCamera.y = Mathf.Lerp(posCamera.y, dummy.y + height, 5 * Time.deltaTime);
					posCamera.z = dummy.z + distance;
					transform.position = posCamera;
					angleCam.x = angle;
					angleCam.y = transform.eulerAngles.y;
					angleCam.z = transform.eulerAngles.z;
					transform.eulerAngles = angleCam;

			}
		}
	}
	
	public void Reset(){
		shake = false;
		Vector3 dummy = Vector3.zero;
		posCamera.x = 0;
		posCamera.y = dummy.y + height;
		posCamera.z = dummy.z + distance;
		transform.position = posCamera;
		angleCam.x = angle;
		angleCam.y = transform.eulerAngles.y;
		angleCam.z = transform.eulerAngles.z;
		transform.eulerAngles = angleCam;
	}
	
	public void ActiveShake(){
		shake = true;
		StartCoroutine(ShakeCamera());	
	}
	
	IEnumerator ShakeCamera(){
		float count = 0;
		Vector3 pos = Vector3.zero;;
		while(count <= 0.2f){
			count += 1 * Time.smoothDeltaTime;	
			pos.x = transform.position.x + Random.Range(-0.05f,0.05f);
			pos.y = target.position.y + height + Random.Range(-0.05f,0.05f);
			pos.z = target.position.z + distance;
			transform.position = pos;
			yield return 0;
		}
		transform.position = posCamera;
		posCamera.x = transform.position.x;
		posCamera.y = target.position.y + height;
		posCamera.z = target.position.z + distance;
		transform.position = posCamera;
		angleCam.x = angle;
		angleCam.y = transform.eulerAngles.y;
		angleCam.z = transform.eulerAngles.z;
		transform.eulerAngles = angleCam;
		shake = false;
	}
	
}
