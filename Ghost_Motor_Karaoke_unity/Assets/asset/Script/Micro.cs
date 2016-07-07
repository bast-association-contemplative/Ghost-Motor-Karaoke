using UnityEngine;
using System.Collections;



[RequireComponent(typeof(AudioSource))]
public class Micro : MonoBehaviour {

	//Add this script to an Object to move it with microphone sound. Sound is translated to a float y and then Vector3.y

	GameObject MoveThisObjectWithSound; //public GameObject MoveThisObjectWithSound;

	AudioSource audio;

	public int minAudio;

	//public float pan = -1.0f;

	void Start () {

		MoveThisObjectWithSound = this.gameObject; //MoveThisObjectWithSound = GameObject.FindGameObjectWithTag("Cube");
		audio = gameObject.AddComponent<AudioSource>() as AudioSource;
		audio.clip = Microphone.Start(Microphone.devices[0], true, 1, 44100);
	}

	void Update () {

		if (audio.isPlaying) {
			
		} else if (audio.clip.isReadyToPlay) {
			audio.Play ();
		} else {
			audio.clip = Microphone.Start (Microphone.devices[0], true, 1, 44100);
		}

		//audio.panStereo = pan;

		float y = audio.GetSpectrumData (128, 0, FFTWindow.BlackmanHarris) [64] * 1000000;

		if (y > minAudio) {
		
			y = map (y, 0, 100, 0, 10);
		
		} else {
			y = 0;
		}

		//Debug.Log (y);

		MoveThisObjectWithSound.transform.position += new Vector3 (-y/10, 0, 0) * Time.deltaTime;
	
	}

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}
}﻿

