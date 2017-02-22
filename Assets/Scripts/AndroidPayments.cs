using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AndroidPayments : MonoBehaviour {

	public const string SKU_ADS = "hide_bunner";
	public const string SKU_10 = "buy10k_coin";
	public const string SKU_25 = "buy25k_coin";
	public const string SKU_100 = "buy100k_coin";
	public const string SKU_1M = "buy1m_coin";

		public const string googleKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgj+7vRwCo5dSFkmDbRRX9ccVD6xE4EaUajTnA2xINSK+BxIVDnLmw3naRKhh29H9iBXOlpTSGM7b7FvjSSh+btERs1QkH61OcA7EKDezcZEzh9R4Tw+v+gGXsGZXaq7uk76l+rS/taI396/EtrqPlgtEpJZOvlxIeAxgSNw5uOh6E+N77Zh3LPDHknZSrtMp2GSrGn88RceT58g9nBW8BjGSHv2rychv2iZi0mTHuo1/ghxrjjtaS5tRV2NYAjFtLDgOf4lKxv5bqZi07qz4em/J9g3WmARalH4BuSX5Z8N4OaUPpY6nWagIaYysEDIbULI/WzZAi2AiqL02bDsDHQIDAQAB";
	private int coinsc;

	private void Awake()
	{
	}
	
	private void OnDestroy()
	{
	}
	
	void Start() {
		
	}


	void Update(){
		if (PlayerPrefs.HasKey ("acoin")) {
			coinsc = PlayerPrefs.GetInt ("acoin");
		} else {
			coinsc = 0;	
		}
	}
		

	private void OnBillingSupported()
	{
	}
	
	private void OnBillingNotSupported(string error)
	{
		Debug.Log("Billing not supported: " + error);
	}


	private void OnQueryInventoryFailed(string error)
	{
		Debug.Log("Query inventory failed: " + error);
	}
	

	
	private void OnPurchaseFailed(int errorCode, string error)
	{
		Debug.Log("Purchase failed: " + error);
	}

	private void OnConsumePurchaseFailed(string error)
	{
		Debug.Log("Consume purchase failed: " + error);
	}
	
	private void OnTransactionRestored(string sku)
	{
		Debug.Log("Transaction restored: " + sku);
	}
	
	private void OnRestoreSucceeded()
	{
		Debug.Log("Transactions restored successfully");
	}
	
	private void OnRestoreFailed(string error)
	{
		Debug.Log("Transaction restore failed: " + error);
	}

}
