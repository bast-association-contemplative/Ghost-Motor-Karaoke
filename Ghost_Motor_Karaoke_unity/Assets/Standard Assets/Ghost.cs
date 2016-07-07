using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

	private Animator animator;                  //Used to store a reference to the Player's animator component.

	//Rigidbody2D rb;

	//public GameObject player0;
	//Animator player0Animator;
	Vector3 pos;

	// Use this for initialization
	void Start () {
	
		//Get a component reference to the Player's animator component
		animator = GetComponent<Animator>();
		//player0Animator = player0.GetComponent<Animator> ();

		//rb = GetComponent<Rigidbody2D>();

		Vector3 pos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("f")){
			move(-0.1f);
		} else if(Input.GetKey("b")){
			move(0.1f);
		}
	}

	public void move (float distance) {
		animator.SetTrigger ("ghostForward");
		transform.position = new Vector3(transform.position.x + distance, transform.position.y);
		//transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
	}

	void OnCollisionEnter2D(Collision2D other) {

		Debug.Log ("Ghost collide with : " + other.transform.name);


		if (other.transform.name == "player0" || other.transform.name == "player1") {

			//animator.SetTrigger("ghosteat1");
			//WAIT
			transform.position = pos;
		}
	}
}
