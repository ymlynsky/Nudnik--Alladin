using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text coinT;
	public Text distanc;
	public Text books;
	public Text vaza;
	public Text zmey;
	public Text medal;
	public Text dudka;
	public Text qual;
	private int qlevel;
	public GameObject mMenu;
	public GameObject ExitMenu;
	public GameObject SettingMenu;
	public GameObject MissionMenu;
	public GameObject ShopMenu;
	private bool mm,sm, em,msm,shm;
	private int b,v,z,m,d,dComplited;
	public static bool unLock;

	void Start(){
		unLock = false;	
		if (PlayerPrefs.HasKey ("Dist")) {
			dComplited = PlayerPrefs.GetInt ("Dist");
		} else {
			dComplited = 2;	
		}
		b = PlayerPrefs.GetInt ("abook");
		v = PlayerPrefs.GetInt ("avaza");
		z = PlayerPrefs.GetInt ("azmey");
		m = PlayerPrefs.GetInt ("amedal"); 
		d = PlayerPrefs.GetInt ("adudka");
		if(dComplited==1){distanc.text = "compleit";} 
		else {
			distanc.text = "none";
		}
		if (Generation.Distance>=10000F&& dComplited!=1) {
			distanc.text = "compleit";
			dComplited = 1;
			PlayerPrefs.SetInt("Dist", dComplited);
			PlayerPrefs.Save ();
		} else {
			dComplited = 2;
		}
		if (b >= 100) {
			books.text = "compleit";	
		} else {
			books.text = PlayerPrefs.GetInt("abook").ToString()+" / 100";	
		}
		if (v >= 75) {
			vaza.text = "compleit";	
		} else {
			vaza.text = PlayerPrefs.GetInt("avaza").ToString()+" / 75";
		}
		if (z >= 30) {
			zmey.text = "compleit";	
		} else {
			zmey.text = PlayerPrefs.GetInt("azmey").ToString()+" / 30";
		}
		if (m >= 500) {
			medal.text = "compleit";	
		} else {
			medal.text = PlayerPrefs.GetInt("amedal").ToString()+" / 500";
		}
		if (d >= 80) {
			dudka.text = "compleit";	
		} else {
			dudka.text = PlayerPrefs.GetInt("adudka").ToString()+" / 80";
		}

		if(PlayerPrefs.HasKey("UQuality")){
			qlevel = PlayerPrefs.GetInt("UQuality");
			QualitySettings.SetQualityLevel (qlevel, true);
			if(qlevel ==0){
				qual.text = "Fast";
				QualitySettings.SetQualityLevel(0, true);
				qlevel = 0;
			}
			else if(qlevel ==1){
				QualitySettings.SetQualityLevel(1, true);
				qlevel = 1;
				qual.text = "Simple";
			}
			else if(qlevel ==2){
				qual.text = "Normal";
				QualitySettings.SetQualityLevel(2, true);
				qlevel = 2;
			}
			else if(qlevel ==3){
				qual.text = "Good";
				QualitySettings.SetQualityLevel(3, true);
				qlevel = 3;
			}
			else if(qlevel ==4){
				qual.text = "Beautiful";
				QualitySettings.SetQualityLevel(4, true);
				qlevel = 4;
			}
			else if(qlevel ==5){
				qual.text = "Fantastic";
				QualitySettings.SetQualityLevel(5, true);
				qlevel = 5;
			}
		}else {
			QualitySettings.SetQualityLevel(1, true);
			qlevel = 1;
			qual.text = "Simple";
		}
		mm = true;
	}


	void Update(){
		if (dComplited == 1 && b >= 100 && v >= 75 && z >= 30 && m >= 500 && d >= 80) {
			unLock = true;	
		} else {
			unLock = false;	
		}
		coinT.text = PlayerPrefs.GetInt ("acoin").ToString ();
		if (mm) {
			mMenu.SetActive (true);
		} else {
			mMenu.SetActive (false);
		}
		if (em) {
			ExitMenu.SetActive (true);
		} else {
			ExitMenu.SetActive (false);
		}
		if (sm) {
			SettingMenu.SetActive (true);
		} else {
			SettingMenu.SetActive (false);
		}
		/*if (msm) {
			MissionMenu.SetActive (true);
		} else {
			MissionMenu.SetActive (false);
		}
		if (shm) {
			ShopMenu.SetActive (true);
		} else {
			ShopMenu.SetActive (false);
		}
		*/
	}

	public void QuitGame(){
		em = true;
		mm = sm = msm = shm = false;
	}
	public void goExit(){
		Application.Quit ();
	}
	public void GoBack(){
		PlayerPrefs.Save();
		mm = true;
		em = sm = msm = shm = false;
	}

	public void Sets(){
		sm = true;
		em = mm = msm = shm = false;
	}

	public void Miss(){
		msm = true;
		em = sm = mm = shm = false;
	}

	public void Shop(){
		shm = true;
		em = sm = msm = mm = false;
	}

	public void QualityButton(){
		if (qlevel == 0) {
			QualitySettings.SetQualityLevel(1, true);
			qlevel = 1;
			qual.text = "Simple";
		}
		else if (qlevel == 1) {
			QualitySettings.SetQualityLevel(2, true);
			qlevel = 2;
			qual.text = "Normal";
		}
		else if (qlevel == 2) {
			QualitySettings.SetQualityLevel(3, true);
			qlevel = 3;
			qual.text = "Good";
		}
		else if (qlevel == 3) {
			QualitySettings.SetQualityLevel(4, true);
			qlevel = 4;
			qual.text = "Beautiful";
		}
		else if (qlevel == 4) {
			QualitySettings.SetQualityLevel(5, true);
			qlevel = 5;
			qual.text = "Fantastic";
		}
		else if (qlevel == 5) {
			QualitySettings.SetQualityLevel(0, true);
			qlevel = 0;
			qual.text = "Fast";
		}
		PlayerPrefs.SetInt("UQuality", qlevel);
	}

	public void StartGame(){
		PauseMenu.Pause = false;
		Application.LoadLevel (1);
	}
}
