using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioM : MonoBehaviour {

	public static bool muted, ismut;
	private int m = 0;
	public Text  mutButton;
	private bool smn;
	public Slider volumsl;
	private float vol;
	public Text volpower;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start(){
		muted = false;
		ismut = false;
		if (PlayerPrefs.HasKey ("mute")) {
			m = PlayerPrefs.GetInt ("mute");
			if(m == 1){
				muted = true;
			}else{
				muted = false;
			}
		}else{
			muted = false;
		}
		if (PlayerPrefs.HasKey ("volum")) {
			volumsl.value = PlayerPrefs.GetFloat ("volum");
		} else {
			PlayerPrefs.SetFloat ("volum", 1f);
		}
	}

	public void isMute(){
		muted = !muted;
	}

	public void boolM(){
		smn = true;
		if (PlayerPrefs.HasKey ("volum")) {
			volumsl.value = PlayerPrefs.GetFloat ("volum");
		} else {
			volumsl.value = 100f;
		}
	}

	public void boolN(){
		smn = false;
	}

	void Update () {
		if (muted) {
			AudioListener.pause = true;
			PlayerPrefs.SetInt ("mute", 1);
			ismut = true;
			if(smn==true){
				 mutButton.text = "OFF";
				vol = volumsl.value;
				PlayerPrefs.SetFloat ("volum", vol);
				volpower.text = (PlayerPrefs.GetFloat ("volum")*100f).ToString ("f0") + "%";
			}
		} else {
			if(Controller.stopGame==false){
				AudioListener.pause = false;
				AudioListener.volume = PlayerPrefs.GetFloat ("volum");
				PlayerPrefs.SetInt ("mute", 0);
				if(smn==true){
					 mutButton.text = "ON";
					vol = volumsl.value;
					PlayerPrefs.SetFloat ("volum", vol);
					volpower.text = (PlayerPrefs.GetFloat ("volum")*100f).ToString ("f0") + "%";
				}
			}
			ismut = false;
		}

	}
}
