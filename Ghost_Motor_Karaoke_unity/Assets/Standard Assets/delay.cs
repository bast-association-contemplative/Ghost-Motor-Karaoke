using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class delay : MonoBehaviour {

	AudioSource audio;

	public AudioClip engineStartClip;
	public AudioClip engineLoopClip;

	void Start()
	{
		audio = GetComponent<AudioSource> ();
		//audio.loop = true;
		StartCoroutine(playEngineSound());
	}

	IEnumerator playEngineSound()
	{
		audio.clip = engineStartClip;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = engineLoopClip;
		audio.Play();
	}

	void Update(){

	}

}
