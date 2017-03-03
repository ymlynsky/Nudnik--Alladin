using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AjPlayerController : MonoBehaviour
{

	public Light l1;
	float lt;
	bool narik = false;
	[HideInInspector]
	public bool isRoll, isSlide;
	public static int coinCount = 0;
	public static int coinsAll;
	[Space (10)]
	public bool keyboard;
	private bool coldr = false;
	private int BookCount, MedalCount, DudkaCount, ZmeyCount, VazaCount;
	[Space (10)]
	[Header ("Префабы эффектов разрушения:")]
	public Transform playerDie;
	public Transform prefBoteDie;
	public Transform prefCoinDie;
	public Transform prefx2Die;
	public Transform prefMagnitDie;
	public Transform prefJpuckDie;
	[Header ("Рейкасты игрока:")]
	public Transform raycast;
	public Transform dieRaycastUp;
	public Transform dieRaycastDown;
	private Transform dieRay;
	[Header ("Аудиоклипы различных эффектов:")]
	public AudioClip coinSound;
	public AudioClip boteSound;
	public AudioClip magnetSound;
	public AudioClip jetSound;
	public AudioClip dieSound;
	public AudioClip x2Sound;
	public AudioClip swipeSound;
	public static bool isGround = false;
	public static bool guardGo = false;
	private float sw, timer, timer2, timer3, timer6, timerl, timer8, timerGO, tc;
	public static float timer4, timer5, timer7;
	private bool swiped, rolled, timerG;
	public static bool swiped2;
	public static bool isJump = false;
	[Header ("Время действия бонусов:")]
	public static float BotsTime;
	public static float x2Time;
	public static float MagnetTime;
	public static float jPuckTime;
	[Header ("Настройки игрока:")]
	public float DistSwipe;
	private AnimationManager animationManager;
	private float SwipeTimeLimit = 0.3f;
	private float SwipeTimeLimit2 = 1f;
	private bool betman = false;
	private Collider cc, sc;
	public static bool crouch = false;
	public Vector3 jumpVelocity;
	public static bool stopGame;
	private AudioSource am, bg;
	public AudioSource fs;
	public AudioSource aSource;
	public static bool die;
	private GameObject guarde;
	GameObject pauseButton;
	public static bool jPuck, botOn, x2On, magnetOn;
	[Header ("ВКЛ/ВЫКЛ - одежки и бонусы:")]
	public GameObject magObj;
	public GameObject magObj2;
	public GameObject kover;
	public GameObject botLeft, botRight;
	private bool noNeed = false;
	public static int roundLife = 0;
	public GameObject saveButton;
	public GameObject saveButtonBG;
	public GameObject gameOv;
	private Touch initialTouch = new Touch ();
	private float distance;
	private bool hasSwiped = false;
	public static bool lifesave = false;
	public static bool jumpUP;
	public Texture KoverText1;
	public Texture KoverText2;
	public Texture KoverText3;
	public GameObject koverGo;
	public GameObject coinKnowledgeContainer;
	public Camera cameraGameObject;
	private int quizAtempt=0;
	private Vector3 lastPosition;
	string[] letterNameArray = {
		"1_alef_texture",
		"2_bet_texture",
		"3_vet_texture",
		"4_gimel_texture",
		"5_daled_texture",
		"6_hay_texture",
		"7_vav_texture",
		"8_zayin_texture",
		"9_chet_texture",
		"10_tet_texture",
		"11_yud_texture",
		"12_kaf_texture",
		"13_chaf_texture",
		"14_final_kaf_texture",
		"15_lamed_texture",
		"16_mem_texture",
		"17_final_mem_texture",
		"18_nun_texture",
		"19_final_nun_texture",
		"20_samekh_texture",
		"21_ayin_texture",
		"22_pay_texture",
		"23_fay_texture",
		"24_final_fay_texture",
		"25_tsadee_texture",
		"26_final_tsadee_texture",
		"27_kuf_texture",
		"28_resh_texture",
		"29_shin_texture",
		"30_sin_texture",
		"31_taf_texture",
		"32_thaf_texture"
	};
	public GameObject pauseMenuContent;
	public bool isChooseLetterActive;

	public AudioClip[] chooseTheLetterArray;
	private int correctAnswerPosition = -1;

	public Renderer[] coinChoiceArray;

	int levelLimit = 5;

	public Animator characterAnimator;

	private bool isFalling=false;
	private int localLvlCounter = 0;
	private int soundLocalLvlCounter = 0;

	public AudioClip[] audioLetterlist;

	IEnumerator Example ()
	{
		print (Time.time);
		yield return new WaitForSeconds (5);
		print (Time.time);
		PauseMenu.PausedOff ();
	}

	void Start ()
	{

		l1.intensity = 0;
		pauseButton = GameObject.FindGameObjectWithTag ("pauseMenu");
		jumpUP = false;
		Physics.gravity = new Vector3 (0, -15f, 0);
		coinsAll = PlayerPrefs.GetInt ("acoin");
		roundLife = 0;
		magnetOn = false;
		jPuck = false;
		botOn = false;
		x2On = false;
		die = false;
		coinCount = 0;
		gameOv.SetActive (false);
		guardGo = true;
		lifesave = false;
		animationManager = this.GetComponent<AnimationManager> ();
		cc = GetComponent<CapsuleCollider> ();
		sc = GetComponent<SphereCollider> ();
		sc.enabled = true;
		am = GameObject.FindGameObjectWithTag ("coinrot").GetComponent<AudioSource> ();
		//fs = GameObject.FindGameObjectWithTag ("footsteps").GetComponent<AudioSource> ();
		bg = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<AudioSource> ();
		guarde = GameObject.FindGameObjectWithTag ("Guard");

		characterAnimator = GetComponent<Animator> ();

	}



	void Update ()
	{
		if (isFalling) {
			RaycastHit hitGround;
			Ray rayDown=new Ray();
			float speed = 20;
			rayDown.origin = dieRaycastDown.transform.position;
			rayDown.direction = Vector3.down;
			Physics.Raycast (rayDown, out hitGround, 0.5F);
			if (hitGround.collider != null && hitGround.collider.tag.Equals("ground")) {
				
				isFalling = false;
				characterAnimator.SetTrigger ("return_to_running");
				PauseMenu.PausedOff ();
			}
			this.transform.position = Vector3.MoveTowards (this.transform.position, lastPosition, speed*Time.deltaTime);
		}


		if (isChooseLetterActive) {


			if (Input.GetMouseButtonDown(0)){ // if left button pressed...
				Ray ray_mouse = cameraGameObject.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit_mouse;
				if (Physics.Raycast(ray_mouse, out hit_mouse)){

					if (hit_mouse.collider.tag.Contains ("coin")) {
						if (correctAnswerPosition != -1 && hit_mouse.collider == coinChoiceArray [correctAnswerPosition].GetComponent<Collider> ()) {
							aSource.enabled = true;
							aSource.clip = chooseTheLetterArray [chooseTheLetterArray.Length - 1];
							aSource.volume = 1F;
							aSource.Play ();

							if (quizAtempt > 3) {
								Application.LoadLevel (1);
							}
							LetterCountController.countValue++;
							quizAtempt++;
							isFalling = true;
							isChooseLetterActive = false;
							this.GetComponent<Rigidbody>().isKinematic=false;

						} else {
							hit_mouse.collider.gameObject.SetActive (false);
							aSource.enabled = true;
							aSource.clip = chooseTheLetterArray [LetterCountController.countValue];
							aSource.volume = 1F;
							aSource.Play ();
						}
					}

				}
			}


			if (Input.touchCount > 0) {

				Touch touch1 = Input.touches [0];
				Ray rayx = cameraGameObject.ScreenPointToRay (touch1.position);
				RaycastHit hitx;
				if (Physics.Raycast (rayx, out hitx)) {

					if (hitx.collider.tag.Contains ("coin")) {
						if (correctAnswerPosition != -1 && hitx.collider == coinChoiceArray [correctAnswerPosition].GetComponent<Collider> ()) {
							aSource.enabled = true;
							aSource.clip = chooseTheLetterArray [chooseTheLetterArray.Length - 1];
							aSource.volume = 1F;
							aSource.Play ();

							LetterCountController.countValue++;

							this.GetComponent<Rigidbody>().isKinematic=false;
							isFalling = true;
							isChooseLetterActive = false;

						} else {
							hitx.collider.gameObject.SetActive (false);
							aSource.enabled = true;
							aSource.clip = chooseTheLetterArray [LetterCountController.countValue];
							aSource.volume = 1F;
							aSource.Play ();
						}
					}

				}
			}



		} 


		if (pauseMenuContent.activeSelf.Equals (false)) {
			pauseButton.SetActive (true);
		}

		if (coldr == true) {
			pauseButton.SetActive (true);
			tc += Time.deltaTime;
			if (tc >= 4F) {
				tc = 0;
				coldr = false;
			}
		}
		if (lifesave == true) {
			timerl += Time.deltaTime;
			if (timerl >= 4F) {
				timerl = 0;
				NoSaved ();
			}
		}
		if (die == true) {
			timerGO += Time.deltaTime;
			if (timerGO >= 2.5F) {
				gameOv.SetActive (true);
			} else {
				gameOv.SetActive (false);
			}
		}

		stopGame = PauseMenu.Pause;
		if (stopGame == false) {

			if (audioM.ismut == false) {
				AudioListener.pause = false;
			}
			//GetComponent<Animation>().enabled = true;
			this.GetComponent<Rigidbody>().isKinematic=false;
			//

			if (swiped) {
				timer += Time.deltaTime;
				if (timer >= SwipeTimeLimit) {
					timer = 0;
					swiped = false;
				}
			}
			if (swiped2) {
				timer2 += Time.deltaTime;
				if (timer2 >= SwipeTimeLimit2) {
					timer2 = 0;
					swiped2 = false;
					jumpUP = false;
				}
			}
			if (crouch) {
				timer3 += Time.deltaTime;
				if (timer3 >= 0.5F) {
					timer3 = 0;
					sc.enabled = true;
					cc.enabled = true;
				}
			}
			if (crouch) {
				dieRay = dieRaycastDown;
			} else {
				dieRay = dieRaycastUp;
			}
			//

			foreach (Touch th in Input.touches) {

				if (th.phase == TouchPhase.Began) {
					initialTouch = th;
				} else if (th.phase == TouchPhase.Moved && !hasSwiped) {
					float deltaX = initialTouch.position.x - th.position.x;
					float deltaY = initialTouch.position.y - th.position.y;
					distance = Mathf.Sqrt ((deltaX * deltaX) + (deltaY * deltaY));
					bool swipeSideways = Mathf.Abs (deltaX) > Mathf.Abs (deltaY);

					if (distance > 15F) {
						if (swipeSideways && deltaX > 0) {
							Left ();
						}
						if (swipeSideways && deltaX <= 0) {
							Right ();
						}
						if (!swipeSideways && deltaY > 0) {
							iRoll ();
						}
						if (!swipeSideways && deltaY <= 0) {
							iJump ();
						}
						hasSwiped = true;
					}
				} else if (th.phase == TouchPhase.Ended) {
					initialTouch = new Touch ();
					hasSwiped = false;
				}
			}

			//
			if (keyboard) {
				if (Input.GetKey (KeyCode.A)) {
					Left ();
				}
				if (Input.GetKey (KeyCode.D)) {
					Right ();
				}
				if (Input.GetKey (KeyCode.W)) {
					iJump ();
				}
				if (Input.GetKey (KeyCode.S)) {
					iRoll ();
				}
			}
			// end keyboard------------------------------<<<//
			RaycastHit toDie;
			Ray ray=new Ray();

			ray.origin = dieRay.transform.position;
			ray.direction = Vector3.forward;
			if (Physics.Raycast (ray, out toDie, 0.15F)) {
				if (toDie.collider.tag == "blocks" || toDie.collider.tag == "otherblock") {
					PauseMenu.Paused ();
					if (roundLife > 0 && lifesave == false) {
						saveButton.SetActive (true);
						saveButtonBG.SetActive (true);
						lifesave = true;
					} else {
						if (lifesave == false && coldr == false) {
							Instantiate (playerDie, new Vector3 (transform.position.x, transform.position.y + 0.9f, transform.position.z + 0.2f), transform.rotation);
							die = true;
							DieTru ();
						}
					}
				}
			}
			Debug.DrawRay (ray.origin, ray.direction,Color.red,0.1f);
			if (narik) {
				Kolyan ();
			}
			RaycastHit t;
			if (Physics.Raycast (raycast.transform.position, Vector3.forward, out t, 1F)) {
				if (t.collider.tag == "coin") {
					Instantiate (prefCoinDie, new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.5F), transform.rotation);
					if (x2On) {
						coinCount = coinCount + 2;
						soundLocalLvlCounter = soundLocalLvlCounter + 2;
						localLvlCounter = localLvlCounter + 2;
					} else {
						coinCount++;
						localLvlCounter++;
						soundLocalLvlCounter++;
					}		
					if (localLvlCounter == levelLimit || localLvlCounter > levelLimit) {

						int level=PlayerPrefs.GetInt ("level");
						level++;
						PlayerPrefs.SetInt ("level", level);
						PauseMenu.Paused ();
						isChooseLetterActive = true;
						lastPosition = transform.position;

						characterAnimator.SetTrigger ("in_game_idle");

						aSource.enabled = true;
						aSource.clip = chooseTheLetterArray [LetterCountController.countValue];
						aSource.volume = 1F;
						aSource.Play ();



						Vector3 temp = new Vector3 (0.0f, 50, 0);
						transform.position += temp;



						Vector3 tempx = new Vector3 (transform.position.x, temp.y + 4f, 17.0f);

						coinKnowledgeContainer.transform.position = tempx;

						bool showCurrentLetter = false;

						//GameObject al = this.gameObject.GetComponentInChildren("ALADDIN2");
						//al.transform.Rotate(Time.deltaTime, 180, 0);

						int[] letterInt = { 0, 1, 2 };

						for (int i = 0; i < letterInt.Length; i++) {
							int temp1 = letterInt [i];
							int randomIndex = Random.Range (i, letterInt.Length);
							letterInt [i] = letterInt [randomIndex];
							letterInt [randomIndex] = temp1;
						}



						List<int> addedLetterPos = new List<int> ();

						for (int i = 0; i < 3; i++) {

							Renderer coinRenderer = coinChoiceArray [letterInt [i]];
							coinRenderer.gameObject.SetActive (true);

							if (!showCurrentLetter) {
								coinRenderer.material.mainTexture = Resources.Load (letterNameArray [LetterCountController.countValue]) as Texture;
								showCurrentLetter = true;
								addedLetterPos.Add (LetterCountController.countValue);
								correctAnswerPosition = letterInt [i];
							} else {
								int incorrectRandomLetter = Random.Range (0, (letterNameArray.Length - 1));
								if (!addedLetterPos.Contains (incorrectRandomLetter)) {
									coinRenderer.material.mainTexture = Resources.Load (letterNameArray [incorrectRandomLetter]) as Texture;
									addedLetterPos.Add (incorrectRandomLetter);
								} else {
									i--;
								}
							}
						}


						localLvlCounter = 0;	
					} else {
						isChooseLetterActive = false;

						am.clip = coinSound;
						am.volume = 0.1F;
						am.Play ();

						if (soundLocalLvlCounter == 10 || soundLocalLvlCounter > 10) {
							soundLocalLvlCounter = 0;
							AudioClip letterAudioClip = audioLetterlist [LetterCountController.countValue];
							aSource.clip = letterAudioClip;
							aSource.volume = 1F;
							aSource.Play ();

						}



					}

					Destroy (t.collider.gameObject.gameObject);
				}
			}
			if (jPuck) {
				coinCount++;
				//localLvlCounter++;
			}

			RaycastHit hit;
			if (Physics.Raycast (transform.position, -Vector3.up, out hit, 0.28F)) {
				if (hit.collider.tag == "ground" || hit.collider.tag == "blocks" || hit.collider.tag == "jumper") {
					isGround = true;
					isJump = false;
				}
				if (hit.collider.tag == "ground" || hit.collider.tag == "jumper") {
					noNeed = true;
				} else {
					noNeed = false;
				}
				if (hit.collider.tag == "blocks" || hit.collider.tag == "jumper") {
					rolled = true;
				} else {
					rolled = false;
				}
				if (hit.collider.tag == "koll") {
					if (die == true) {
						animationManager.animationState = animationManager.Dead;
					} else {
						animationManager.animationState = animationManager.Needles;
					}
					// =============================DEACTIVATE GUARD==============================
					guarde.SetActive (false);
					if (timerG == true && die == false) {
						die = true;
						DieTru ();
						timerG = false;
					} else {
						guardGo = true;
					}
				}
			}
			if (isGround == false && isJump == true) {
				//animationManager.animationState = animationManager.JumpLoop;
				isJump = false;
			}
			if (isGround == true && isJump == false && betman == true) {
				betman = false;
				//animationManager.animationState = animationManager.Run;
			}
			RaycastHit guardF;
			if (Physics.Raycast (raycast.transform.position, Vector3.left, out guardF, 0.15F) || Physics.Raycast (raycast.transform.position, Vector3.right, out guardF, 0.15F)) {
				if (guardF.collider.tag == "blocks" || guardF.collider.tag == "otherblock") {
					// =============================DEACTIVATE GUARD==============================
					//guarde.SetActive (false);
					//guardGo = true;
				}
			}
			//-----------------------------------------------------------------------//
			transform.position = Vector3.Lerp (transform.position, new Vector3 (sw, transform.position.y), Generation.speed * Time.deltaTime);
		} else {
			if (lifesave == false)
				//pauseButton.SetActive(false);
			if (die == false) {
				//GetComponent<Animation>().enabled = false;
				if (audioM.ismut == false) {
					//TODO take a different approach
					//AudioListener.pause = true;
				}
				this.GetComponent<Rigidbody> ().isKinematic = true;
			}
		}
	}

	void Kolyan ()
	{
		for (int l = 0; l < 10; l++) {
			l1.intensity = Random.Range (0, 10);
		}
		lt += Time.deltaTime;
		if (lt > 8f) {
			lt = 0;		
			l1.intensity = 0;
			narik = false;
		}
	}

	void NoSaved ()
	{
		lifesave = false;
		//GetComponent<Animation>().enabled = true;
		saveButton.SetActive (false);
		saveButtonBG.SetActive (false);
		swiped2 = true;
		die = true;
		DieTru ();
	}

	public void SavedLife ()
	{
		lifesave = false;
		roundLife--;
		saveButton.SetActive (false);
		saveButtonBG.SetActive (false);
		coldr = true;
	}


	void DieTru ()
	{
		if (die == true) {
			PlayerPrefs.SetInt ("acoin", coinsAll + coinCount);
			PlayerPrefs.Save ();
			if (jPuck == false) {
				//guarde.SetActive (true);
			}
			//bg.enabled = false;
			//am.clip = dieSound;
			//am.Play ();

			characterAnimator.SetTrigger ("player_head_hurts");
			pauseButton.SetActive (false);
		}
	}

	void OnTriggerExit (Collider par)
	{
		if (par.GetComponent<Collider> ().tag == "blocks" && isJump == false && swiped == false && noNeed == false) {
			animationManager.animationState = animationManager.JumpBetman;
		}
	}

	void BoteOn ()
	{
		botLeft.SetActive (true);
		botRight.SetActive (true);
		if (botOn == true) {
			timer4 = timer4 - BotsTime;
		} else {
			jumpVelocity.y = jumpVelocity.y + 1F;
			botOn = true;
		}
	}


	void Left ()
	{

		characterAnimator.SetTrigger ("leftStrafeAction");
		swiped = true;

		if (timer == 0) {
			if (sw == 0) {
				sw -= DistSwipe;
				if (timer2 == 0) {
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
				}
			} else if (sw == DistSwipe && sw != 0) {
				sw = 0;
				if (timer2 == 0) {
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
				}
			}
		}
		RaycastHit toDie;
		Ray rayLeft=new Ray();

		rayLeft.origin = dieRaycastDown.transform.position;
		rayLeft.direction = Vector3.left;
		if (Physics.Raycast (rayLeft, out toDie, 0.15F)) {

			if (toDie.collider.tag == "blocks" || toDie.collider.tag == "otherblock"|| toDie.collider.tag == "ground") {
				sw += DistSwipe;
			}

		}



	}

	void Right ()
	{
		characterAnimator.SetTrigger ("rightStrafeAction");
		swiped = true;
		if (timer == 0) {
			if (sw == 0) {
				sw += DistSwipe;
				if (timer2 == 0) {
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
				}
			} else if (sw == (-DistSwipe) && sw != 0) {
				sw = 0;
				if (timer2 == 0) {
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
				}
			}
		}
		RaycastHit toDie;
		Ray rayRight=new Ray();
		rayRight.origin = dieRaycastDown.transform.position;
		rayRight.direction = -Vector3.left;

		if (Physics.Raycast (rayRight, out toDie, 0.15F)) {

			if (toDie.collider.tag == "blocks" || toDie.collider.tag == "otherblock"|| toDie.collider.tag == "ground") {
				sw -= DistSwipe;
			}

		}
	}

	void iJump ()
	{
		if (timer2 == 0) {
			jumpUP = true;
			swiped2 = true;

			if (isGround == true && jPuck == false && timer3 == 0) {
				fs.volume = 0.9F;
				fs.clip = swipeSound;
				fs.Play ();
				isGround = false;
				isJump = true;

				characterAnimator.SetTrigger ("jumpSelected");

				this.GetComponent<Rigidbody> ().AddForce (jumpVelocity, ForceMode.VelocityChange);

			}	
		}
	}

	void iRoll ()
	{

		characterAnimator.SetTrigger ("slideSelected");
		StartCoroutine (crouchWait ());
		cc.enabled = false;
		sc.enabled = true;
		/*if (isGround == true && jPuck == false) {
			fs.volume = 0.9F;
			fs.clip = swipeSound;
			fs.Play ();



			//int rN = UnityEngine.Random.Range (0, 3);
			this.GetComponent<Rigidbody> ().AddForce (-Vector3.up, ForceMode.VelocityChange);

		}
		*/
	}

	IEnumerator playChooseLetterSound ()
	{
		am.enabled = true;
		AudioListener.pause = false;
		am.clip = chooseTheLetterArray [LetterCountController.countValue];
		am.volume = 1F;
		am.Play ();
		yield return null;
	}

	IEnumerator crouchWait(){
		crouch = true;
		yield return new WaitForSeconds (1f);
		crouch = false;
		timer3 = 0;
	}

	private void returnRuning(){
		RaycastHit hitGround;
		Ray rayDown=new Ray();

		rayDown.origin = dieRaycastDown.transform.position;
		rayDown.direction = Vector3.down;
		float speed = 1;
		Physics.Raycast (rayDown, out hitGround, 0.15F);
		while(hitGround.collider==null){
			float step =speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Vector3.down, step);
			Physics.Raycast (rayDown, out hitGround, 0.15F);
		}



	}

}
