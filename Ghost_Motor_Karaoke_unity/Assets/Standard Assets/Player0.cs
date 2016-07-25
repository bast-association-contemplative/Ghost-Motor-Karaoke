 using UnityEngine;
using System.Collections;

public class Player0 : MonoBehaviour {

	private Animator animator;                  //Used to store a reference to the Player's animator component.
	GameObject playerlife;

	public GameObject player1;
	GameObject player1life;
	Animator player1Animator;

	public Transform Intro;

	private int collide = 0;

	string[] arr = new string[]{"impact1","impact2","impact3","impact4","impact5","impact6"};

	void Start () {
		animator = GetComponent<Animator>();
		player1Animator = player1.GetComponent<Animator> ();
		player1life = player1.transform.Find("vie").gameObject;
	}
	
	void Update () {
		if(Input.GetKeyDown("z")){
			animator.SetTrigger ("impact1");
		} else if(Input.GetKeyDown("a")){
			animator.SetTrigger ("persoHit1");
			player1Animator.SetTrigger ("impact3");
			player1life.GetComponent<Player_life>().life();
		}

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
