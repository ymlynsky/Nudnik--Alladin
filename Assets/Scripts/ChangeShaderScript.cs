using UnityEngine;
using System.Collections;

public class ChangeShaderScript : MonoBehaviour {

	public Renderer rend;
	public GameObject gameObject;

	// Use this for initialization
	void Start () {

			

		
		
	}
	
	// Update is called once per frame
	void Update () {

				switch(LetterCountController.countValue){

				case 0:
						rend.material.mainTexture = Resources.Load("1_alef_texture") as Texture;
						break;

				case 1:
						rend.material.mainTexture = Resources.Load("2_bet_texture") as Texture;
						break;

				case 2:
						rend.material.mainTexture = Resources.Load("3_vet_texture") as Texture;
						break;
				
				case 3:
						rend.material.mainTexture = Resources.Load("4_gimel_texture") as Texture;
						break;

				case 4:
						rend.material.mainTexture = Resources.Load("5_daled_texture") as Texture;
						break;

				case 5:
						rend.material.mainTexture = Resources.Load("6_hay_texture") as Texture;
						break;

				case 6:
						rend.material.mainTexture = Resources.Load("7_vav_texture") as Texture;
						break;

				case 7:
						rend.material.mainTexture = Resources.Load("8_zayin_texture") as Texture;
						break;
				
				case 8:
						rend.material.mainTexture = Resources.Load("9_chet_texture") as Texture;
						break;

				case 9:
						rend.material.mainTexture = Resources.Load("10_tet_texture") as Texture;
						break;

				case 10:
						rend.material.mainTexture = Resources.Load("11_yud_texture") as Texture;
						break;

				case 11:
						rend.material.mainTexture = Resources.Load("12_kaf_texture") as Texture;
						break;

				case 12:
						rend.material.mainTexture = Resources.Load("13_chaf_texture") as Texture;
						break;

				case 13:
						rend.material.mainTexture = Resources.Load("14_final_kaf_texture") as Texture;
						break;

				case 14:
						rend.material.mainTexture = Resources.Load("15_lamed_texture") as Texture;
						break;

				case 15:
						rend.material.mainTexture = Resources.Load("16_mem_texture") as Texture;
						break;

				case 16:
						rend.material.mainTexture = Resources.Load("17_final_mem_texture") as Texture;
						break;

				case 17:
						rend.material.mainTexture = Resources.Load("18_nun_texture") as Texture;
						break;

				case 18:
						rend.material.mainTexture = Resources.Load("19_final_nun_texture") as Texture;
						break;

				case 19:
						rend.material.mainTexture = Resources.Load("20_samekh_texture") as Texture;
						break;

				case 20:
						rend.material.mainTexture = Resources.Load("21_ayin_texture") as Texture;
						break;

				case 21:
						rend.material.mainTexture = Resources.Load("22_pay_texture") as Texture;
						break;

				case 22:
						rend.material.mainTexture = Resources.Load("23_fay_texture") as Texture;
						break;

				case 23:
						rend.material.mainTexture = Resources.Load("24_final_fay_texture") as Texture;
						break;

				case 24:
						rend.material.mainTexture = Resources.Load("25_tsadee_texture") as Texture;
						break;

				case 25:
						rend.material.mainTexture = Resources.Load("26_final_tsadee_texture") as Texture;
						break;

				case 26:
						rend.material.mainTexture = Resources.Load("27_kuf_texture") as Texture;
						break;

				case 27:
						rend.material.mainTexture = Resources.Load("28_resh_texture") as Texture;
						break;

				case 28:
						rend.material.mainTexture = Resources.Load("29_shin_texture") as Texture;
						break;

				case 29:
						rend.material.mainTexture = Resources.Load("30_sin_texture") as Texture;
						break;

				case 30:
						rend.material.mainTexture = Resources.Load("31_taf_texture") as Texture;
						break;

				case 31:
						rend.material.mainTexture = Resources.Load("32_thaf_texture") as Texture;
						break;

				default:
						//rend.material.mainTexture = Resources.Load("alef_texture") as Texture;
						break;
				}
	
	}
}
