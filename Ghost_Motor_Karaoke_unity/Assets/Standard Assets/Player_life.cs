using UnityEngine;
using System.Collections;

public class Player_life : MonoBehaviour {

	public int lifeSate = 3;

	public GameObject win;
	new AudioSource audio;

	void Start () {
		win.GetComponent<Renderer>().enabled = false;
		audio = GetComponent<AudioSource>();
	}
	
	void Update () {
	}

	public void life(){
		if (lifeSate >= 0) {
			transform.GetChild (lifeSate).gameObject.SetActive(false);
			lifeSate--;
			if (lifeSate == -1) {
				Debug.Log (transform.parent.name + " PERDU");

				if (audio.mute){
					audio.mute = false;
				}
				audio.Play();

				if (transform.parent.name == "player0") {
					win.GetComponent<SpriteRenderer>().enabled = true;
				} else if(transform.parent.name == "player1"){
					win.GetComponent<SpriteRenderer>().enabled = true;
				}
			}
		}
	}
}
