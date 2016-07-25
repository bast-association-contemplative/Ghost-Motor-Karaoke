using UnityEngine;
using System.Collections;

public class Load_lvl : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("g")){
			if (Application.loadedLevelName == "Intro") {
				Application.LoadLevel ("motor Karaoke");
			} else if (Application.loadedLevelName == "motor Karaoke") {
				Application.LoadLevel ("Intro");
			}
		}
	}
}
