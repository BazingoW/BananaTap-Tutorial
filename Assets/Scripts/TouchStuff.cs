using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchStuff : MonoBehaviour {


	public BananaHandler bh;

	public int maxFinger;
	int fingerCount;


	bool screenPressed;

	public GameObject cut;
	public GameObject plusBananas;

	Vector3 worldPos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(screenPressed){
		fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began && fingerCount<maxFinger)
			{

				this.GetComponent<Animator>().SetBool("Tapped",true);

				worldPos= Camera.main.ScreenToWorldPoint(touch.position);
				worldPos.z=0;



				Instantiate(cut,worldPos,Quaternion.Euler(0,0,Random.Range(80,100)));
				GameObject plusbans	=(GameObject)Instantiate(plusBananas,worldPos,Quaternion.identity);
					plusbans.GetComponentInChildren<Text>().text = "+" + bh.ScreenTapped();


			}

			fingerCount++;
				screenPressed=false;
			}
			
		}


	}

	public void TappedFalse()
	{
		this.GetComponent<Animator>().SetBool("Tapped",false);
	}

	public void CheckFingers()
	{
		screenPressed = true;
	}


}
