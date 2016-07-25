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

	public Transform Intro;

	private int collide = 0;

	string[] arr = new string[]{"impact1","impact2","impact3","impact4","impact5","impact6"};

	void Start () {
	
		thisPlayerAnimator = GetComponent<Animator>();

		player0Animator = player0.GetComponent<Animator> ();
		player0life = player0.transform.Find("vie").gameObject;

		ghostAnimator = ghost.GetComponent<Animator> ();
	}
	
	void Update () {
		if(Input.GetKeyDown("p")){
			thisPlayerAnimator.SetTrigger ("impact3");
		} else if(Input.GetKeyDown("o")){
			thisPlayerAnimator.SetTrigger ("persoHit3");
			player0Animator.SetTrigger ("impact1");
			ghostAnimator.SetTrigger ("ghostForward");
			ghost.GetComponent<Ghost>().move(-1f, 0.5f);
			player0life.GetComponent<Player_life>().life();
		}

		if(collide >= 4){
			player0Animator.SetTrigger ("win01");
			thisPlayerAnimator.SetTrigger ("eat2");
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
			thisPlayerAnimator.SetTrigger (arr[Random.Range(0, arr.Length)]);
		}
	}
}