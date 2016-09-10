using UnityEngine;
using System.Collections;


public class ButtonsMaster : MonoBehaviour {

	public Animator shopanim;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void shopcontrol()
	{
		if (shopanim.GetBool ("isUp"))
			shopanim.SetBool ("isUp", false);
		else
			shopanim.SetBool ("isUp", true);

	}

	public void GotoUrl(string site)
	{
		Application.OpenURL (site);

	}



}
