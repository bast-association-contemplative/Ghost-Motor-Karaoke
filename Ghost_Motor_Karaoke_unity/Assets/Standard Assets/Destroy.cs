using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public int destroyTime = 4;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
