using UnityEngine;
using System.Collections;

public class ItemsOn : MonoBehaviour {

	public GameObject Mesh1;
	public GameObject Mesh2;
	public GameObject[] mechOn;
	public GameObject[] capOn;
	public Texture SCostum;
	public Texture RCostum;
	public Texture GCostum;

	private int meshnum;
	private int capnum;
	private int mechnum;

	void Start () {
		meshnum = PlayerPrefs.GetInt ("char");
		capnum = PlayerPrefs.GetInt ("cap");
		mechnum = PlayerPrefs.GetInt ("mech");
		if (meshnum == 4) {
			Mesh1.SetActive(false);	
			Mesh2.SetActive(true);	
			mechOn[3].SetActive(true);
		} else {
			Mesh2.SetActive(false);	
			Mesh1.SetActive(true);	

			if(meshnum == 2){
				//Mesh1.GetComponent<Renderer>().material.mainTexture = RCostum;	
			}
			else if(meshnum == 3){
				//Mesh1.GetComponent<Renderer>().material.mainTexture = GCostum;	
			}
			else {
				//Mesh1.GetComponent<Renderer>().material.mainTexture = SCostum;	
			}
			// items other
			if(mechnum == 1){
				mechOn[0].SetActive(true);
				mechOn[1].SetActive(false);
				mechOn[2].SetActive(false);
				mechOn[3].SetActive(false);
			}
			else if(mechnum == 2){
				mechOn[0].SetActive(false);
				mechOn[1].SetActive(true);
				mechOn[2].SetActive(false);
				mechOn[3].SetActive(false);
			}
			else if(mechnum == 3){
				mechOn[0].SetActive(false);
				mechOn[1].SetActive(false);
				mechOn[2].SetActive(true);
				mechOn[3].SetActive(false);
			}
			else if(mechnum == 4){
				mechOn[0].SetActive(false);
				mechOn[1].SetActive(false);
				mechOn[2].SetActive(false);
				mechOn[3].SetActive(true);
			}
			else{
				mechOn[0].SetActive(false);
				mechOn[1].SetActive(false);
				mechOn[2].SetActive(false);
				mechOn[3].SetActive(false);
			}

			if(capnum == 1){
				capOn[0].SetActive(true);
				capOn[1].SetActive(false);
				capOn[2].SetActive(false);
				capOn[3].SetActive(false);
				capOn[4].SetActive(false);
				capOn[5].SetActive(false);
				capOn[6].SetActive(false);
			}
			else if(capnum == 2){
				capOn[0].SetActive(false);
				capOn[1].SetActive(true);
				capOn[2].SetActive(false);
				capOn[3].SetActive(false);
				capOn[4].SetActive(false);
				capOn[5].SetActive(false);
				capOn[6].SetActive(false);
			}
			else if(capnum == 3){
				capOn[0].SetActive(false);
				capOn[1].SetActive(false);
				capOn[2].SetActive(true);
				capOn[3].SetActive(false);
				capOn[4].SetActive(false);
				capOn[5].SetActive(false);
				capOn[6].SetActive(false);
			}
			else if(capnum == 4){
				capOn[0].SetActive(false);
				capOn[1].SetActive(false);
				capOn[2].SetActive(false);
				capOn[3].SetActive(true);
				capOn[4].SetActive(false);
				capOn[5].SetActive(false);
				capOn[6].SetActive(false);
			}
			else if(capnum == 5){
				capOn[0].SetActive(false);
				capOn[1].SetActive(false);
				capOn[2].SetActive(false);
				capOn[3].SetActive(false);
				capOn[4].SetActive(true);
				capOn[5].SetActive(false);
				capOn[6].SetActive(false);
			}
			else if(capnum == 6){
				capOn[0].SetActive(false);
				capOn[1].SetActive(false);
				capOn[2].SetActive(false);
				capOn[3].SetActive(false);
				capOn[4].SetActive(false);
				capOn[5].SetActive(true);
				capOn[6].SetActive(false);
			}
			else if(capnum == 7){
				capOn[0].SetActive(false);
				capOn[1].SetActive(false);
				capOn[2].SetActive(false);
				capOn[3].SetActive(false);
				capOn[4].SetActive(false);
				capOn[5].SetActive(false);
				capOn[6].SetActive(true);
			}
			else{
				capOn[0].SetActive(false);
				capOn[1].SetActive(false);
				capOn[2].SetActive(false);
				capOn[3].SetActive(false);
				capOn[4].SetActive(false);
				capOn[5].SetActive(false);
				capOn[6].SetActive(false);
			}
		}
	}
	

}
