using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class CircularButtonScript : MonoBehaviour {

	public enum State {Active, Ready,Charging};

	public Image circle;
	public TouchStuff ts;


	public float activeTime;
	public float chargingTime=2f;
	float counter;


	public State status;

	// Use this for initialization
	void Start () {	
		Advertisement.Initialize("55594",true);



		status = State.Ready;
		circle.color = Color.blue;
		if (PlayerPrefs.GetFloat ("UpgradeCounter") < 0) {
			status=State.Charging;
			counter=0;
			//counter=PlayerPrefs.GetFloat ("UpgradeCounter");
		}else if(PlayerPrefs.GetFloat ("UpgradeCounter") > 0)
		{
			status=State.Charging;
			counter=PlayerPrefs.GetFloat ("UpgradeCounter");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if (status == State.Active) {
			counter+=Time.deltaTime;

			circle.fillAmount= 1-  counter/activeTime;
			PlayerPrefs.SetFloat("UpgradeCounter",-counter);
			if(counter>=activeTime)
			{status=State.Charging;
				counter=0;
				ts.maxFinger--;
			}

		}

		if (status == State.Ready) {
			counter=0;
			circle.fillAmount=1;
			circle.color=Color.blue;
		}

		if (status == State.Charging) {
			circle.color=Color.gray;
			counter+=Time.deltaTime;

			PlayerPrefs.SetFloat("UpgradeCounter",counter);

			circle.fillAmount= counter/chargingTime;

			if(counter>=chargingTime)
			{
				PlayerPrefs.SetFloat("UpgradeCounter",0);
				status=State.Ready;
			}

		}



	}

	public void Pressed()
	{
		if (status == State.Ready) {
			status=State.Active;
			ts.maxFinger++;


		}

		if (status == State.Charging) {

			if(Advertisement.IsReady("rewardedVideoZone"))
				Advertisement.Show("rewardedVideoZone", new ShowOptions {
					resultCallback = result => {
						status=State.Ready;
					}
				});


		}


	}

}
