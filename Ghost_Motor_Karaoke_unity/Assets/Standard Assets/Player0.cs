 using UnityEngine;
using System.Collections;

public class Player0 : MonoBehaviour {

	//THIS GAMEOBJECT
	private Animator animator;
	GameObject playerlife;

	//PLAYER 1 GAMEOBJECT
	public GameObject player1;
	Animator player1Animator;

	//COUNT DOWN
	public Transform Intro;

	//COLLIDER COUNTER
	private int collide = 0;

	//IMPACT ANIMATION ARRAY
	string[] arr = new string[]{"impact1","impact2","impact3","impact4","impact5","impact6"};

	void Start () {
		animator = GetComponent<Animator>();
		player1Animator = player1.GetComponent<Animator> ();
	}
	
	void Update () {
		if(collide >= 4){
			player1Animator.SetTrigger ("win02");
			animator.SetTrigger ("eat2");
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		playerlife = this.transform.Find ("vie").gameObject;
		playerlife.GetComponent<Player_life> ().life ();
		collide++;

		Destroy(GameObject.Find("Engine_Sound"), 0);
		Destroy(GameObject.Find("Engine_Sound(Clone)"), 0);

		if (collide < 4) {
			Instantiate(Intro);
			animator.SetTrigger (arr[Random.Range(0, arr.Length)]);
		}
	}
}
