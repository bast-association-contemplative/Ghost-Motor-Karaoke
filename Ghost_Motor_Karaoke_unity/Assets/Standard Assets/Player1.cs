using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

	private Animator thisPlayerAnimator;                  //Used to store a reference to the Player's animator component.
	GameObject playerlife;

	public GameObject player0;
	GameObject player0life;
	Animator player0Animator;

	public GameObject ghost;
	Animator ghostAnimator;

	// Use this for initialization
	void Start () {
	
		//Get a component reference to the Player's animator component
		thisPlayerAnimator = GetComponent<Animator>();

		player0Animator = player0.GetComponent<Animator> ();
		player0life = player0.transform.Find("vie").gameObject;

		ghostAnimator = ghost.GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			thisPlayerAnimator.SetTrigger ("impact3");
		} else if(Input.GetKeyDown("o")){
			thisPlayerAnimator.SetTrigger ("persoHit3");
			player0Animator.SetTrigger ("impact1");
			ghostAnimator.SetTrigger ("ghostForward");
			ghost.GetComponent<Ghost>().move(-1f);
			player0life.GetComponent<Player_life>().life();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		playerlife = this.transform.Find ("vie").gameObject;
		playerlife.GetComponent<Player_life> ().life ();
	}
}