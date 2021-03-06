﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {

	//THIS GAMEOBJECT
	private Animator thisPlayerAnimator;
	GameObject playerlife;

	//PLAYER 0 GAMEOBJECT
	public GameObject player0;
	Animator player0Animator;

	//COUNT DOWN
	public Transform Intro;

	//COLLIDER COUNTER
	private int collide = 0;

	//IMPACT ANIMATION ARRAY
	string[] arr = new string[]{"impact1","impact2","impact3","impact4","impact5","impact6"};

	private float finishTime = 0.0F;
	private float restartTime = 20.0F;
	private bool win = false;

	void Start () {
		thisPlayerAnimator = GetComponent<Animator>();
		player0Animator = player0.GetComponent<Animator> ();
	}
	
	void Update () {
		if(collide >= 4){
			player0Animator.SetTrigger ("win01");
			thisPlayerAnimator.SetTrigger ("eat2");

			if (win == false) {
				finishTime = Time.time + restartTime;
				Debug.Log (finishTime);
			}
			win = true;
		}

		if (win == true && Time.time > finishTime) {
			//Debug.Log("RESTART");
			SceneManager.LoadScene("Intro");
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