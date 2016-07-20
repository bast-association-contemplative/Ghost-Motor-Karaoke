using UnityEngine;
using System.Collections;

public class Player_life : MonoBehaviour {

	public int lifeSate = 3;

	public GameObject win;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		win.GetComponent<Renderer>().enabled = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown("l") ){
			life();
		}
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
