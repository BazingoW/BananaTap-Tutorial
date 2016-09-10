using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class ShopHandler : MonoBehaviour {
	public BananaHandler banHandler;
	public GameObject button;
	int counter;

	[System.Serializable]
	public class Item{
		public string name;
		public Sprite image;
		public float cost;
		public float gain;
		public int count;
	}


	public GameObject[] buttonItems;
	public Item[] shopItems;





	// Use this for initialization
	void Start () {

		buttonItems= new GameObject[shopItems.Length];


		counter = 0;
		foreach (Item i in shopItems)
		{
			GameObject btn = (GameObject)Instantiate(button);
			buttonItems[counter]=btn;
			ItemScript scp = btn.GetComponent<ItemScript>();
			scp.name.text=i.name;
			scp.cost.text= "Cost: " + i.cost.ToString("F1");
			scp.count.text= i.count.ToString();
			scp.gain.text= "BPS: " + i.gain.ToString("F1");
			scp.icon.sprite= i.image;

			Item thisItem = i;
			scp.thisButton.onClick.AddListener(() => Purchase(thisItem) );

			btn.transform.SetParent(this.transform);
			counter++;
		}


	}

	void Purchase(Item bought)
	{
		bought.count++;
		bought.cost = bought.cost * 1.2f;

		UpdateItems ();
		banHandler.BananasSecond ();
	}

	void UpdateItems()
	{


		counter = 0;
		foreach (Item i in shopItems)
		{										
			ItemScript scp = buttonItems[counter].GetComponent<ItemScript>();
			//btn.GetComponent<ItemScript>().name.text
			scp.name.text=i.name;
			scp.cost.text= "Cost: " + i.cost.ToString("F1");
			scp.count.text= i.count.ToString();
			scp.gain.text= "BPS: " + i.gain.ToString("F1");
			scp.icon.sprite= i.image;			

			counter++;
		}




	}


	
	// Update is called once per frame
	void Update () {

		counter = 0;
		foreach (Item i in shopItems)
		{
			if(i.cost> banHandler.totalBan)
				buttonItems[counter].GetComponent<Button>().interactable=false;
			else
				buttonItems[counter].GetComponent<Button>().interactable=true;

				counter++;
		}


	}
}
