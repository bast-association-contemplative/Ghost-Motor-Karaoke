using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Ghost : MonoBehaviour {

	private Animator animator;

	public AudioClip[] impactSound;
	AudioSource audio;

	//Rigidbody2D rb;

	//public GameObject player0;
	//Animator player0Animator;
	Vector3 pos;

	void Start () {

		animator = GetComponent<Animator>();
		//rb = GetComponent<Rigidbody2D>();

		pos = transform.position;

		audio = GetComponent<AudioSource>();
	}

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
	}

	void OnCollisionEnter2D(Collision2D other) {

		Debug.Log ("Ghost collide with : " + other.transform.name);

		if (other.transform.name == "player0" || other.transform.name == "player1") {

			//animator.SetTrigger("ghosteat1");
			//WAIT

			audio.clip = impactSound[Random.Range(0, impactSound.Length)];
			audio.Play();

			transform.position = pos;
		}
	}
}
