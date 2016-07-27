using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public int destroyTime = 4;

	void Start () {
		Destroy (gameObject, destroyTime);
	}
}
