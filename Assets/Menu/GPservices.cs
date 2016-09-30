using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class GPservices : MonoBehaviour {

	private int hs;

	void Start () {
		Social.localUser.Authenticate((bool success) =>
		                              {
			if (success)
			{
				OnAddScoreToLeaderBorad();
			}
			else
			{
				Debug.Log("Login failed for some reason");
			}
		});

	}
	
	public void LeaderBoard () {

	}

	public void OnAddScoreToLeaderBorad()
	{
		if (PlayerPrefs.HasKey ("ihs")) {
			hs = PlayerPrefs.GetInt ("ihs");               
		}else{
			hs = 0;
		}
	
	}
	
	public void OnLogOut()
	{
	}
	
}