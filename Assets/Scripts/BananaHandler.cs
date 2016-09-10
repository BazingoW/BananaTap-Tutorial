using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BananaHandler : MonoBehaviour {

	public float totalBan;
	public float bps;
	public Text totalBanTxt;
	public Text bpsTxt;
	int itemcount;


	public bool DependOnItems;
	float tapValue;
	public bool UpgradedTouch;


	public ShopHandler shopHandler;



	public Button buySomething;


	public float updateTime;
	float counter;

	public bool minimumUpdateTime;


	// Use this for initialization
	void Start () {
		LoadStuff ();
		BananasSecond ();
	}
	
	// Update is called once per frame
	void Update () {



		if (totalBan < 5)
			buySomething.interactable = false;
		else
			buySomething.interactable = true;



		if (minimumUpdateTime)
			updateTime = Time.deltaTime;

		bpsTxt.text= bps + " Bananas/Second";
		totalBanTxt.text= totalBan.ToString("F1") + " Bananas";


		if (counter < updateTime)
			counter += Time.deltaTime;
		else {
			totalBan+= bps*updateTime;
			PlayerPrefs.SetFloat("Score",totalBan);


			counter=0;
		}

	
	}
	public float ScreenTapped()
	{
		tapValue=1;

		if (DependOnItems)
			tapValue = itemcount * .4f;

		if (UpgradedTouch)
			tapValue = tapValue * 2;


		totalBan += tapValue;
		PlayerPrefs.SetFloat("Score",totalBan);

		return tapValue;
	}


	public void LoadStuff()
	{
		totalBan=PlayerPrefs.GetFloat("Score");
		foreach (ShopHandler.Item item in shopHandler.shopItems) {
			item.cost=PlayerPrefs.GetFloat(item.name+ "Cost",item.cost);
			item.count=PlayerPrefs.GetInt(item.name+"Count");

		}


	}




	public void moreBananas()
	{
		totalBan -= 5;
		bps += 10;

	}


	public void BananasSecond()
	{
		bps = 0;
		itemcount = 0;
		foreach (ShopHandler.Item item in shopHandler.shopItems) {
			itemcount+= item.count;
			bps= bps + item.count*item.gain;

			PlayerPrefs.SetInt(item.name + "Count",item.count);
			PlayerPrefs.SetFloat(item.name+ "Cost",item.cost);


		}




	}



}
