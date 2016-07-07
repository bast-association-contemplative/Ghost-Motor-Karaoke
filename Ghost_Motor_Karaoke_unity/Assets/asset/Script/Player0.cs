 using UnityEngine;
using System.Collections;

public class Player0 : MonoBehaviour {

	private Animator animator;                  //Used to store a reference to the Player's animator component.
	GameObject playerlife;

	public GameObject player1;
	GameObject player1life;
	Animator player1Animator;

	// Use this for initialization
	void Start () {
	
		//Get a component reference to the Player's animator component
		animator = GetComponent<Animator>();
		player1Animator = player1.GetComponent<Animator> ();
		player1life = player1.transform.Find("vie").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("z")){
			animator.SetTrigger ("impact1");
		} else if(Input.GetKeyDown("a")){
			animator.SetTrigger ("persoHit1");
			player1Animator.SetTrigger ("impact3");
			player1life.GetComponent<Player_life>().life();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {

		playerlife = this.transform.Find ("vie").gameObject;
		playerlife.GetComponent<Player_life> ().life ();
	}
}
