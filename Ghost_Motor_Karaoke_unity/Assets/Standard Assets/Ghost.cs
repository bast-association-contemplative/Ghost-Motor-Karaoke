using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Ghost : MonoBehaviour {

	private Animator animator;

	public AudioClip[] impactSound;
	AudioSource audio;

	public int CollidePlayer0 = 0;
	public int CollidePlayer1 = 0;

	Vector3 pos;

	void Start () {
		animator = GetComponent<Animator>();
		pos = transform.position;
		audio = GetComponent<AudioSource>();
	}

	void Update () {
		if(Input.GetKey("f")){
			move(-0.1f, 0.5f);
		} else if(Input.GetKey("b")){
			move(0.1f, -0.5f);
		}
	}

	public void move (float distance, float direction) {
		animator.SetTrigger ("ghostForward");
		transform.position = new Vector3(transform.position.x + distance, transform.position.y);
		transform.localScale = new Vector3(direction, 0.5f, 0.5f);
	}

	void OnCollisionEnter2D(Collision2D other) {

		Debug.Log ("Ghost collide with : " + other.transform.name);

		if (other.transform.name == "player0" || other.transform.name == "player1") {

			//animator.SetTrigger("ghosteat1");
			//WAIT

			audio.clip = impactSound[Random.Range(0, impactSound.Length)];
			audio.Play();
		}

		if (other.transform.name == "player0") {

			CollidePlayer0++;

			if (CollidePlayer0 < 4){
				transform.position = pos;
			}/* else if(CollidePlayer0 >= 4){
				animator.SetTrigger ("ghosteat1");
			}*/

		} else if(other.transform.name == "player1"){
			CollidePlayer1++;

			if (CollidePlayer1 < 4){
				transform.position = pos;
			} /*else if(CollidePlayer1 >= 4){
				animator.SetTrigger ("ghosteat1");
			}*/
		}
	}
}
