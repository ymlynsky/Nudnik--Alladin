 using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.UI;

public class ADS_Unity : MonoBehaviour {

	private int coinsc2;
	private int BookCount2, MedalCount2, DudkaCount2, VazaCount2;
	public GameObject buttonBon;


	[SerializeField] string gameID = "1041254";
	public Text bonusText;
	private string bonusName;
	private int bonuseNumber;
	private bool generated;

	void Awake()
	{
		Advertisement.Initialize (gameID, false);
		generated = false;
	}
	
	public void ShowAd(string zone = "")
	{
		#if UNITY_EDITOR
		StartCoroutine(WaitForAd ());
		#endif
		
		if (string.Equals (zone, ""))
			zone = null;
		
		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;
		
		if (Advertisement.isReady (zone))
			Advertisement.Show (zone, options);
	}
	
	void AdCallbackhandler (ShowResult result)
	{
		switch(result)
		{
		case ShowResult.Finished:
			Debug.Log ("Ad Finished. Rewarding player...");
			InstansShow();
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		case ShowResult.Failed:
			Debug.Log("I swear this has never happened to me before");
			break;
		}
	}
	
	IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;
		
		while (Advertisement.isShowing)
			yield return null;
		
		Time.timeScale = currentTimeScale;
	}

	void Update(){
		if (Controller.die && !generated){
			buttonBon.SetActive (true);
			bonuseNumber = Random.Range (0,7);
			generated = true;
			switch(bonuseNumber){
			case 1:
				bonusName = "Get 250 coins";
				break;
			case 2:
				bonusName = "Get 3 books";
				break;
			case 3:
				bonusName = "Get 2 pipes";
				break;
			case 4:
				bonusName = "Get 4 amulets";
				break;
			case 5:
				bonusName = "Get 2 vazes";
				break;
			default:
				bonusName = "Get 100 coins";
				break;
				
			}
			bonusText.text = Advertisement.isReady() ? bonusName : "Generate Bonus";
		}

	}

	void InstansShow(){
		if (PlayerPrefs.HasKey ("acoin")) {
			coinsc2 = PlayerPrefs.GetInt ("acoin");
		} else {
			coinsc2 = 0;	
		}
		BookCount2 = PlayerPrefs.GetInt ("abook");
		VazaCount2 = PlayerPrefs.GetInt ("avaza");
		MedalCount2 = PlayerPrefs.GetInt ("amedal");
		DudkaCount2 = PlayerPrefs.GetInt ("adudka");
		
		switch(bonuseNumber){
		case 1:
			PlayerPrefs.SetInt ("acoin", coinsc2 + 250);
			break;
		case 2:
			PlayerPrefs.SetInt("abook", BookCount2 + 3);
			break;
		case 3:
			PlayerPrefs.SetInt("adudka", DudkaCount2 + 2);
			break;
		case 4:
			PlayerPrefs.SetInt("amedal", MedalCount2+4);
			break;
		case 5:
			PlayerPrefs.SetInt("avaza", VazaCount2 +2);
			break;
		default:
			PlayerPrefs.SetInt ("acoin", coinsc2 + 100);
			break;
			
		}
		buttonBon.SetActive (false);
		PlayerPrefs.Save ();
	}
}
