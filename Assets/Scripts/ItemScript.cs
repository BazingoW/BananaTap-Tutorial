using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ItemScript : MonoBehaviour {


	public Image icon;
	public Text name;
	public Text cost;
	public Text gain;
	public Text count;
	public Button thisButton;



	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
