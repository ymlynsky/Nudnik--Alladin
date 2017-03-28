using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	public static bool Pause = false;
	public Text coinText;
	public Text goCoins;
	public Text goDist;
	public Text distanceText;
	private int coinCount;
	private int dist;
	private bool st;
	public Image magnit;
	public Image kover;
	public Image botu;
	public Image rawX2;
	public Image magnitBG;
	public Image koverBG;
	public Image botuBG;
	public Image rawX2BG;
	public Image SavB;
	private static bool end,isp;
	public Text LampCount;

	void Start(){
		end = false;
		isp = false;
	}

	public static void Paused()
	{
		isp = true;
		Pause = true;
	}

	public static void PausedOff()
	{
		isp = false;
		Pause = false;
	}

	public void Rest()
	{
		Pause = false;
		Application.LoadLevel("game");

	}
	public void Rest2()
	{
		end = true;
		Pause = false;
		Application.LoadLevel("game");
	}
	public void MainMenu()
	{
		Pause = false;
		Application.LoadLevel(0);
		
	}

	void Update(){
		if(LampCount != null){
			LampCount.text = AjPlayerController.roundLife.ToString ();
			if (AjPlayerController.die == true && end == false) {
			Pause = true;	
			} else if(AjPlayerController.die ==false && end ==true){
			Pause = false;	
		}
			if (AjPlayerController.lifesave==true) {
			Pause = true;
			SavB.fillAmount -= Time.deltaTime/4F;
			} else if(AjPlayerController.lifesave==false && AjPlayerController.die == false && isp == false){
			Pause = false;	
			SavB.fillAmount = 1;
		}
			/*
			if (AjPlayerController.stopGame == false) {
				if (AjPlayerController.magnetOn == true) {
				magnit.enabled = true;
				magnitBG.enabled = true;
					magnit.fillAmount = AjPlayerController.timer7/AjPlayerController.MagnetTime;
			} else {
				magnit.fillAmount = 1;
				magnit.enabled = false;
				magnitBG.enabled = false;
			}
				if (AjPlayerController.botOn == true) {
				botu.enabled = true;
				botuBG.enabled = true;
					botu.fillAmount = AjPlayerController.timer4/AjPlayerController.BotsTime;
			} else {
				botu.fillAmount = 1;
				botu.enabled = false;
				botuBG.enabled = false;	
			}
				if (AjPlayerController.jPuck == true) {
				kover.enabled = true;
				koverBG.enabled = true;
					kover.fillAmount -= Time.deltaTime/AjPlayerController.jPuckTime;
			} else {
				kover.fillAmount = 1;
				kover.enabled = false;
				koverBG.enabled = false;	
			}
				if (AjPlayerController.x2On == true) {
				rawX2.enabled = true;
				rawX2BG.enabled = true;
					rawX2.fillAmount = AjPlayerController.timer5/AjPlayerController.x2Time;
			} else {
				rawX2.fillAmount = 1;
				rawX2.enabled = false;
				rawX2BG.enabled = false;	
			}	
		}
		*/
		
		coinCount = AjPlayerController.coinCount;
		dist = (int)Generation.Distance;
		goCoins.text = coinCount.ToString ();
		goDist.text = dist.ToString ();
		if (Pause) {
				
		} else 
		{
			coinText.text = coinCount.ToString ();
			distanceText.text = dist.ToString ();
		}
		}
	}
}
