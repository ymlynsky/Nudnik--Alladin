using UnityEngine;
using System.Collections;

public class sController : MonoBehaviour {
	[Header("Материалы блоков уровня список:")]
	public Material[] blocksMaterialList;

	[Header("Диапазон колебаний уровня по осям:")]
	[Range(5,35)]
	public float moveX;
	[Range(1,30)]
	public float moveY;
	[Range(1,100)]
	public float distance;
	bool ps;
	bool ok,ok2;
	float xPos,yPos;

	void Update()
	{
		ps = PauseMenu.Pause;
		if (ps == false) {
			float speed = Generation.speed;
		
			if (ok) {
				xPos = Mathf.Lerp (xPos, moveX, Time.deltaTime * speed / 85);
				if (xPos >= moveX - 0.01f)
					ok = !ok;
				} else {
				xPos = Mathf.Lerp (xPos, -moveX, Time.deltaTime * speed / 100);
					if (xPos <= -moveX + 0.01f)
					ok = !ok;
				}
		
				if (ok2) {
					yPos = Mathf.Lerp (yPos, moveY, Time.deltaTime * speed / 55);
					if (yPos >= moveY - 0.01f)
						ok2 = !ok2;
				} else {
				yPos = Mathf.Lerp (yPos, -moveY / 3, Time.deltaTime * speed / 35);
					if (yPos <= -moveY / 3 + 0.01f)
						ok2 = !ok2;
				}

				for (int i=0; i<blocksMaterialList.Length; i++) {
					blocksMaterialList [i].SetFloat ("_Dist", distance);
					blocksMaterialList [i].SetVector ("_QOffset", new Vector4 (xPos, yPos, 0, 0));
				}
		}
	}

}
