using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	float currentTimeScale;

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		currentTimeScale = Time.timeScale;
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Pressed(){
		if (Time.timeScale == 0) {
			Time.timeScale = currentTimeScale;
			pauseMenu.SetActive (false);
		} else {
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
		}


	}
}
