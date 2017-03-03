using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Generation : MonoBehaviour
{
	[Space (12)]
	[Header ("Добавляем префабы блоков уровня:")]
	public Transform[] blocksPrefabs;
	[Header ("Дистанция которую пробежал игрок:")]
	public static float Distance;
	[Header ("Настройки скорости игрока:")]
	[Tooltip ("Через каждые Х-метров скорость будет увеличиваться на значение переменной speedAdd")]
	public float speedAddDistance = 50;
	[Tooltip ("На сколько увеличивать скорость бега")]
	public float speedAdd = 0.5f;
	[Tooltip ("Максимальная скорость бега")]
	public float speedMax = 14.0f;
	[Header ("Конфигурации генерации уровня:")]
	[Range (1, 5)]
	[Tooltip ("Количество блоков на старте и в уровне")]
	public int BlockCounth = 3;
	public static float speed = 10.0f;
	private bool isPause;
	public static  bool isStart;
	private float posY = 0.0f;
	private int bcount;
	private int speedBonus = 100;
	LinkedList<Transform> roads = new LinkedList<Transform> ();
	MeshFilter[] meshF;
	private int idist;
	public Image coinImage;
	private string[] letterNameArray = {"1_alef_texture","2_bet_texture","3_vet_texture", "4_gimel_texture", "5_daled_texture", "6_hay_texture", "7_vav_texture", "8_zayin_texture","9_chet_texture", "10_tet_texture", "11_yud_texture", "12_kaf_texture", "13_chaf_texture", "14_final_kaf_texture", "15_lamed_texture", "16_mem_texture", "17_final_mem_texture", "18_nun_texture", "19_final_nun_texture", "20_samekh_texture", "21_ayin_texture","22_pay_texture", "23_fay_texture", "24_final_fay_texture", "25_tsadee_texture", "26_final_tsadee_texture", "27_kuf_texture","28_resh_texture", "29_shin_texture", "30_sin_texture", "31_taf_texture", "32_thaf_texture"};

	void Start ()
	{
		PlayerPrefs.DeleteAll();
		isPause = false;
		isStart = false;
		Distance = 0;
		speed = 10.0f;
		for (int i = 0; i < BlockCounth; i++) {
			Transform road = Instantiate (blocksPrefabs [i]) as Transform;
			road.Translate (0, posY, i * road.localScale.z + 35f);

			if (i > 0) {
				//Debug.Log (road.transform.Find ("Road_1"));
				road.Translate (0, posY, i * road.localScale.z + GetTotalMeshFilterBounds (road).size.z - 0.7f);
			}


			if (i >= 1) {
				isStart = false;
			}
			roads.AddLast (road);

		}

		int level = PlayerPrefs.GetInt ("level");
		string coin ="letter_sprites/"+letterNameArray [level]+"_sprite";
		Sprite sprite=Resources.Load<Sprite> (coin);
		coinImage.sprite = sprite;
	
	}

	void Update ()
	{
		if (PlayerPrefs.HasKey ("ihs")) {
			idist = PlayerPrefs.GetInt ("ihs");
		} else {
			idist = 0;	
		}
		if (Distance > idist && Controller.die) {
			idist = (int)Distance;
			PlayerPrefs.SetInt ("ihs", idist);
			PlayerPrefs.Save ();
		} 
		if (Controller.jPuck == true) {
			speedBonus = 3;
		} else {
			speedBonus = 1;
		}
		isPause = PauseMenu.Pause;
		if (!isPause) {
			Distance += (speed * speedBonus / 3 * Time.deltaTime);
			if (Distance >= speedAddDistance) {
				AddSpeed ();
			}
			Transform firstRoad = roads.First.Value;
			Transform lastRoad = roads.Last.Value;
			if (firstRoad.localPosition.z < -firstRoad.localScale.z / 2 - 46F) {
				roads.Remove (firstRoad);
				bcount++;
				Destroy (firstRoad.gameObject);

				Transform newRoad = Instantiate (blocksPrefabs [UnityEngine.Random.Range (1, blocksPrefabs.Length)], new Vector3 (0, posY, lastRoad.localPosition.z + GetTotalMeshFilterBounds (lastRoad).size.z - 1f), Quaternion.identity) as Transform;
				roads.AddLast (newRoad);
			}
			foreach (Transform road in roads) {
				road.Translate (0, 0, -(speed * speedBonus) * Time.deltaTime); 
			}	
		}




	}

	private void AddSpeed ()
	{
		speed += speedAdd;
		speedAddDistance = speedAddDistance * 2;
		if (speed > speedMax) {
			speed = speedMax;
		}
	}

	private static Bounds GetTotalMeshFilterBounds (Transform objectTransform)
	{
		var meshFilter = objectTransform.GetComponent<MeshFilter> ();
		var result = meshFilter != null ? meshFilter.mesh.bounds : new Bounds ();

		foreach (Transform transform in objectTransform) {
			var bounds = GetTotalMeshFilterBounds (transform);
			result.Encapsulate (bounds.min);
			result.Encapsulate (bounds.max);
		}
		var scaledMin = result.min;
		scaledMin.Scale (objectTransform.localScale);
		result.min = scaledMin;
		var scaledMax = result.max;
		scaledMax.Scale (objectTransform.localScale);
		result.max = scaledMax;
		return result;
	}



}