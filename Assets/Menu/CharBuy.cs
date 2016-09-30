using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharBuy : MonoBehaviour {


		public int skin1 = 5;
		public int skin2 = 10;
		public int skinNew = 100;
		public int cape1 = 1;
		public int cape2 = 2;
		public int cape3 = 3;
		public int cape4 = 45;
		public int cape5 = 25;
		public int cape6 = 4;
		public int cape7 = 6;
		public int metch1 = 15;
		public int metch2 = 2;
		public int metch3 = 25;
		public int metch4 = 5;

	public Animation animat;
	public Animation dooranimat;
	public GameObject PlayerX;
	public GameObject PlayerMesh;
	public GameObject PlayerMesh2;
	public Texture StartCostum;
	public Texture RedCostum;
	public Texture GreenCostum;
	public GameObject[] Shapki;
	public GameObject[] Mech;
	private int itemNumer;
	public GameObject butLeft,butRight;
	private bool show;
	private int kostum;
	public GameObject imButton;
	public GameObject BuyButton;
	private bool shopping;

	public Text BuyBut;
	public Text coast;

	private int rd, gr, m1, m2, m3, m4, c1, c2, c3, c4, c5, c6, c7, ald;
	private int money;
	private int mm;
	private int cm;
	private int mem;

	//
	private int magLevel;
	public Scrollbar magnetP;
	private int kovLevel;
	public Scrollbar koverP;
	private int botLevel;
	public Scrollbar botP;
	private int dLevel;
	public Scrollbar dP;
	public Text tMagnit;
	public Text tKover;
	public Text tBot;
	public Text tDouble;
	public Text itemName;

	void Start () {
		if (PlayerPrefs.HasKey ("char")) {
			kostum = PlayerPrefs.GetInt ("char");
		} else {
			kostum = 0;	
		}
		itemNumer = 0;
		PlayerMesh2.SetActive(false);
		animat.GetComponent<Animation>()["Open"].speed = 0.35f;
		animat.CrossFade ("Open");
		dooranimat.GetComponent<Animation>()["opendoor"].speed = 0.4f;
		dooranimat.CrossFade ("opendoor");
	}

	public void BackedGo(){
		shopping = false;
	}

	public void Shoped(){
		shopping = true;
	}

	void Update () {
		mm = PlayerPrefs.GetInt ("char");
		cm = PlayerPrefs.GetInt ("cap");
		mem = PlayerPrefs.GetInt ("mech");
		if (PlayerPrefs.HasKey ("m_LvL")) {
			magLevel = PlayerPrefs.GetInt ("m_LvL");
		} else {
			magLevel = 0;
			magnetP.size = 0f;
			tMagnit.text = "Upgrede 750";
		}
		if (magLevel == 1) {
			magnetP.size = 0.2f;
			tMagnit.text = "Upgrede 2 500";
		}
		else if (magLevel == 2) {
			magnetP.size = 0.4f;
			tMagnit.text = "Upgrede 5 000";
		}
		else if (magLevel == 3) {
			magnetP.size = 0.6f;
			tMagnit.text = "Upgrede 7 500";
		}
		else if (magLevel == 4) {
			magnetP.size = 0.8f;
			tMagnit.text = "Upgrede 10 000";
		}
		else if (magLevel == 5) {
			magnetP.size = 1f;
			tMagnit.text = "Perfect!";
		}

		if (PlayerPrefs.HasKey ("k_LvL")) {
			kovLevel = PlayerPrefs.GetInt ("k_LvL");
		} else {
			kovLevel = 0;
			koverP.size = 0f;
			tKover.text = "Upgrede 750";
		}
		if (kovLevel == 1) {
			koverP.size = 0.2f;
			tKover.text = "Upgrede 2 500";
		}
		else if (kovLevel == 2) {
			koverP.size = 0.4f;
			tKover.text = "Upgrede 5 000";
		}
		else if (kovLevel == 3) {
			koverP.size = 0.6f;
			tKover.text = "Upgrede 7 500";
		}
		else if (kovLevel == 4) {
			koverP.size = 0.8f;
			tKover.text = "Upgrede 10 000";
		}
		else if (kovLevel == 5) {
			koverP.size = 1f;
			tKover.text = "Perfect!";
		}

		if (PlayerPrefs.HasKey ("b_LvL")) {
			botLevel = PlayerPrefs.GetInt ("b_LvL");
		} else {
			botLevel = 0;
			botP.size = 0f;
			tBot.text = "Upgrede 750";
		}
		if (botLevel == 1) {
			botP.size = 0.2f;
			tBot.text = "Upgrede 2 500";
		}
		else if (botLevel == 2) {
			botP.size = 0.4f;
			tBot.text = "Upgrede 5 000";
		}
		else if (botLevel == 3) {
			botP.size = 0.6f;
			tBot.text = "Upgrede 7 500";
		}
		else if (botLevel == 4) {
			botP.size = 0.8f;
			tBot.text = "Upgrede 10 000";
		}
		else if (botLevel == 5) {
			botP.size = 1f;
			tBot.text = "Perfect!";
		}

		if (PlayerPrefs.HasKey ("d_LvL")) {
			dLevel = PlayerPrefs.GetInt ("d_LvL");
		} else {
			dLevel = 0;
			dP.size = 0f;
			tDouble.text = "Upgrede 750";
		}
		if (dLevel == 1) {
			dP.size = 0.2f;
			tDouble.text = "Upgrede 2 500";
		}
		else if (dLevel == 2) {
			dP.size = 0.4f;
			tDouble.text = "Upgrede 5 000";
		}
		else if (dLevel == 3) {
			dP.size = 0.6f;
			tDouble.text = "Upgrede 7 500";
		}
		else if (dLevel == 4) {
			dP.size = 0.8f;
			tDouble.text = "Upgrede 10 000";
		}
		else if (dLevel == 5) {
			dP.size = 1f;
			tDouble.text = "Perfect!";
		}

	
		if (shopping) {
			ald = PlayerPrefs.GetInt ("ald_pp");
			rd = PlayerPrefs.GetInt ("rd_pp");
			gr = PlayerPrefs.GetInt ("gr_pp");
			m1 = PlayerPrefs.GetInt ("m1_pp");
			m2 = PlayerPrefs.GetInt ("m2_pp");
			m3 = PlayerPrefs.GetInt ("m3_pp");
			m4 = PlayerPrefs.GetInt ("m4_pp");
			c1 = PlayerPrefs.GetInt ("c1_pp");
			c2 = PlayerPrefs.GetInt ("c2_pp");
			c3 = PlayerPrefs.GetInt ("c3_pp");
			c4 = PlayerPrefs.GetInt ("c4_pp");
			c5 = PlayerPrefs.GetInt ("c5_pp");
			c6 = PlayerPrefs.GetInt ("c6_pp");
			c7 = PlayerPrefs.GetInt ("c7_pp");
			money = PlayerPrefs.GetInt ("acoin");
			if (PlayerPrefs.HasKey ("char")) {
				kostum = PlayerPrefs.GetInt ("char");
			} else {
				kostum = 0;	
			}

			if (itemNumer == 0) {
				BuyButton.SetActive (false);	
				imButton.SetActive (false);		
			} else {
				BuyButton.SetActive (true);	
				imButton.SetActive (true);	
			}

			if (show == false) {
				if(kostum == 2){
					PlayerMesh.GetComponent<Renderer>().material.mainTexture = RedCostum;
				}
				else if(kostum == 3){
					PlayerMesh.GetComponent<Renderer>().material.mainTexture = GreenCostum;
				}
				else{
					PlayerMesh.GetComponent<Renderer>().material.mainTexture = StartCostum;
				}
			}	

			if (itemNumer == 0) {
				butLeft.SetActive(false);
			}
			else if (itemNumer == 1) {
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				itemName.text = "Starting clothing";
				BuyBut.text="Wear";
				coast.text="In the chest";
				butLeft.SetActive(false);
				PlayerMesh.GetComponent<Renderer>().material.mainTexture = StartCostum;	
				show = true;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
				if(mm!=2 && mm!=3 && mm!=4){
					BuyButton.SetActive (false);
					coast.text="Dressed";
				}
			}
			else if (itemNumer == 2) {
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				itemName.text = "Red clothing";
				if(rd==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(mm==2){
						BuyButton.SetActive (false);
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text= skin1.ToString ();
				}
				butLeft.SetActive(true);
				PlayerMesh.GetComponent<Renderer>().material.mainTexture = RedCostum;
				show = true;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 3) {
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				itemName.text = "Blue clothing";
				if(gr==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(mm==3){
						BuyButton.SetActive (false);
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text= skin2.ToString ();
				}
				PlayerMesh.GetComponent<Renderer>().material.mainTexture = GreenCostum;
				show = true;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 4) {
				itemName.text = "Red small cap";
				if(c1==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==1){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape1.ToString ();
				}
				Shapki[0].SetActive(true);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 5) {
				itemName.text = "White prince cap";
				if(c2==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==2){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape2.ToString ();
				}
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(true);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 6) {
				itemName.text = "Colored cap";
				if(c3==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==3){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape3.ToString ();
				}
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(true);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 7) {
				itemName.text = "Sultan cap";
				if(c4==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==4){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape4.ToString ();
				}
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(true);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);	
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 8) {
				itemName.text = "Rastaman cap";
				if(c5==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==5){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape5.ToString ();;
				}
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(true);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 9) {
				itemName.text = "Sultan guard cap";
				if(c6==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==6){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape6.ToString ();
				}
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(true);
				Shapki[6].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 10) {
				itemName.text = "Sultan cap Prime";
				if(c7==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(cm==7){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=cape7.ToString ();
				}
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(true);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 11) {
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);	
				itemName.text = "Knife";
				if(m1==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(mem==1){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=metch1.ToString ();
				}
				Mech[0].SetActive(true);
				Mech[1].SetActive(false);
				Mech[2].SetActive(false);
				Mech[3].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 12) {
				itemName.text = "Small sword";
				if(m2==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(mem==2){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=metch2.ToString ();
				}
				Mech[0].SetActive(false);
				Mech[1].SetActive(true);
				Mech[2].SetActive(false);
				Mech[3].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 13) {
				itemName.text = "Big sword 1";
				if(m3==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(mem==3){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=metch3.ToString ();
				}
				Mech[0].SetActive(false);
				Mech[1].SetActive(false);
				Mech[2].SetActive(true);
				Mech[3].SetActive(false);
				show = false;
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
			}
			else if (itemNumer == 14) {
				itemName.text = "Big sword 2";
				if(m4==1){
					BuyBut.text="Wear";
					coast.text="In the chest";
					if(mem==4){
						BuyBut.text="Remove";
						coast.text="Dressed";
					}
				}
				else{
					BuyBut.text="Buy";
					coast.text=metch4.ToString ();
				}
				Mech[0].SetActive(false);
				Mech[1].SetActive(false);
				Mech[2].SetActive(false);
				Mech[3].SetActive(true);
				butRight.SetActive(true);
				show = false;
				
				PlayerMesh2.SetActive(false);
				PlayerMesh.SetActive(true);
				
				
			}
			else if (itemNumer == 15) {
				if(MainMenu.unLock==false){
					BuyButton.SetActive (false);
					coast.text="Locked";
				}else{
					if(ald==1){
						BuyBut.text="Wear";
						coast.text="In the chest";
						if(mm==4){
							BuyButton.SetActive (false);
							coast.text="Dressed";
						}
					}
					else{
						BuyBut.text="Buy";
						coast.text=skinNew.ToString ();
					}
				}
				itemName.text = "Sultan Aladeen";

				Mech[0].SetActive(false);
				Mech[1].SetActive(false);
				Mech[2].SetActive(false);
				Mech[3].SetActive(false);
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);
				butRight.SetActive(false);
				show = false;
				
				PlayerMesh.SetActive(false);
				PlayerMesh2.SetActive(true);
				Mech[3].SetActive(true);
			}		
		}
		else{

			if (mm == 4) {
				//PlayerMesh.SetActive(false);	
				//PlayerMesh2.SetActive(true);	
				//Mech[3].SetActive(true);
			} else {
				//PlayerMesh2.SetActive(false);	
				//PlayerMesh.SetActive(true);	
				
				if(mm == 2){
					PlayerMesh.GetComponent<Renderer>().material.mainTexture = RedCostum;	
				}
				else if(mm == 3){
					PlayerMesh.GetComponent<Renderer>().material.mainTexture = GreenCostum;	
				}
				else {
					PlayerMesh.GetComponent<Renderer>().material.mainTexture = StartCostum;	
				}
				// items other
				if(mem == 1){
					Mech[0].SetActive(true);
					Mech[1].SetActive(false);
					Mech[2].SetActive(false);
					Mech[3].SetActive(false);
				}
				else if(mem == 2){
					Mech[0].SetActive(false);
					Mech[1].SetActive(true);
					Mech[2].SetActive(false);
					Mech[3].SetActive(false);
				}
				else if(mem == 3){
					Mech[0].SetActive(false);
					Mech[1].SetActive(false);
					Mech[2].SetActive(true);
					Mech[3].SetActive(false);
				}
				else if(mem == 4){
					Mech[0].SetActive(false);
					Mech[1].SetActive(false);
					Mech[2].SetActive(false);
					Mech[3].SetActive(true);
				}
				else{
					Mech[0].SetActive(false);
					Mech[1].SetActive(false);
					Mech[2].SetActive(false);
					Mech[3].SetActive(false);
				}
				
				if(cm == 1){
					Shapki[0].SetActive(true);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(false);
				}
				else if(cm == 2){
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(true);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(false);
				}
				else if(cm == 3){
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(true);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(false);
				}
				else if(cm == 4){
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(true);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(false);
				}
				else if(cm == 5){
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(true);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(false);
				}
				else if(cm == 6){
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(true);
					Shapki[6].SetActive(false);
				}
				else if(cm == 7){
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(true);
				}
				else{
					Shapki[0].SetActive(false);
					Shapki[1].SetActive(false);
					Shapki[2].SetActive(false);
					Shapki[3].SetActive(false);
					Shapki[4].SetActive(false);
					Shapki[5].SetActive(false);
					Shapki[6].SetActive(false);
				}
			}
			if (mm == 4) {
				Shapki[0].SetActive(false);
				Shapki[1].SetActive(false);
				Shapki[2].SetActive(false);
				Shapki[3].SetActive(false);
				Shapki[4].SetActive(false);
				Shapki[5].SetActive(false);
				Shapki[6].SetActive(false);	
			}
		}
	}

	public void AddRight(){
		itemNumer++;
	}

	public void AddLeft(){
		itemNumer--;
	}
	public void Buy(){
		if (itemNumer == 1) {
			PlayerPrefs.SetInt("char", 1);
		} else if (itemNumer == 2) {
			if(rd==1){
				PlayerPrefs.SetInt("char", 2);
			}
			else{
				if(money>=skin1){
					PlayerPrefs.SetInt("char", 2);
					PlayerPrefs.SetInt ("rd_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-skin1);
				}
			}

		} else if (itemNumer == 3) {
			if(gr==1){
				PlayerPrefs.SetInt("char", 3);
			}
			else{
				if(money>=skin2){
					PlayerPrefs.SetInt("char", 3);
					PlayerPrefs.SetInt ("gr_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-skin2);
				}
			}

		} else if (itemNumer == 4) {
			if(c1==1){
				if(cm==1){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 1);
				}
			}
			else{
				if(money>=cape1){
					PlayerPrefs.SetInt("cap", 1);
					PlayerPrefs.SetInt ("c1_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape1);
				}
			}

		} else if (itemNumer == 5) {
			if(c2==1){
				if(cm==2){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 2);
				}
			}
			else{
				if(money>=cape2){
					PlayerPrefs.SetInt("cap", 2);
					PlayerPrefs.SetInt ("c2_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape2);
				}
			}

		} else if (itemNumer == 6) {
			if(c3==1){
				if(cm==3){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 3);
				}
			}
			else{
				if(money>=cape3){
					PlayerPrefs.SetInt("cap", 3);
					PlayerPrefs.SetInt ("c3_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape3);
				}
			}

		} else if (itemNumer == 7) {
			if(c4==1){
				if(cm==4){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 4);
				}
			}
			else{
				if(money>=cape4){
					PlayerPrefs.SetInt("cap", 4);
					PlayerPrefs.SetInt ("c4_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape4);
				}
			}

		} else if (itemNumer == 8) {
			if(c5==1){
				if(cm==5){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 5);
				}
			}
			else{
				if(money>=cape5){
					PlayerPrefs.SetInt("cap", 5);
					PlayerPrefs.SetInt ("c5_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape5);
				}
			}

		} else if (itemNumer == 9) {
			if(c6==1){
				if(cm==6){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 6);
				}
			}
			else{
				if(money>=cape6){
					PlayerPrefs.SetInt("cap", 6);
					PlayerPrefs.SetInt ("c6_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape6);
				}
			}

		} else if (itemNumer == 10) {
			if(c7==1){
				if(cm==7){
					PlayerPrefs.SetInt("cap", 0);
				}else{
					PlayerPrefs.SetInt("cap", 7);
				}
			}
			else{
				if(money>=cape7){
					PlayerPrefs.SetInt("cap", 7);
					PlayerPrefs.SetInt ("c7_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-cape7);
				}
			}

		} else if (itemNumer == 11) {
			if(m1==1){
				if(mem==1){
					PlayerPrefs.SetInt("mech", 0);
				}else{
					PlayerPrefs.SetInt("mech", 1);
				}
			}
			else{
				if(money>=metch1){
					PlayerPrefs.SetInt("mech", 1);
					PlayerPrefs.SetInt ("m1_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-metch1);
				}
			}

		} else if (itemNumer == 12) {
			if(m2==1){
				if(mem==2){
					PlayerPrefs.SetInt("mech", 0);
				}else{
					PlayerPrefs.SetInt("mech", 2);
				}
			}
			else{
				if(money>=metch2){
					PlayerPrefs.SetInt("mech", 2);
					PlayerPrefs.SetInt ("m2_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-metch2);
				}
			}

		} else if (itemNumer == 13) {
			if(m3==1){
				if(mem==3){
					PlayerPrefs.SetInt("mech", 0);
				}else{
					PlayerPrefs.SetInt("mech", 3);
				}
			}
			else{
				if(money>=metch3){
					PlayerPrefs.SetInt("mech", 3);
					PlayerPrefs.SetInt ("m3_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-metch3);
				}
			}

		} else if (itemNumer == 14) {
			if(m4==1){
				if(mem==4){
					PlayerPrefs.SetInt("mech", 0);
				}else{
					PlayerPrefs.SetInt("mech", 4);
				}
			}
			else{
				if(money>=metch4){
					PlayerPrefs.SetInt("mech", 4);
					PlayerPrefs.SetInt ("m4_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-metch4);
				}
			}

		} else if (itemNumer == 15) {
			if(ald==1){
				PlayerPrefs.SetInt("char", 4);
			}
			else{
				if(money>=skinNew){
					PlayerPrefs.SetInt("char", 4);
					PlayerPrefs.SetInt ("ald_pp", 1);
					PlayerPrefs.SetInt ("acoin", money-skinNew);
				}
			}
		}
	}

	public void MagnetUp(){
		if (money >= 750 && magLevel == 0) {
			PlayerPrefs.SetInt ("m_LvL", 1);
			PlayerPrefs.SetInt ("acoin", money - 750);
		} else if (money >= 2500 && magLevel == 1) {
			PlayerPrefs.SetInt ("m_LvL", 2);
			PlayerPrefs.SetInt ("acoin", money - 2500);
		} else if (money >= 5000 && magLevel == 2) {
			PlayerPrefs.SetInt ("m_LvL", 3);
			PlayerPrefs.SetInt ("acoin", money - 5000);
		} else if (money >= 7500 && magLevel == 3) {
			PlayerPrefs.SetInt ("m_LvL", 4);
			PlayerPrefs.SetInt ("acoin", money - 7500);
		} else if (money >= 10000 && magLevel == 4) {
			PlayerPrefs.SetInt ("m_LvL", 5);
			PlayerPrefs.SetInt ("acoin", money - 10000);
		}
	}

	public void KoverUp(){
		if (money >= 750 && kovLevel == 0) {
			PlayerPrefs.SetInt ("k_LvL", 1);
			PlayerPrefs.SetInt ("acoin", money - 750);
		} else if (money >= 2500 && kovLevel == 1) {
			PlayerPrefs.SetInt ("k_LvL", 2);
			PlayerPrefs.SetInt ("acoin", money - 2500);
		} else if (money >= 5000 && kovLevel == 2) {
			PlayerPrefs.SetInt ("k_LvL", 3);
			PlayerPrefs.SetInt ("acoin", money - 5000);
		} else if (money >= 7500 && kovLevel == 3) {
			PlayerPrefs.SetInt ("k_LvL", 4);
			PlayerPrefs.SetInt ("acoin", money - 7500);
		} else if (money >= 10000 && kovLevel == 4) {
			PlayerPrefs.SetInt ("k_LvL", 5);
			PlayerPrefs.SetInt ("acoin", money - 10000);
		}
	}

	public void BotUp(){
		if (money >= 750 && botLevel == 0) {
			PlayerPrefs.SetInt ("b_LvL", 1);
			PlayerPrefs.SetInt ("acoin", money - 750);
		} else if (money >= 2500 && botLevel == 1) {
			PlayerPrefs.SetInt ("b_LvL", 2);
			PlayerPrefs.SetInt ("acoin", money - 2500);
		} else if (money >= 5000 && botLevel == 2) {
			PlayerPrefs.SetInt ("b_LvL", 3);
			PlayerPrefs.SetInt ("acoin", money - 5000);
		} else if (money >= 7500 && botLevel == 3) {
			PlayerPrefs.SetInt ("b_LvL", 4);
			PlayerPrefs.SetInt ("acoin", money - 7500);
		} else if (money >= 10000 && botLevel == 4) {
			PlayerPrefs.SetInt ("b_LvL", 5);
			PlayerPrefs.SetInt ("acoin", money - 10000);
		}
	}

	public void DoubleUp(){
		if (money >= 750 && dLevel == 0) {
			PlayerPrefs.SetInt ("d_LvL", 1);
			PlayerPrefs.SetInt ("acoin", money - 750);
		} else if (money >= 2500 && dLevel == 1) {
			PlayerPrefs.SetInt ("d_LvL", 2);
			PlayerPrefs.SetInt ("acoin", money - 2500);
		} else if (money >= 5000 && dLevel == 2) {
			PlayerPrefs.SetInt ("d_LvL", 3);
			PlayerPrefs.SetInt ("acoin", money - 5000);
		} else if (money >= 7500 && dLevel == 3) {
			PlayerPrefs.SetInt ("d_LvL", 4);
			PlayerPrefs.SetInt ("acoin", money - 7500);
		} else if (money >= 10000 && dLevel == 4) {
			PlayerPrefs.SetInt ("d_LvL", 5);
			PlayerPrefs.SetInt ("acoin", money - 10000);
		}
	}
}
