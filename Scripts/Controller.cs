using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public Light l1;
	float lt;
	bool narik = false;
	[HideInInspector]
	public bool isRoll, isSlide;
	public static int coinCount =0;
	public static int coinsAll;
	[Space(10)]
	public bool keyboard;
	private bool coldr = false;
	private int BookCount, MedalCount, DudkaCount, ZmeyCount, VazaCount;
	[Space(10)]
	[Header("Префабы эффектов разрушения:")]
	public Transform playerDie;
	public Transform prefBoteDie;
	public Transform prefCoinDie;
	public Transform prefx2Die;
	public Transform prefMagnitDie;
	public Transform prefJpuckDie;
	[Header("Рейкасты игрока:")]
	public Transform raycast;
	public Transform dieRaycastUp;
	public Transform dieRaycastDown;
	private Transform dieRay;
	[Header("Аудиоклипы различных эффектов:")]
	public AudioClip coinSound;
	public AudioClip boteSound;
	public AudioClip magnetSound;
	public AudioClip jetSound;
	public AudioClip dieSound;
	public AudioClip x2Sound;
	public AudioClip swipeSound;
	public static bool isGround = false;
	public static bool guardGo = false;
	private float sw,timer,timer2,timer3,timer6, timerl,timer8,timerGO,tc;
	public static float timer4,timer5,timer7;
	private bool swiped, rolled, timerG;
	public static bool swiped2;
	public static bool isJump = false;
	[Header("Время действия бонусов:")]
	public static float BotsTime;
	public static float x2Time;
	public static float MagnetTime;
	public static float jPuckTime;
	[Header("Настройки игрока:")]
	public float DistSwipe;
	private AnimationManager animationManager;
	private float SwipeTimeLimit = 0.3f;
	private float SwipeTimeLimit2 = 1f;
	private bool betman = false;
	private Collider cc,sc;
	public static bool crouch = false;
	public Vector3 jumpVelocity; 
	public static bool stopGame;
	private AudioSource am,fs,bg;
		public AudioSource aSource;
	public static bool die;
	private GameObject guarde;
	GameObject pauseButton;
	public static bool jPuck,botOn,x2On,magnetOn;
	[Header("ВКЛ/ВЫКЛ - одежки и бонусы:")]
	public GameObject magObj;
	public GameObject magObj2;
	public GameObject kover;
	public GameObject botLeft,botRight;
	private bool noNeed = false;
	public static int roundLife = 0;
	public GameObject saveButton;
	public GameObject saveButtonBG;
	public GameObject gameOv;
	private Touch initialTouch = new Touch();
	private float distance;
	private bool hasSwiped = false;
	public static bool lifesave = false;
	private int mgn,kvr,bts,x2t;
	public static bool jumpUP;
	public Texture KoverText1;
	public Texture KoverText2;
	public Texture KoverText3;
	public GameObject koverGo;
	public GameObject coinKnowledgeContainer;
	public Camera cameraGameObject;
	string[] letterNameArray = {"1_alef_texture","2_bet_texture","3_vet_texture", "4_gimel_texture", "5_daled_texture", "6_hay_texture", "7_vav_texture", "8_zayin_texture","9_chet_texture", "10_tet_texture", "11_yud_texture", "12_kaf_texture", "13_chaf_texture", "14_final_kaf_texture", "15_lamed_texture", "16_mem_texture", "17_final_mem_texture", "18_nun_texture", "19_final_nun_texture", "20_samekh_texture", "21_ayin_texture","22_pay_texture", "23_fay_texture", "24_final_fay_texture", "25_tsadee_texture", "26_final_tsadee_texture", "27_kuf_texture","28_resh_texture", "29_shin_texture", "30_sin_texture", "31_taf_texture", "32_thaf_texture"};
	public GameObject pauseMenuContent;
	public bool isChooseLetterActive;

	public AudioClip[] chooseTheLetterArray;
	private int correctAnswerPosition= -1;

	public Renderer[] coinChoiceArray;

	int levelLimit = 10;




	private int localLvlCounter = 0;
	private int soundLocalLvlCounter = 0;

	public AudioClip[] audioLetterlist;

	IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(5);
		print(Time.time);
		PauseMenu.PausedOff ();
	}

	void Start(){

		l1.intensity = 0;
		pauseButton = GameObject.FindGameObjectWithTag ("pauseMenu");
		jumpUP = false;
		Physics.gravity = new Vector3(0,-15f,0);
		mgn = PlayerPrefs.GetInt ("m_LvL");
		kvr = PlayerPrefs.GetInt ("k_LvL");
		x2t = PlayerPrefs.GetInt ("d_LvL");
		bts = PlayerPrefs.GetInt ("b_LvL");
		coinsAll = PlayerPrefs.GetInt ("acoin");
		BookCount = PlayerPrefs.GetInt ("abook");
		VazaCount = PlayerPrefs.GetInt ("avaza");
		ZmeyCount = PlayerPrefs.GetInt ("azmey");
		MedalCount = PlayerPrefs.GetInt ("amedal");
		DudkaCount = PlayerPrefs.GetInt ("adudka");
		roundLife = 0;
		kover.SetActive (false);
		magObj.SetActive (false);
		magObj2.SetActive (false);
		magnetOn = false;
		jPuck = false;
		botOn = false;
		x2On = false;
		die = false;
		coinCount = 0;
		gameOv.SetActive (false);
		guardGo = true;
		lifesave = false;
		animationManager = this.GetComponent<AnimationManager>();
		cc = GetComponent<CapsuleCollider> ();
		sc = GetComponent<SphereCollider> ();
		sc.enabled = true;
		am = GameObject.FindGameObjectWithTag ("coinrot").GetComponent<AudioSource> ();
		fs = GameObject.FindGameObjectWithTag ("footsteps").GetComponent<AudioSource> ();
		bg = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<AudioSource> ();
		guarde = GameObject.FindGameObjectWithTag ("Guard");
	}



	void Update() {


		if (isChooseLetterActive) {

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

							PauseMenu.PausedOff ();
						} else {
							hitx.collider.gameObject.SetActive (false);
							aSource.enabled = true;
							aSource.clip = chooseTheLetterArray [LetterCountController.countValue - 1];
							aSource.volume = 1F;
							aSource.Play ();
						}
					}

				}
			}


		
		} 


		if(pauseMenuContent.active.Equals(false)){
			pauseButton.SetActive(true);
		}

		if (coldr == true) {
			pauseButton.SetActive (true);
			tc += Time.deltaTime;
			if(tc>=4F){
				tc = 0;
				coldr = false;
			}
		}
		if (lifesave==true) {
			timerl += Time.deltaTime;
			if (timerl >= 4F) {
				timerl = 0;
				NoSaved ();
			}
		}
		if (die == true) {
			timerGO += Time.deltaTime;
			if(timerGO>=2.5F){
				gameOv.SetActive(true);
			}
			else {
				gameOv.SetActive(false);
			}
		}
		if (!die && !guardGo) {
			//guarde.SetActive (false);
		}
		stopGame = PauseMenu.Pause;
		if (stopGame == false){
			if (mgn == 1) {
				MagnetTime = 15f;
			}
			else if (mgn == 2) {
				MagnetTime = 20f;
			}
			else if (mgn == 3) {
				MagnetTime = 25f;
			}
			else if (mgn == 4) {
				MagnetTime = 30f;
			}
			else if (mgn == 5) {
				MagnetTime = 35f;
			}
			else  {
				MagnetTime = 10f;
			}
			
			if (kvr == 1) {
				jPuckTime = 15f;
			}
			else if (kvr == 2) {
				jPuckTime = 20f;
			}
			else if (kvr == 3) {
				jPuckTime = 25f;	
			}
			else if (kvr == 4) {
				jPuckTime = 30f;
			}
			else if (kvr == 5) {
				jPuckTime = 35f;	
			}
			else  {
				jPuckTime = 10f;	
			}
			
			if (x2t == 1) {
				x2Time = 15f;
			}
			else if (x2t == 2) {
				x2Time = 20f;	
			}
			else if (x2t == 3) {
				x2Time = 25f;	
			}
			else if (x2t == 4) {
				x2Time = 30f;
			}
			else if (x2t == 5) {
				x2Time = 35f;
			}
			else  {
				x2Time = 10f;
			}
			
			if (bts == 1) {
				BotsTime = 15f;	
			}
			else if (bts == 2) {
				BotsTime = 20f;
			}
			else if (bts == 3) {
				BotsTime = 25f;
			}
			else if (bts == 4) {
				BotsTime = 30f;	
			}
			else if (bts == 5) {
				BotsTime = 35f;	
			}
			else  {
				BotsTime = 10f;	
			}

			if(audioM.ismut == false){
				AudioListener.pause = false;
			}
		GetComponent<Animation>().enabled = true;
		this.GetComponent<Rigidbody>().isKinematic=false;
		//
				if (guardGo==true) {
					timer6 += Time.deltaTime;
					if (timer6 >= 1F){
						timerG=true;
					}
					if (timer6 >= 20F) {
						timer6 = 0;
						timerG=false;
						guardGo = false;
					}
				}
				if (magnetOn == true) {
					timer7 += Time.deltaTime;
					if (timer7 >= MagnetTime) {
						timer7 = 0;
						magObj.SetActive (false);
						magObj2.SetActive (false);
						magnetOn = false;
					}
				}
				if (jPuck == true) {
					guardGo = false;
					timer8 += Time.deltaTime;
					kover.SetActive (true);
					Physics.gravity = new Vector3(0,- 9.8f,0);
					if (timer8 >= 0.97F && timer8<jPuckTime) {
						this.GetComponent<Rigidbody>().useGravity=false;
					}
					if (timer8 >= jPuckTime) {
						timer8 = 0;
						jPuck = false;
						kover.SetActive (false);
					Physics.gravity = new Vector3(0,-15f,0);
						animationManager.animationState = animationManager.JumpBetman2;
						this.GetComponent<Rigidbody>().useGravity=true;
					}
				}
				if (x2On) {
					timer5 += Time.deltaTime;
					if (timer5 >= x2Time) {
						timer5 = 0;
						x2On = false;
					}
				}
				if (botOn) {
					timer4 += Time.deltaTime;
					
					if (timer4 >= BotsTime) {
						timer4 = 0;
						botOn = false;
						botLeft.SetActive (false);
						botRight.SetActive (false);
						jumpVelocity.y = jumpVelocity.y-1F;
					}
				}
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
								crouch = false;
						}
				}
				if(crouch){
					dieRay = dieRaycastDown;
				}
				else{
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
				if (Physics.Raycast (dieRay.transform.position, Vector3.forward, out toDie, 0.5F)) {
					if (toDie.collider.tag == "blocks" || toDie.collider.tag == "otherblock") {
						if(roundLife >0 && lifesave ==false){
							saveButton.SetActive (true);
							saveButtonBG.SetActive (true);
							lifesave = true;
						}else{
							if(lifesave == false && coldr == false){
								Instantiate (playerDie, new Vector3 (transform.position.x, transform.position.y+0.9f, transform.position.z+0.2f), transform.rotation);
								die=true;
								DieTru();
							}
						}
					}
				}
				if(narik){
					Kolyan();
				}
				RaycastHit t;
				if (Physics.Raycast (raycast.transform.position, Vector3.forward, out t, 1F)) {
						if (t.collider.tag == "coin") {
								Instantiate (prefCoinDie, new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.5F), transform.rotation);
								if(x2On){
									coinCount = coinCount+2;
									soundLocalLvlCounter = soundLocalLvlCounter + 2;
									localLvlCounter =localLvlCounter + 2;
								}
								else{
									coinCount++;
									localLvlCounter++;
									soundLocalLvlCounter++;
								}		
								if(localLvlCounter == levelLimit || localLvlCounter > levelLimit){
									
									PauseMenu.Paused();
									isChooseLetterActive = true;

									aSource.enabled = true;
									aSource.clip = chooseTheLetterArray[LetterCountController.countValue];
									aSource.volume = 1F;
									aSource.Play ();
					
									Vector3 tempx = new Vector3(transform.position.x,51,15.0f);

									coinKnowledgeContainer.transform.position = tempx;
									Vector3 temp = new Vector3(0.0f,50,0);
						 			transform.position += temp;

									bool showCurrentLetter = false;

									//GameObject al = this.gameObject.GetComponentInChildren("ALADDIN2");
									//al.transform.Rotate(Time.deltaTime, 180, 0);

									int[] letterInt = {0,1,2};

									for (int i = 0; i < letterInt.Length; i++) {
										int temp1 = letterInt[i];
										int randomIndex = Random.Range(i, letterInt.Length);
										letterInt[i] = letterInt[randomIndex];
										letterInt[randomIndex] = temp1;
									}

									
								
									List<int> addedLetterPos = new List<int> ();

									for(int i=0;i<3;i++){
							
										Renderer coinRenderer = coinChoiceArray [letterInt[i]];
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
									LetterCountController.countValue++;

								}else{
						isChooseLetterActive = false;
									am.clip = coinSound;
									am.volume = 0.1F;
									am.Play ();

									if(soundLocalLvlCounter == 10 || soundLocalLvlCounter > 10){
										soundLocalLvlCounter = 0;
										AudioClip letterAudioClip = audioLetterlist[LetterCountController.countValue];
										aSource.clip = letterAudioClip;
										aSource.volume = 1F;
										aSource.Play ();

									}
								
							
							
								}
												
								Destroy (t.collider.gameObject.gameObject);
						}
						if (t.collider.tag == "kalyan") {
							narik = true;
							am.clip = boteSound;
							am.Play ();
							Destroy (t.collider.gameObject);
						}
						if (t.collider.tag == "bote") {
							Instantiate (prefBoteDie, new Vector3 (transform.position.x, transform.position.y+0.5f, transform.position.z + 0.5F), transform.rotation);
							BoteOn();
							am.clip = boteSound;
							am.Play ();
							Destroy (t.collider.gameObject);
						}
						if (t.collider.tag == "x2") {
							Instantiate (prefx2Die, new Vector3 (transform.position.x, transform.position.y+ 0.5F, transform.position.z + 0.5F), transform.rotation);
							if (x2On == true) {
								timer5 = timer5-x2Time;
							} else{
								x2On = true;
							}
							am.clip = x2Sound;
							am.Play ();
							Destroy (t.collider.gameObject);
						}
						if (t.collider.tag == "mag") {
							Instantiate (prefMagnitDie, new Vector3 (transform.position.x, transform.position.y+0.5f, transform.position.z + 0.5F), transform.rotation);
							am.clip = magnetSound;
							am.Play ();
							Destroy (t.collider.gameObject);
							magObj.SetActive (true);
							magObj2.SetActive (true);
							if (magnetOn == true) {
								timer7 = timer7-MagnetTime;
							} else{
								magnetOn = true;						
							}
							
						}
						if (t.collider.tag == "jetPuck") {
							Instantiate (prefJpuckDie, new Vector3 (transform.position.x, transform.position.y+0.5f, transform.position.z + 0.5F), transform.rotation);
							this.GetComponent<Rigidbody>().AddForce((new Vector3(0,5,0))*2, ForceMode.VelocityChange);
							am.clip = jetSound;
							am.Play ();
							Destroy (t.collider.gameObject);
							jPuck = true;
							fLy();
						}
						if (t.collider.tag == "book") {
							Destroy (t.collider.gameObject);
							BookCount++;
							PlayerPrefs.SetInt("abook", BookCount);
							am.clip = x2Sound;
							am.Play ();
						}
						if (t.collider.tag == "dudka") {
							Destroy (t.collider.gameObject);
							DudkaCount++;
							PlayerPrefs.SetInt("adudka", DudkaCount);
							am.clip = x2Sound;
							am.Play ();
						}
						if (t.collider.tag == "medal") {
							Destroy (t.collider.gameObject);
							MedalCount++;
							PlayerPrefs.SetInt("amedal", MedalCount);
							am.clip = x2Sound;
							am.Play ();
						}
						if (t.collider.tag == "vaza") {
							Destroy (t.collider.gameObject);
							VazaCount++;
							PlayerPrefs.SetInt("avaza", VazaCount);
							am.clip = x2Sound;
							am.Play ();
						}
						if (t.collider.tag == "zmey") {
							Destroy (t.collider.gameObject);
							ZmeyCount++;
							PlayerPrefs.SetInt("azmey", ZmeyCount);
							am.clip = x2Sound;
							am.Play ();
						}
						if (t.collider.tag == "lampa") {
							Destroy (t.collider.gameObject);
							am.clip = x2Sound;
							am.Play ();
							roundLife++;
						}
				}
				if(jPuck){
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
						}
						else{
							noNeed = false;
						}
						if (hit.collider.tag == "blocks" || hit.collider.tag == "jumper") {
								rolled = true;
						} else {
								rolled = false;
						}
						if (hit.collider.tag == "koll") {
							if(die==true){
								animationManager.animationState = animationManager.Dead;
							}else{
								animationManager.animationState = animationManager.Needles;
							}
						// =============================DEACTIVATE GUARD==============================
							guarde.SetActive (false);
							if(timerG==true&&die==false){
								die=true;
								DieTru();
								timerG=false;
							}else{
								guardGo = true;
							}
						}
				}
				if (isGround == false && isJump == true) {
						animationManager.animationState = animationManager.JumpLoop;
						isJump = false;
				}
				if (isGround == true && isJump == false && betman == true) {
						betman = false;
						animationManager.animationState = animationManager.Run;
				}
				RaycastHit guardF;
			if (Physics.Raycast (raycast.transform.position, Vector3.left, out guardF, 0.15F) ||Physics.Raycast (raycast.transform.position, Vector3.right, out guardF, 0.15F )) {
					if (guardF.collider.tag == "blocks" ||guardF.collider.tag == "otherblock") {
						// =============================DEACTIVATE GUARD==============================
						//guarde.SetActive (false);
						//guardGo = true;
					}
				}
				//-----------------------------------------------------------------------//
				transform.position = Vector3.Lerp (transform.position, new Vector3 (sw, transform.position.y), Generation.speed * Time.deltaTime);
		}
		else{
			if(lifesave==false)
			//pauseButton.SetActive(false);
			if(die==false){
				GetComponent<Animation>().enabled = false;
				if(audioM.ismut == false){
					//TODO take a different approach
					//AudioListener.pause = true;
				}
				this.GetComponent<Rigidbody>().isKinematic=true;
			}
		}
	}

	void Kolyan(){
		for (int l = 0; l<10; l++) {
			l1.intensity = Random.Range (0, 10);
		}
		lt += Time.deltaTime;
		if (lt > 8f) {
			lt = 0;		
			l1.intensity = 0;
			narik = false;
		}
	}

	 void NoSaved(){
		lifesave = false;
		GetComponent<Animation>().enabled = true;
		saveButton.SetActive (false);
		saveButtonBG.SetActive (false);
		swiped2 = true;
		die=true;
		DieTru();
	}

	public void SavedLife(){
		lifesave = false;
		roundLife--;
		saveButton.SetActive (false);
		saveButtonBG.SetActive (false);
		coldr = true;
	}

	void fLy(){
		if (kvr == 4) {
			koverGo.GetComponent<Renderer>().material.mainTexture = KoverText3;	
		} else if (kvr == 5) {
			koverGo.GetComponent<Renderer>().material.mainTexture = KoverText1;	
		} else {
			koverGo.GetComponent<Renderer>().material.mainTexture = KoverText2;	
		}
		if (jPuck == true) {
			animationManager.animationState = animationManager.FlyUpper;	
		}
	}

	void DieTru(){
		if (die == true) {
			PlayerPrefs.SetInt ("acoin",coinsAll + coinCount);
			PlayerPrefs.Save ();
			if(jPuck == false){
				//guarde.SetActive (true);
			}
			bg.enabled = false;
			am.clip = dieSound;
			am.Play ();
			animationManager.animationState = animationManager.Dead;
			pauseButton.SetActive (false);
		}
	}

	void OnTriggerExit(Collider par) {
		if (par.GetComponent<Collider>().tag == "blocks" && isJump==false && swiped ==false && noNeed == false) {
			animationManager.animationState = animationManager.JumpBetman;
		}
	}

	void BoteOn(){
			botLeft.SetActive (true);
			botRight.SetActive (true);
		if (botOn == true) {
			timer4 = timer4-BotsTime;
		} else{
			jumpVelocity.y = jumpVelocity.y + 1F;
			botOn = true;
		}
	}


	void Left(){
		swiped = true;

		if (timer == 0) {
			if(sw ==0){
				sw -=DistSwipe;
				if(timer2==0){
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
					if(jPuck==true){
						animationManager.animationState = animationManager.fLeft;
					}else{
						animationManager.animationState = animationManager.TurnLeft;
					}
				}
			}
			else if(sw == DistSwipe && sw  != 0){
				sw =0;
				if(timer2==0){
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
					if(jPuck==true ){
						animationManager.animationState = animationManager.fLeft;
					}else{
						animationManager.animationState = animationManager.TurnLeft;
					}
				}
			}
		}
	}
	
	void Right(){
		swiped = true;
		if (timer == 0) {
			if(sw ==0){
				sw +=DistSwipe;
				if(timer2==0){
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
					if(jPuck==true){
						animationManager.animationState = animationManager.fRight;
					}else{
						animationManager.animationState = animationManager.TurnRight;
					}
				}
			}
			else if(sw == (-DistSwipe) && sw  != 0){
				sw =0;
				if(timer2==0){
					fs.volume = 0.8F;
					fs.clip = swipeSound;
					fs.Play ();
					if(jPuck==true){
						animationManager.animationState = animationManager.fRight;
					}else{
						animationManager.animationState = animationManager.TurnRight;
					}
				}
			}
		}
	}

	void iJump(){
		if (timer2 == 0) {
			jumpUP = true;
			swiped2 = true;
			if (isGround == true && jPuck ==false && timer3==0) {
				fs.volume = 0.9F;
				fs.clip = swipeSound;
				fs.Play ();
				isGround = false;
				isJump = true;
				animationManager.animationState = animationManager.Jump;

				this.GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
			
			}	
		}
	}
	
	void iRoll(){
		if (isGround == true && jPuck ==false ) {
			fs.volume = 0.9F;
			fs.clip = swipeSound;
			fs.Play ();
			cc.enabled = false;
			sc.enabled = true;
			crouch = true;
			int rN = UnityEngine.Random.Range (0, 3);
			this.GetComponent<Rigidbody>().AddForce(-Vector3.up, ForceMode.VelocityChange);
			if(swiped2==true){

			}
			else{
				if(swiped2 == false){
					if (rN == 2 && rolled ==false) {
						animationManager.animationState = animationManager.Slide;	
					} else{
						animationManager.animationState = animationManager.Roll;
					}
				}
			}
		}
	}

	IEnumerator playChooseLetterSound() {
		am.enabled = true;
		AudioListener.pause = false;
		am.clip = chooseTheLetterArray[LetterCountController.countValue];
		am.volume = 1F;
		am.Play ();
		yield return null;
	}

}
