using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer background;

	void Start () {
		background = GetComponent<SpriteRenderer>();
		background.sprite = sprites[Random.Range (0, sprites.Length)];
	}
}