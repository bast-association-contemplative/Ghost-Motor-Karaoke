using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load_lvl : MonoBehaviour {

	void Update () {
		//USE SPACE BAR FOR LOAD GMK SCENE
		if(Input.GetKeyDown(KeyCode.Space)){
			if (SceneManager.GetActiveScene().name == "Intro") {
				SceneManager.LoadScene("motor Karaoke");
			} else if (SceneManager.GetActiveScene().name == "motor Karaoke") {
				SceneManager.LoadScene("Intro");
			}
		}
	}
}
