using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer background;

	// Use this for initialization
	void Start () {
		background = GetComponent<SpriteRenderer>();
		background.sprite = sprites[Random.Range (0, sprites.Length)];
	}
}